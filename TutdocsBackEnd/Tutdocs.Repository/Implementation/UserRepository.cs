using Microsoft.EntityFrameworkCore;
using Tutdocs.Data.Context;
using Tutdocs.Domain.Entities;
using Tutdocs.Repository.Interface;

namespace Tutdocs.Repository.Implementation;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Users>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<Users> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task AddAsync(Users user)
    {
        await _context.Users.AddAsync(user);
    }

    public void Update(Users user)
    {
        _context.Users.Update(user);
    }

    public void Delete(Users user)
    {
        _context.Users.Remove(user);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync()) > 0;
    }
}