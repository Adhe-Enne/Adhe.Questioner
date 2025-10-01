using AutoMapper;
using Core.Framework.Contracts.Api;
using Core.Framework.Contracts.Api.Interfaces;
using Core.Framework.Contracts.Shared.Request;
using Core.Framework.Contracts.Shared.Response;
using Core.Framework.Controllers;
using Core.SharedServices;
using Core.SharedServices.Authentication;
using Core.SharedServices.Security;
using Core.SharedServices.Security.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Questioner.Api.Contracts.Messages;
using Questioner.Data.Entities;
using System.Net;
using System.Security.Claims;

namespace Questioner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(
        ILogger<AuthController> logger,
        IGenericService<User> service,
        IMapper mapper,
        IAuthenticationService<User> authService, ITokenService<User> tokenService
        ) : BaseController(logger, mapper)
    {
        private readonly IGenericService<User> _service = service;
        private readonly IAuthenticationService<User> _authService = authService;
        private readonly ITokenService<User> _tokenService = tokenService;

        [HttpPost("register")]
        public async Task<ActionResult<IApiResult>> SaveUser([FromBody] UserRegisterRequest dto)
        {
            IApiResult result = new ApiResult();

            User? entity = _mapper.Map<User>(dto);

            if (entity == null)
                return ResponseApi(new ApiResult(Entity.ERROR_CREATE_USER, HttpStatusCode.BadRequest));

            //var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            entity.UserAdded = "OneSelf";

            await _authService.RegisterAsync(entity, dto.Password);

            result.Set(HandleSuccess(Entity.USER_REGISTRING_OK, dto.Email));

            return ResponseApi(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ILoginResult<LoginResponse>>> Login([FromBody] LoginRequest dto)
        {
            ILoginResult<LoginResponse> result = new LoginResult<LoginResponse>();
            _log.LogInformation(FormatMessage(Entity.USER_LOGIN, dto.Email));

            var user = await _authService.AuthenticateAsync(dto.Email, dto.Password);

            if (user == null)
            {
                result.Set(HandleSuccess(Entity.ERROR_INVALID_USER, HttpStatusCode.Unauthorized));
                return ResponseApi(result);
            }

            result.Token = _tokenService.CreateToken(user);
            result.UserData = _mapper.Map<LoginResponse>(user);
            result.Set(HandleSuccess(Entity.USER_LOGIN_OK));

            return ResponseApi(result);
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<ActionResult<IApiResult>> ChangePassword([FromBody] ChangePasswordRequest dto)
        {
            _log.LogInformation(FormatMessage(Entity.PASSWORD_CHANGE, User.FindFirst(ClaimTypes.NameIdentifier)!.Value));

            IApiResult result = new ApiResult();

            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            await _authService.ChangePasswordAsync(userId, dto.CurrentPassword, dto.NewPassword);

            result.Set(HandleSuccess(Entity.PASSWORD_CHANGE_OK));

            return ResponseApi(result);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<ActionResult<IApiResult>> Logout()
        {
            IApiResult result = new ApiResult();
            // For JWT, logout is typically handled on the client side by deleting the token.

            // Optionally, you can implement token blacklisting on the server side if needed.
            result.Set(HandleSuccess(Entity.USER_LOGOUT_OK));
            return ResponseApi(result);
        }
    }
}
