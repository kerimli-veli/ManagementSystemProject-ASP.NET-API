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
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        using var transaction = connection.BeginTransaction();

    
        string insertProductQuery = @"
    INSERT INTO Product (Name, Type, Barcode, Price, OpenPrice, Description, ButtonColor, TextColor, InvoiceNumber, CreatedBy, CreatedDate, UpdatedDate, IsDeleted)
    OUTPUT INSERTED.Id
    VALUES (@Name, @Type, @Barcode, @Price, @OpenPrice, @Description, @ButtonColor, @TextColor, @InvoiceNumber, @CreatedBy, GETDATE(), GETDATE(), 0);";

        int productId = await connection.ExecuteScalarAsync<int>(insertProductQuery, product, transaction);

        
        if (product.IngredientsId?.Any() == true)
        {
            string insertIngredientProductQuery = @"
        INSERT INTO IngredientProduct (IngredientId, ProductId)
        VALUES (@IngredientId, @ProductId);";

            foreach (var ingredientId in product.IngredientsId)
            {
                await connection.ExecuteAsync(insertIngredientProductQuery, new { IngredientId = ingredientId, ProductId = productId }, transaction);
            }
        }

        
        if (product.DepartmentsId?.Any() == true)
        {
            string insertDepartmentProductQuery = @"
        INSERT INTO DepartmentProduct (DepartmentId, ProductId)
        VALUES (@DepartmentId, @ProductId);";

            foreach (var departmentId in product.DepartmentsId)
            {
                await connection.ExecuteAsync(insertDepartmentProductQuery, new { DepartmentId = departmentId, ProductId = productId }, transaction);
            }
        }

        
        if (product.AllergenGroupId?.Any() == true)
        {
            string insertAllergenGroupProductQuery = @"
        INSERT INTO AllergenGroupProduct (AllergenGroupId, ProductId)
        VALUES (@AllergenGroupId, @ProductId);";

            foreach (var allergenGroupId in product.AllergenGroupId)
            {
                await connection.ExecuteAsync(insertAllergenGroupProductQuery, new { AllergenGroupId = allergenGroupId, ProductId = productId }, transaction);
            }
        }

        transaction.Commit();

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
