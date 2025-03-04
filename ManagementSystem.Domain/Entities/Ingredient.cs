using ManagementSystem.Domain.BaseEntities;

namespace ManagementSystem.Domain.Entities;

public class Ingredient : ProductBaseEntity
{
    public int MinimumCount { get; set; }
    public int MaximumCount { get; set; }
    public int FreeIngredientCount { get; set; }
    public List<int> DepartmentsId { get; set; }
}
