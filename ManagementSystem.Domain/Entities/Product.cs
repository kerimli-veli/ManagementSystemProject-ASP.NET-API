using ManagementSystem.Domain.BaseEntities;

namespace ManagementSystem.Domain.Entities;

public class Product : ProductBaseEntity
{
    public List<int> IngredientsId { get; set; }

    public List<int> DepartmentsId { get; set; }

    public List<int> AllergenGroupId { get; set; }
}
