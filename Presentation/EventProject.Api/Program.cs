using EventProject.Api.Middlewares;
using EventProject.Api.Services;
using EventProject.Application;
using EventProject.Application.Abstractions.Jobs;
using EventProject.Infrastructure;
using EventProject.Infrastructure.Services.Storage.Azure;
using EventProject.Persistence;
using Hangfire;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EventProject.API", Version = "v1" });

     
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Tokeni aşağıdakı formatda daxil edin:  
                        Bearer eyJhbGciOi... (JWT token)",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
   
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

 
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddStorage<AzureStorage>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthenticationMain(builder.Configuration);
builder.Services.AddInfrastructureService(builder.Configuration);


builder.Services.AddCors(options => options.AddPolicy("AllowAll", policy =>
    policy
        .WithOrigins("http://localhost:3000", "http://localhost:5173", "http://localhost:5174")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
));



builder.Services.AddHangfire(config =>
    config.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHangfireServer();

var app = builder.Build();

 
using (var scope = app.Services.CreateScope())
{
    var jobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();

    jobManager.AddOrUpdate<IRecentlyViewedJob>(
        "delete-old-recentlyviewed-events",
        job => job.DeleteOldRecentlyViewedEvents(),
        Cron.Daily); 
}

 
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

 
app.UseHangfireDashboard("/jobs");

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.MapControllers();

app.Run();
