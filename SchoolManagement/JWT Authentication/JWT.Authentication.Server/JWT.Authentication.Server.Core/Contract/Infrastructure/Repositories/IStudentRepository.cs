using JWT.Authentication.Server.Core.Entities;

namespace JWT.Authentication.Server.Core.Contract.Infrastructure.Repositories
{
    public interface IStudentRepository
    {
        Task<bool> RegisterStudent(Student student);
        Task<bool> ValidateStudent(string email, string password);
    }
}
