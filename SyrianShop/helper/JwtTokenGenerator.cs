using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SyrianShop.models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SyrianShop.helper
{
    public class JwtTokenGenerator
    {

       
        public static string JwtTokenSigningKey = "12345@543210985556";

        public static string GenerateToken(User user)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenSigningKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
                new Claim("userName", user.Name),
                new Claim("userId", user.Name)

            };

            // Add roles as multiple claims
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            //Create Secrurity token object by giving required parameters

            var header = new JwtHeader(credentials);
            var payload = new JwtPayload(claims);
            var token = new JwtSecurityToken(header, payload);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            
            return jwt_token;
        }
    }
}
