using ManagementSystem.Domain.Entities;

namespace ManagementSystem.Repository.Repositories;

public interface ICategoryRepository
{
    Task AddAsync(Category category);
    void Update(Category category);
    Task<bool> Delete(int id , int deletedBy);
    IQueryable<Category> GetAll();
    Task<Category> GetByIdAsync(int id);
   // Task<IEnumerable<Category>> GetAllInitialDataAsync();
}