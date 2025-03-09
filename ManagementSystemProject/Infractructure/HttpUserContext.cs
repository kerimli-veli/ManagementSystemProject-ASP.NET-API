using ManagementSystem.Application.Security;
using System.Security.Claims;

namespace ManagementSystemProject.Infractructure;

public class HttpUserContext : IUserContext
{
    private readonly int? _userId;

    public HttpUserContext(IHttpContextAccessor httpContextAccessor)
    {
        var id = httpContextAccessor.HttpContext?.User.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        _userId = Int32.Parse(id!);
    }

    public int? UserId => _userId;

   

    public int MustGetUserId()
    {
        if (_userId is null)
        {
            throw new InvalidOperationException("User ");
        }

        return _userId.Value;
    }
}
