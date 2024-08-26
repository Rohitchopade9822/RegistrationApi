using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using RegistrationApi.DBModel;
using RegistrationApi.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RegistrationApi.Repository
{
    public class AuthenticationRepository : IAuthenticationServices
    {
        private IConfiguration _config;
        private readonly MyAppDbContext _myAppDbContext;
        public AuthenticationRepository(IConfiguration configuration, MyAppDbContext myAppDbContext)
        {
            _config = configuration;
            _myAppDbContext = myAppDbContext;
            //_userInfoContext = userInfoContext;
        }
        public string GenerateToken(User user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
                );


            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }

        

      
    }
}
