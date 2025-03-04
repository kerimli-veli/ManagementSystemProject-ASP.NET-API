using ManagementSystem.Domain.Entities;

namespace ManagementSystem.Repository.Repositories;

public interface IProductRepository
{
    Task AdddAsyncDapper(Product product);
    Task AdddAsyncEFCore(Product product);
    void UpdatedDapper(Product product);
    void UpdatedEFCore(Product product);
    Task<bool> DeleteDapper(int id, int deletedId);
    Task<bool> DeleteEFCore(int id, int deletedId);
    IQueryable<Product> GetAllDapper();
    IQueryable<Product> GetAllEFCore();
    Task<Product> GetByAsyncDapper(int id);
    Task<Product> GetByAsyncEFCore(int id);
}
