using ManagementSystem.Application.CQRS.Categories.Commands.Requests;
using ManagementSystem.Application.CQRS.Categories.Commands.Responses;
using ManagementSystem.Application.Security;
using ManagementSystem.Common.Exceptions;
using ManagementSystem.Common.GlobalResponses.Generics;
using ManagementSystem.Domain.Entities;
using ManagementSystem.Repository.Common;
using MediatR;

namespace ManagementSystem.Application.CQRS.Categories.Handlers.CommandHandlers;

public class CreateCategoryHandler(IUnitOfWork unitOfWork ,IUserContext userContext ) : IRequestHandler<CreateCategoryRequest, Result<CreateCategoryResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<CreateCategoryResponse>> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        Category category = new()
        {
            Name = request.Name
        };

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            //return new Result<CreateCategoryResponse>
            //{
            //    Data = null,
            //    Errors = ["Categry Name bosh olmamalidir"],
            //    IsSuccess = false
            //};

            throw new BadRequestException("Name null ola bilmez");
        }

        category

        await _unitOfWork.CategoryRepository.AddAsync(category);

        CreateCategoryResponse response = new()
        {
            Id = category.Id,
            Name = request.Name
        };

        return new Result<CreateCategoryResponse> { Data = response, Errors = [], IsSuccess = true };

    }
}

