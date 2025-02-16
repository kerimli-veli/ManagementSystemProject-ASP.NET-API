using ManagementSystem.Application.CQRS.Queries.Responses;
using ManagementSystem.Common.GlobalResponses.Generics;
using MediatR;

namespace ManagementSystem.Application.CQRS.Queries.Requests;

public record struct GetByIdCategoryRequest : IRequest<Result<GetByIdCategoryResponse>>
{
    public int Id { get; set; }
}
