using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mukhametshin_Test_Aviakod.Dto.Common;
using Mukhametshin_Test_Aviakod.Dto.Login;
using Mukhametshin_Test_Aviakod.UseCases.Login.Commands.LoginUser;
using Mukhametshin_Test_Aviakod.UseCases.Login.Commands.RegisterUser;

namespace Mukhametshin_Test_Aviakod.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<SimpleDto<Guid>> Register([FromBody] LoginDto dto)
    {
        var userId = await _mediator.Send(new RegisterUser.Command(dto.Username, dto.Password));
        return new SimpleDto<Guid>(userId);
    }

    [HttpPost("login")]
    public async Task<ActionResult<SimpleDto<string>>> Login([FromBody] LoginDto dto)
    {
        var result = await _mediator.Send(new LoginUser.Command(dto.Username, dto.Password));
        if (result is null)
        {
            return Unauthorized();
        }
        
        return new SimpleDto<string>(result);
    }
}