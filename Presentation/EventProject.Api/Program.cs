using EventProject.Api.Middlewares;
using EventProject.Api.Services;
using EventProject.Application;
using EventProject.Application.Abstractions.Jobs;
using EventProject.Infrastructure;
using EventProject.Infrastructure.Services.Storage.Azure;
using EventProject.Persistence;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddStorage<AzureStorage>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthenticationMain(builder.Configuration);
builder.Services.AddInfrastructureService(builder.Configuration);

builder.Services.AddCors(options => options.AddPolicy("AllowAll", policy =>
    policy.WithOrigins().AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));


builder.Services.AddHangfire(config =>
    config.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHangfireServer();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();

    recurringJobManager.AddOrUpdate<IRecentlyViewedJob>(
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
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.UseHangfireDashboard("/jobs");

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.MapControllers();

app.Run();
