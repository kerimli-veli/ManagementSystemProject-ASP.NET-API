namespace ManagementSystem.Domain.BaseEntities;

public abstract class ProductBaseEntity : BaseEntity
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Barcode { get; set; }
    public decimal Price { get; set; }
    public bool OpenPrice { get; set; }
    public string Description { get; set; }
    public string ButtonColor { get; set; }
    public string TextColor { get; set; }
    public string InvoiceNumber { get; set; }
}
