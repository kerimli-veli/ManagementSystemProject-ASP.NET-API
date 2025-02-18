using ManagementSystem.DAL.SqlServer.Context;
using ManagementSystem.Domain.Entities;
using ManagementSystem.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.DAL.SqlServer.Infrastructure;

public class SqlUserRepository(AppDbContext context) : IUserRepository
{
    private readonly AppDbContext _context = context;
    public IQueryable<User> GetAll()
    {
        return _context.Users;
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return (await _context.Users.FirstOrDefaultAsync(u => u.Email == email))!;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return (await _context.Users.FirstOrDefaultAsync(u => u.Id == id))!;
    }

    public async Task RegisterAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task Remove(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        user.IsDeleted = true;
        user.DeletedDate = DateTime.Now;
    }

    public void Update(User user)
    {
        user.UpdatedDate = DateTime.Now;
        _context.Update(user);
    }
}
