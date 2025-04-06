using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Graph_QL_Dot_NET_8.REST
{
    public class TokenService
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config)
        {
            _config = config;
        }
        // Token Generation Logic
        public string GenerateJwtToken(string username, string role)
        {
            var securityKey = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
            var claims = new Claim[] {
                        new Claim(ClaimTypes.Name,username),
                };
            var credentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                                             _config["Jwt:Issuer"],
                                             claims,
                                             expires: DateTime.Now.AddMinutes(Convert.ToDouble(10)),
                                             signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
