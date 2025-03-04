using ManagementSystem.Domain.BaseEntities;

namespace ManagementSystem.Domain.Entities;

public class AllergenGroup : BaseEntity
{
    public string Name { get; set; }
    public string Code { get; set; }
}
