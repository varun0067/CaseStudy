using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using Newtonsoft.Json;

namespace AuthenticationAPI.Service
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GenerateToken(int userId,string userName)
        {
            var userClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName,userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,new Guid().ToString())
            };
            var byteArray = Encoding.UTF8.GetBytes("AkdsljafdDDDsjkafhajkadsk");
            var userSymmetricSecurityKey = new SymmetricSecurityKey(byteArray);
            var userSigningCredentials = new SigningCredentials(userSymmetricSecurityKey, SecurityAlgorithms.HmacSha256);


            var userJwtSecurityToken = new JwtSecurityToken(
                issuer:"userAPI",
                audience:"ProductAPI",
                signingCredentials: userSigningCredentials,
                claims:userClaims,
                expires:DateTime.UtcNow.AddMinutes(10)
                );
            var userJwtSecurityTokenHandler = new { token = new JwtSecurityTokenHandler().WriteToken(userJwtSecurityToken) };
            var jsonTokenObject = JsonConvert.SerializeObject(userJwtSecurityTokenHandler);
            return jsonTokenObject;
        }
    }
}
