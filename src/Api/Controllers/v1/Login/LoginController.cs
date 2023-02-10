using Domain.Commands.v1.Login;
using Domain.Commands.v1.User.Create;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1.Login
{
    [ApiController]
    [Route("api/v1/login")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IMediator _mediator;
        public LoginController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] CreateTokenCommand tokenCommand)
        {
            try
            {
                var response = await _mediator.Send(tokenCommand);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
