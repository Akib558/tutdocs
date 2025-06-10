using Tutdocs.Domain.Entities;

namespace Tutdocs.Service.Interface;

public interface IUserService
{
    Task<IEnumerable<Users>> GetAllUsersAsync();
    Task<Users> GetUserByIdAsync(int id);
    Task<bool> CreateUserAsync(Users user);
    Task<bool> UpdateUserAsync(Users user);
    Task<bool> DeleteUserAsync(int id);
}