using ManagementSystem.Application.CQRS.Categories.Queries.Responses;
using ManagementSystem.Common.GlobalResponses.Generics;
using MediatR;

namespace ManagementSystem.Application.CQRS.Categories.Queries.Requests;

public record struct GetByIdCategoryRequest : IRequest<Result<GetByIdCategoryResponse>>
{
    public int Id { get; set; }
}
