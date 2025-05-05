using EventProject.Api.Middlewares;
using EventProject.Api.Services;
using EventProject.Application;

using EventProject.Infrastructure;
using EventProject.Infrastructure.Services.Storage.Azure;
using EventProject.Persistence;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EventProject.API", Version = "v1" });

    // JWT üçün auth konfiqi
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
builder.Services.AddCors(options => options.AddPolicy("AllowAll",policy =>
    policy.WithOrigins().AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));







var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";



var app = builder.Build();
 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()||app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting(); // <-- bu olmalıdır!

app.UseCors(); // <-- CORS burada olmalıdır!

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<ExceptionHandlerMiddleware>();





app.Run();
