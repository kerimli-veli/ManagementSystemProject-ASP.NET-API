using ManagementSystem.Application.CQRS.Users.ResponsesDtos;
using ManagementSystem.Application.Service;
using ManagementSystem.Common.Exceptions;
using ManagementSystem.Common.GlobalResponses;
using ManagementSystem.Common.GlobalResponses.Generics;
using ManagementSystem.Common.Security;
using ManagementSystem.Domain.Entities;
using ManagementSystem.Repository.Common;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Win32.SafeHandles;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ManagementSystem.Application.CQRS.Users.Handlers;

public class Login
{
    public class LoginRequest : IRequest<Result<LoginResponseDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public sealed class Handler(IUnitOfWork unitOfWork, IConfiguration configuration) : IRequestHandler<LoginRequest, Result<LoginResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IConfiguration _configuration = configuration;

        public async Task<Result<LoginResponseDto>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            User user = await _unitOfWork.UserRepository.GetByEmailAsync(request.Email) ?? throw new BadRequestException("User does not exist");
            var hashedPassword = PasswordHasher.ComputeStringToSha256Hash(request.Password);

            if (user.PasswordHash != hashedPassword)
            {
                throw new BadRequestException("Wrong Password");
            }

            if (user != null && hashedPassword == user.PasswordHash)
            {
                List<Claim> authClaim = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                    new Claim(ClaimTypes.Name , user.Name),
                    new Claim(ClaimTypes.Email, user.Email),

                };

                JwtSecurityToken token = TokenService.CreateToken(authClaim, _configuration);
                string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                string refreshTokenString = TokenService.GenerateRefreshToken();

                RefreshToken refreshToken = new()
                {
                    Token = refreshTokenString,
                    UserId = user.Id,
                    ExpirationDate = DateTime.Now.AddDays(double.Parse(_configuration.GetSection("JWT:RefreshTokenExpirationDays").Value!)),
                };

                await _unitOfWork.RefreshTokenRepository.SaveRefreshToken(refreshToken);
                await _unitOfWork.SaveChangesAsync();

                LoginResponseDto response = new()
                {
                    AccessToken = tokenString,
                    RefreshToken = refreshTokenString
                };

                return new Result<LoginResponseDto> { Data = response };

            }

            return new Result<LoginResponseDto> { Data = null, Errors = ["Something went wrong"], IsSuccess = false };
        }
    }
}
