using ChatterBot.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChatterBot.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitchAuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TwitchAuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AccessTokenReceived accessTokenReceived)
        {
            var result = await _mediator.Send(accessTokenReceived);
            if (result)
            {
                return Ok();
            }

            return Problem("Failed to save auth token.");
        }
    }
}