using ManagementSystem.DAL.SqlServer.Context;
using ManagementSystem.DAL.SqlServer.Infrastructure;
using ManagementSystem.Repository.Common;
using ManagementSystem.Repository.Repositories;

namespace ManagementSystem.DAL.SqlServer.UnitOfWork.SqlUnitOfWork;

public class SqlUnitOfWork(string connectionString, AppDbContext context) : IUnitOfWork
{

    private readonly string _connectionString = connectionString;
    private readonly AppDbContext _context = context;

    public SqlCategoryRepository _categoryRepository;
    public SqlUserRepository _userRepository;
    public SqlProductRepository _productRepository;


    public ICategoryRepository CategoryRepository => _categoryRepository ?? new SqlCategoryRepository(_connectionString , _context);

    public IUserRepository UserRepository => _userRepository ?? new SqlUserRepository(_context);

    public IProductRepository ProductRepository => _productRepository ?? new SqlProductRepository(_connectionString, _context);


    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}