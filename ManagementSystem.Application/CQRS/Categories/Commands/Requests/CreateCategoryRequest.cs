using ManagementSystem.Application.CQRS.Categories.Commands.Responses;
using ManagementSystem.Application.CQRS.Categories.Queries.Responses;
using ManagementSystem.Common.GlobalResponses.Generics;
using MediatR;



namespace ManagementSystem.Application.CQRS.Categories.Commands.Requests;

public class CreateCategoryRequest : IRequest<Result<CreateCategoryResponse>>
{
    public string Name { get; set; }
}

