namespace ManagementSystem.Application.CQRS.Users.ResponsesDtos;

public class GetByIdDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Surname { get; set; }

}
