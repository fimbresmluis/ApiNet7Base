using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APINETALL.JWT
{
    public class JwtManager 
    {
        public string GenerateJwtToken(string userId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("xyz4owkXW+VCxamVfD2rroyhFgOzi1T/pefYSasE5Ws=")); // TODO: OBTENERLO DEL APPSETTINGS
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "http://localhost:7244",
                audience: "http://localhost:7244",
                claims: new[] { new Claim("userId", userId) },
                expires: DateTime.UtcNow.AddHours(12),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        public bool ValidateJwtToken(string token)
        {            
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "http://localhost:7244",
                ValidAudience = "http://localhost:7244",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("xyz4owkXW+VCxamVfD2rroyhFgOzi1T/pefYSasE5Ws="))
            };

            try
            {
                tokenHandler.ValidateToken(token, validationParameters, out _);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
