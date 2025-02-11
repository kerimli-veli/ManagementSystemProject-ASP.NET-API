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


    public ICategoryRepository CategoryRepository => _categoryRepository ?? new SqlCategoryRepository(_connectionString , _context);
}