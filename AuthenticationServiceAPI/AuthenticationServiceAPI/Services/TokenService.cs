using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationServiceAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;

        public TokenService(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public string GenerateToken(string email, string password)
        {
            var claims = new List<Claim>
            {
                new Claim("EmailId", email),
                new Claim("Password",password)
            };
            var byteArray = Encoding.UTF8.GetBytes(configuration["Token:SecretKey"]);
            var userSymmetricSecurityKey = new SymmetricSecurityKey(byteArray);
            var userSigningCredentials = new SigningCredentials(userSymmetricSecurityKey, SecurityAlgorithms.HmacSha256);


            var userJwtSecurityToken = new JwtSecurityToken(
                issuer: configuration["Token:Issuer"],
                audience: configuration["Token:Audience"],
                signingCredentials: userSigningCredentials,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15)
                );

            var userJwtSecurityTokenHandler = new { token = new JwtSecurityTokenHandler().WriteToken(userJwtSecurityToken) ,email=email};
            var jsonTokenObject = JsonConvert.SerializeObject(userJwtSecurityTokenHandler);
            return jsonTokenObject;
        }
    }
}

