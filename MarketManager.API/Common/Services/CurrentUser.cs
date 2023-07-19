using MarketManager.Application.Common.Interfaces;
using System.Security.Claims;

namespace MarketManager.API.Common.Services;

public class CurrentUser:ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        
    }
    public Guid? Id => Guid.Parse(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));
}
