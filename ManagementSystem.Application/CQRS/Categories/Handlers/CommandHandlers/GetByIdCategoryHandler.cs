using ManagementSystem.Application.CQRS.Categories.Queries.Requests;
using ManagementSystem.Application.CQRS.Categories.Queries.Responses;
using ManagementSystem.Common.Exceptions;
using ManagementSystem.Common.GlobalResponses.Generics;
using ManagementSystem.Domain.Entities;
using ManagementSystem.Repository.Common;
using MediatR;

namespace ManagementSystem.Application.CQRS.Categories.Handlers.CommandHandlers;

public sealed class GetByIdCategoryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetByIdCategoryRequest, Result<GetByIdCategoryResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<GetByIdCategoryResponse>> Handle(GetByIdCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
        if (category == null)
            throw new NotFoundException(typeof(Category), request.Id);
        GetByIdCategoryResponse response = new()
        {
            Id = category.Id,
            Name = category.Name,
            CreatedDate = category.CreatedDate
        };

        return new Result<GetByIdCategoryResponse> { Data = response, Errors = [], IsSuccess = true };
    }
}

