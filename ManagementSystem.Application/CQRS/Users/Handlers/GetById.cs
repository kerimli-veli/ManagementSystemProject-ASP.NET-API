using ManagementSystem.Application.CQRS.Users.ResponsesDtos;
using ManagementSystem.Common.GlobalResponses;
using ManagementSystem.Common.GlobalResponses.Generics;
using ManagementSystem.Repository.Common;
using MediatR;

namespace ManagementSystem.Application.CQRS.Users.Handlers;

public class GetById
{
    public class Query : IRequest<Result<GetByIdDto>>
    {
        public int Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<GetByIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetByIdDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var currentUser = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
            if (currentUser == null)
            {
                return new Result<GetByIdDto>() { Errors = ["User tapilmadi"], IsSuccess = true };
            }
            GetByIdDto response = new()
            {
                Id = currentUser.Id,
                Name = currentUser.Name,
                Surname = currentUser.Surname,
                Email = currentUser.Email,
                Phone = currentUser.Phone,
            };

            return new Result<GetByIdDto> { Data = response, Errors = [], IsSuccess = true };
        }
    }
}
