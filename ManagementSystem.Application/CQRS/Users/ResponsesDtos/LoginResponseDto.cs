namespace ManagementSystem.Application.CQRS.Users.ResponsesDtos;

public class LoginResponseDto
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}
