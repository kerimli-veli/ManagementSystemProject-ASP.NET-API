using ManagementSystem.Application.CQRS.Users.ResponsesDtos;
using ManagementSystem.Common.GlobalResponses;
using ManagementSystem.Common.GlobalResponses.Generics;
using ManagementSystem.Repository.Common;
using MediatR;

namespace ManagementSystem.Application.CQRS.Users.Handlers;

public class GetById
{
    public class Query : IRequest<Result<GetByEmailDto>>
    {
        public int Id { get; set; }
    }

    public class Handler : IRequestHandler<Query Result<GetByIdDto> >
    {
        private readonly IUnitOfWork unitOfWork;

        public Handler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task<Result<GetByIdDto>> Handle(Query result , CancellationToken cancellationToken )
        {
            var currentUser = await _unitwork.UserRepository.GetByIdAsync( result.Id );
            GetByIdDto user = new()
            {
                Id = currentUser.Id,
                Email = currentUser.Email,
                Surname = currentUser.Surname,
                Name = currentUser.Name,
                Phone = currentUser.Phone,

            };

            return new Result<GetByIdDto> { Data = response, Errors = [] , IsSuccess = true };
        } 

    }

}
