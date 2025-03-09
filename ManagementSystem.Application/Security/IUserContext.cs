namespace ManagementSystem.Application.Security;

public interface IUserContext
{
    public int UserId { get;}
    public int MustGetUserId();
}
