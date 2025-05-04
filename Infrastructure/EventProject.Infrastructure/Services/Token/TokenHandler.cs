using EventProject.Application.Abstractions.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace EventProject.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration configuration;

        public TokenHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Application.DTOs.Token CreateAccessToken(List<Claim> claims, int minute)
        {
            var token = new Application.DTOs.Token();


            //biizm security key
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!));

            //sifrelenmis kod
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            token.ExpirationDate = DateTime.Now.AddMinutes(minute);
            JwtSecurityToken securityToken = new JwtSecurityToken(
                audience: configuration["JWT:ValidAudience"],
                claims:claims,
                issuer: configuration["JWT:ValidIssuer"],
                expires: token.ExpirationDate,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
                );
            //token creator classs
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            token.AccessToken=jwtSecurityTokenHandler.WriteToken(securityToken);
            return token;
        }

        public string CreateRefreshToken()
        {
            var bytes = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
