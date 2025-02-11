using ManagementSystem.Repository.Repositories;

namespace ManagementSystem.Repository.Common;

public interface IUnitOfWork
{
    public ICategoryRepository CategoryRepository { get;}
}