namespace ManagementSystem.Application.CQRS.Categories.Queries.Responses;

public record struct GetByIdCategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }

    public DateTime CreatedDate { get; set; }
}
