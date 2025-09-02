using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mukhametshin_Test_Aviakod.Controllers.Base;

[ApiController]
[Authorize]
public abstract class BaseController : ControllerBase
{
    private Guid? _userId;
    protected Guid UserId => _userId ??= GetUserId();

    private Guid GetUserId()
    {
        return Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId) 
            ? userId 
            : throw new UnauthorizedAccessException();
    }
}