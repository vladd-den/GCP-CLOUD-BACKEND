using GCP.BLL.Interfaces;
using GCP.Common.UIModels.RequestModels;
using GCP.Common.UIModels.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GCP.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private const string TAG = "Account";
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("sign-up")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SignUpUserAsync(SignUpRequestModel request)
        {
            Guid id = await _userService.CreateAsync(request);

            if (id == Guid.Empty) return BadRequest();

            return Ok(id);
        }

        [HttpPost("login")]
        [SwaggerOperation(
           Summary = "Login to user account",
           OperationId = "login",
           Tags = new[] { TAG }
        )]
        [ProducesResponseType(typeof(TokenResponseModel), StatusCodes.Status200OK)]
        public async Task<ActionResult> LoginAsync(
            [FromBody] LoginRequestModel user
            )
        {
            TokenResult token = await _userService.LoginAsync(user);

            if (!token.Success) return BadRequest(token.Error);

            return Ok(token.TokenModel);
        }
    }
}
