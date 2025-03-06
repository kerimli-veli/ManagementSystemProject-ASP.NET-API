using ManagementSystem.Domain.BaseEntities;
using ManagementSystem.Domain.Enums;

namespace ManagementSystem.Domain.Entities;

public class User : BaseEntity
{
    public string Name {get; set;}
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string Email { get; set;}
    public string PasswordHash { get; set;}
    public UserRoles UserRole { get; set; }


}
