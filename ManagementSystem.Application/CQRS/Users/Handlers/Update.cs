using AutoMapper;
using ManagementSystem.Application.CQRS.Users.ResponsesDtos;
using ManagementSystem.Common.Exceptions;
using ManagementSystem.Common.GlobalResponses;
using ManagementSystem.Common.GlobalResponses.Generics;
using ManagementSystem.Repository.Common;
using MediatR;

namespace ManagementSystem.Application.CQRS.Users.Handlers;

public class Update
{

    public record struct Command : IRequest<Result<UpdateDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }

    public sealed class Handler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<Command, Result<UpdateDto>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<UpdateDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var currentUser = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
            if (currentUser == null) throw new BadRequestException($"User does not exist with id : {request.Id}");

            currentUser.Name = request.Name;
            currentUser.Surname = request.Surname;
            currentUser.Email = request.Email;
            currentUser.Phone = request.Phone;
            currentUser.UpdatedBy = 1;


            _unitOfWork.UserRepository.Update(currentUser);

            var response = _mapper.Map<UpdateDto>(currentUser);
            return new Result<UpdateDto>
            {
                Data = response,
                Errors = [],
                IsSuccess = true,
            };
        }
    }
}
