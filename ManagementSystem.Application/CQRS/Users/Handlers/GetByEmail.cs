using ManagementSystem.Application.CQRS.Users.ResponsesDtos;
using ManagementSystem.Common.GlobalResponses;
using ManagementSystem.Common.GlobalResponses.Generics;
using ManagementSystem.Repository.Common;
using MediatR;
using static ManagementSystem.Application.CQRS.Users.Handlers.Register;

namespace ManagementSystem.Application.CQRS.Users.Handlers;
public class GetByEmail
{
    public class Query : IRequest<Result<GetByEmailDto>>
    {
        public string Email { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<GetByEmailDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetByEmailDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var currentUser = await _unitOfWork.UserRepository.GetByEmailAsync(request.Email);
            if (currentUser == null)
            {
                return new Result<GetByEmailDto>() { Errors = ["User tapilmadi"], IsSuccess = true };

            }

            GetByEmailDto user = new()
            {
                Id = currentUser.Id,
                Email = currentUser.Email,
                Surname = currentUser.Surname,
                Name = currentUser.Name,
                Phone = currentUser.Phone,

            };

            return new Result<GetByEmailDto>() { Data = user  , Errors = [] , IsSuccess = true };
        }
    }
}
