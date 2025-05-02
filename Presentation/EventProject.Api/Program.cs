using EventProject.Api.Middlewares;
using EventProject.Api.Services;
using EventProject.Application;

using EventProject.Infrastructure;
using EventProject.Infrastructure.Services.Storage.Azure;
using EventProject.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddStorage<AzureStorage>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthenticationMain(builder.Configuration);
builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("http://localhost:5173", "https://localhost:5173").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
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

app.UseRouting(); 

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<ExceptionHandlerMiddleware>();





app.Run();
