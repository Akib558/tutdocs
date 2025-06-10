using Tutdocs.Domain.Entities;

namespace Tutdocs.Repository.Interface;


public interface IUserRepository
{
    Task<IEnumerable<Users>> GetAllAsync();
    Task<Users> GetByIdAsync(int id);
    Task AddAsync(Users user);
    void Update(Users user);
    void Delete(Users user);
    Task<bool> SaveChangesAsync();
}