using ManagementSystem.Application.CQRS.Commands.Responses;
using ManagementSystem.Common.GlobalResponses.Generics;
using MediatR;

namespace ManagementSystem.Application.CQRS.Commands.Requests;

public class CreateCategoryRequest : IRequest<Result<CreateCategoryResponse>>
{
    public string Name { get; set; }
}

