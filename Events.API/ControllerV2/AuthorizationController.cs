using Events.API.Infrastructure.Authentication;
using Events.Application.Users;
using Events.Application.Users.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Events.API.ControllerV2
{

    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        #region Readonly
        private readonly IUserService _userService;
        private readonly IOptions<JWTConfiguration> _options;
        #endregion

        #region ctor
        public AuthorizationController(IUserService userService, IOptions<JWTConfiguration> options)
        {
            _userService = userService;
            _options = options;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Registration
        /// </summary>
        /// <param name="cancellation"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("Register")]
        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task Register([FromBody] UserCreateModel user, CancellationToken cancellation)
        {
            await _userService.RegisterAsync(user, cancellation);
        }

        /// <summary>
        /// Log In
        /// </summary>
        /// <param name="cancellation"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("LogIn")]
        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<string> LogIn(UserLogInModel request, CancellationToken cancellation)
        {

            var result = await _userService.AuthenticateAsync(request, cancellation);

            var roleName = await _userService.GetRoleAsync(result.Id, cancellation);

            return JWTHelper.GenerateSecurityToken(result.UserName, result.Id, roleName, _options);
        }
        #endregion
    }

}
