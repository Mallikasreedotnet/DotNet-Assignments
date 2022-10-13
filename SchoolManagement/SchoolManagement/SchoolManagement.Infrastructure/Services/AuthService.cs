using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchoolManagement.Core.Contracts.Infrastructure.Services;
using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure.Extensions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SchoolManagement.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;

        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        public (string password, string passwordSalt) GeneratePassword(string password, string? passwordSalt = null)
        {
            if (passwordSalt == null)
                passwordSalt = GenerateSalt();
            password += passwordSalt;
            password = GenerateHashPassword(password);
            return (password, passwordSalt);
        }

        private string GenerateHashPassword(string password)
        {
            string machineKey = _config["MachineKey"].ToString();
            var hmac = new HMACSHA1()
            {
                Key = machineKey.HexToByte()
            };
            return Convert.ToBase64String(hmac.ComputeHash(password.GetByteArray()));
        }

        private static string GenerateSalt()
        {
            int saltLength = 8;
            byte[] salt = new byte[saltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        public string GenerateToken(UserDto userDetails,string user)
        {

            string result = "";
            if (userDetails is not null && user is not null)
            {
                var claims = new[]
                {
                     new Claim("Fname", userDetails.Fname),
                     new Claim("Lname", userDetails.Lname),
                     new Claim("Email", userDetails.Email),
                     new Claim(ClaimTypes.Role, userDetails.Role)
                };
                result = GetTokenString(claims);
            }
            return result;
        }

        public string GetTokenString(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: signIn);

            var result = new JwtSecurityTokenHandler().WriteToken(token);
            return result;
        }
    }
}
