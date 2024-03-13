using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using truckwheels.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.IdentityModel.Tokens.Jwt;

namespace truckwheels.Services
{
    public class TokensService
    {
        public static object GenerateToken(Employee employee)
        {
            var key = Encoding.ASCII.GetBytes(truckwheels.Key.Secret);
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("employeeId", employee.Id.ToString()),

                }),

                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };


            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenConfig);
            var tokenString = tokenHandler.WriteToken(token);

            return new
            {
                token = tokenString
            };
        }
    }
}
