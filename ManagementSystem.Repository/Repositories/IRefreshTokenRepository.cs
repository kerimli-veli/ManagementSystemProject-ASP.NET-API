using ManagementSystem.Domain.Entities;

namespace ManagementSystem.Repository.Repositories;

public interface IRefreshTokenRepository
{
    Task<RefreshToken> GetStoredRefreshToken(string refreshToken);
    Task SaveRefreshToken(RefreshToken refreshToken);
}
