using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTBasedAuth.Apis.JWT
{
    public class JWTAuthenticationManager
 : IJWTAutheticationManager
    {
        private Dictionary<string, string> _users = new Dictionary<string, string>() { { "test", "pass" }, { "shah", "123" } };
        public string _key;
        public JWTAuthenticationManager(string key)
        {
            _key = key;
        }

        public string Authenticate(string username, string password)
        {
            if(_users.Any(u=>u.Key==username && u.Value == password))
            {
                return "";
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(_key);
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(60),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
        }
    }
}
