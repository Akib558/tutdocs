using Tutdocs.Domain.Entities;
using Tutdocs.Repository.Interface;
using Tutdocs.Service.Interface;

namespace Tutdocs.Service.Implementation;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
        
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<Users>> GetAllUsersAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<Users> GetUserByIdAsync(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<bool> CreateUserAsync(Users user)
    {
        await _userRepository.AddAsync(user);
        return await _userRepository.SaveChangesAsync();
    }

    public async Task<bool> UpdateUserAsync(Users user)
    {
        _userRepository.Update(user);
        return await _userRepository.SaveChangesAsync();
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return false;

        _userRepository.Delete(user);
        return await _userRepository.SaveChangesAsync();
    }
}