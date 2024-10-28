using System.Security.Claims;
using ChatNext.Data;
using Gnarly.Data;

namespace ChatNext.Api.Infrastructure;

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext, IScopeDependency
{
    public Guid? UserId
    {
        get
        {
            var userId = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return userId is null ? null : Guid.Parse(userId);
        }
    }

    public bool IsAuthenticated => httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
}