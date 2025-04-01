using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EventProject.Api.Services
{
    public static class AuthenticationService
    {
        public static IServiceCollection AddAuthentication(this IServiceCollection services,IConfiguration configuration) {

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme= JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateAudience=true,
                    ValidateIssuer=true,        
                    ValidateIssuerSigningKey=true,
                    ValidateLifetime=true,
                    ValidAudience = configuration["JWT:ValidAudince"],
                    ValidIssuer = configuration["JWT:ValidIssuer"],
                    IssuerSigningKey =new SymmetricSecurityKey( Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!))
                };
            });
            return services; }
    }
}
