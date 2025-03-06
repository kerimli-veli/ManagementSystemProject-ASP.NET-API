using ManagementSystem.DAL.SqlServer.Context;
using ManagementSystem.Domain.Entities;
using ManagementSystem.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.DAL.SqlServer.Infrastructure;

public class SqlRefreshTokenRepository(AppDbContext context) : IRefreshTokenRepository
{
    private readonly AppDbContext _context = context;

    public async Task<RefreshToken> GetStoredRefreshToken(string refreshToken)
    {
        return (await _context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == refreshToken))!;
    }

    public async Task SaveRefreshToken(RefreshToken refreshToken)
    {
        await _context.RefreshTokens.AddAsync(refreshToken);
    }
}
