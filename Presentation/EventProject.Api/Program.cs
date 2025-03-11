using EventProject.Api.Middlewares;
using EventProject.Application;
using EventProject.Application.Services;
using EventProject.Application.Settings;
using EventProject.Persistence;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("http://localhost:5177", "https://localhost:5177").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));





var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

#region cloudinary services
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<CloudinarySettings>>().Value);
builder.Services.AddScoped<CloudinaryService>();
#endregion

var app = builder.Build();
app.UseCors();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<ExceptionHandlerMiddleware>();





app.Run();
