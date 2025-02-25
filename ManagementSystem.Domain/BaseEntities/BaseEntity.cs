namespace ManagementSystem.Domain.BaseEntities;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public int? DeletedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }

    public BaseEntity()
    {
        CreatedDate = DateTime.Now;
    }
}