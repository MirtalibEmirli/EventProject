using EventProject.Application.Abstractions.IHttpContextUser;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace EventProject.Infrastructure.Services.HttpContextUser;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public string GetRole()
    {
        var role = _httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.Role)?.Value;
        if (role == null) throw new UnauthorizedAccessException("User is not authenticated");
        return role;
    }

    public Guid GetUserId()
    {
        var userIdClaim = _httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null) throw new UnauthorizedAccessException("User is not authenticated");
        var userId = Guid.Parse(userIdClaim.Value);
        return userId;
    }
}
