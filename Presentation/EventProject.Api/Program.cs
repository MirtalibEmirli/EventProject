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

// ✅ Controller və Swagger konfiqurasiyası
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EventProject.API", Version = "v1" });

    // ✅ JWT üçün Swagger auth əlavə edilir
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

// ✅ Layihənin bütün qatlarını inject et
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddStorage<AzureStorage>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthenticationMain(builder.Configuration);
builder.Services.AddInfrastructureService(builder.Configuration);

// ✅ CORS siyasəti
builder.Services.AddCors(options => options.AddPolicy("AllowAll", policy =>
    policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
));

// ✅ Hangfire konfiqurasiyası
builder.Services.AddHangfire(config =>
    config.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHangfireServer();

var app = builder.Build();

// ✅ Recurring Job qeydiyyatı (Hangfire)
using (var scope = app.Services.CreateScope())
{
    var jobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();

    jobManager.AddOrUpdate<IRecentlyViewedJob>(
        "delete-old-recentlyviewed-events",
        job => job.DeleteOldRecentlyViewedEvents(),
        Cron.Daily); // istəsən Cron.Hourly və ya test üçün Cron.Minutely də edə bilərsən
}

// ✅ Middleware və Endpoint konfiqurasiyası
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

// ✅ Hangfire dashboard (istəsən auth ilə məhdudlaşdıra bilərik)
app.UseHangfireDashboard("/jobs");

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.MapControllers();

app.Run();
