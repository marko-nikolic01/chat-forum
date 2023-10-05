using Microsoft.AspNetCore.Mvc;
using Model;
using Model.DTO;
using Services.IService;

namespace API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserAPIController : ControllerBase
    {
        private readonly ISignUpService _signUpService;
        private readonly ISignInService _signInService;
        public UserAPIController(ISignUpService signUpService, ISignInService signInService)
        {
            this._signUpService = signUpService;
            this._signInService = signInService;
        }


        [HttpPost("signup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [Produces("application/json")]
        public ActionResult SignUp([FromBody] SignUpDTO dto)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values.SelectMany(v => v.Errors)
                                             .Select(e => e.ErrorMessage)
                                             .ToList();
                return BadRequest(new { Status = 400, Errors = errorMessages });
            }

            if (_signUpService.IsUsernameOrEmailTaken(dto.Username, dto.Email))
            {
                return Conflict(new { Status = 409, Message = "Username or email is already in use." });
            }

            User user = new User(dto.Email, dto.Username, dto.Password);
            _signUpService.SignUp(user);
            return Ok(new { Status = 200, Message = "Successfully signed up." });
        }


        [HttpPost("signin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        public ActionResult SignIn([FromBody] SignInDTO dto)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values.SelectMany(v => v.Errors)
                                             .Select(e => e.ErrorMessage)
                                             .ToList();
                return BadRequest(new { Status = 400, Errors = errorMessages });
            }

            User user = _signInService.SignIn(dto.EmailOrUsername, dto.Password);
            if (user == null)
            {
                return Unauthorized(new { Status = 401, Message = "Invalid credentials." });
            }

            return Ok(new { Status = 200, Message = "Successfully signed in." });
        }
    }
}
