using SchoolManagement.Core.Dtos;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Core.Contracts.Infrastructure.Services
{
    public interface IAuthService
    {
        (string password, string passwordSalt) GeneratePassword(string password, string? passwordSalt = null);
        string GenerateToken(UserDto userDetails,string user);
    }
}

