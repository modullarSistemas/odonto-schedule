using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;
using PlanejaOdonto.Api.Domain.Models.LoginAggregate;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace PlanejaOdonto.Api.Authentication
{
    public static class TokenService
    {
        public static void AddJwtAuthentication(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(Startup.Configuration.GetSection("Authentication").GetValue<string>("Secret"));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer
            (x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

            }
            );
        }

        public static string GenerateToken(User usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Startup.Configuration.GetSection("Authentication").GetValue<string>("Secret"));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                         new Claim(ClaimTypes.Name,usuario.Username.ToString())
                        ,new Claim(ClaimTypes.Role,usuario.Role.ToString())
                    })
                ,Expires = DateTime.UtcNow.AddHours(2)
                , SigningCredentials = 
                    new SigningCredentials(
                            new SymmetricSecurityKey (key),
                            SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
