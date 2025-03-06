using Dapper;
using ManagementSystem.DAL.SqlServer.Context;
using ManagementSystem.Domain.Entities;
using ManagementSystem.Repository.Repositories;
using Microsoft.Data.SqlClient;

namespace ManagementSystem.DAL.SqlServer.Infrastructure;

public class SqlProductRepository(string connectionString, AppDbContext context) : BaseSqlRepository(connectionString), IProductRepository
{
    private readonly AppDbContext _context = context;

    public Task AdddAsyncDapper(Product product)
    {

        throw new NotImplementedException();
    }

    public Task AdddAsyncEFCore(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteDapper(int id, int deletedId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteEFCore(int id, int deletedId)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Product> GetAllDapper()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Product> GetAllEFCore()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByAsyncDapper(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetByAsyncEFCore(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdatedDapper(Product product)
    {
        throw new NotImplementedException();
    }

    public void UpdatedEFCore(Product product)
    {
        throw new NotImplementedException();
    }
}
