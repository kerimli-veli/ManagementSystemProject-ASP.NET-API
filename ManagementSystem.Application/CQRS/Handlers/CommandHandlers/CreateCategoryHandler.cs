using ManagementSystem.Application.CQRS.Commands.Requests;
using ManagementSystem.Application.CQRS.Commands.Responses;
using ManagementSystem.Common.Exceptions;
using ManagementSystem.Common.GlobalResponses.Generics;
using ManagementSystem.Domain.Entities;
using ManagementSystem.Repository.Common;
using MediatR;

namespace ManagementSystem.Application.CQRS.Handlers.CommandHandlers;

public class CreateCategoryHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCategoryRequest, Result<CreateCategoryResponse>>
{
    private readonly IUnitOfWork _unitwork = unitOfWork;
    public async Task<Result<CreateCategoryResponse>> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        Category category = new()
        {
            Name = request.Name
        };

        if(string.IsNullOrEmpty(request.Name))
        {
            //return new Result<CreateCategoryResponse>
            //{
            //    Data = null,
            //    Errors = ["Category Name cannot be empty"],
            //    IsSuccess = false
            //};s

            throw new BadRequestException("Name cannot be null");

        }

       await _unitwork.CategoryRepository.AddAsync(category);

        CreateCategoryResponse response = new()
        {
            Id = category.Id,
            Name = category.Name,
        };

        return new Result<CreateCategoryResponse>
        {
            Data = response,
            Errors = [],
            IsSuccess = true
        };
    }
}

