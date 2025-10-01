using AutoMapper;
using Core.Framework.Contracts.Api;
using Core.Framework.Contracts.Api.Interfaces;
using Core.Framework.Contracts.Shared.Request;
using Core.Framework.Contracts.Shared.Response;
using Core.Framework.Controllers;
using Core.Framework.Messages;
using Core.SharedServices;
using Core.SharedServices.Authentication;
using Core.SharedServices.Exceptions;
using Core.SharedServices.Security.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Questioner.Api.Contracts.Messages;
using Questioner.Data.Entities;
using System.Net;

namespace Questioner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Obsolete("Modelo de Controller Deprecado, ya no implementar con try/catch, desarrollar teniendo en cuenta el ErrorHandlingMiddleware o los Wrappers para evitar los Exceptions en controller")]
    public class UsersController
        (
        ILogger<UsersController> logger,
        IGenericService<User> service,
        IMapper mapper,
        IAuthenticationService<User> authService, ITokenService<User> tokenService
        ) : BaseController(logger, mapper)
    {
        private readonly IGenericService<User> _service = service;
        private readonly IAuthenticationService<User> _authService = authService;
        private readonly ITokenService<User> _tokenService = tokenService;

        [HttpGet]
        public async Task<ActionResult<IApiResult<IEnumerable<UserResponse>>>> GetAll()
        {
            IApiResult<IEnumerable<UserResponse>> result = new ApiResult<IEnumerable<UserResponse>>();
            _log.LogInformation(message: Entity.USER_GETALL);

            try
            {
                var users = await _service.GetAllAsync();
                result.Data = _mapper.Map<IEnumerable<UserResponse>>(users);

                if (result.Data.Any())
                    result.Set(HandleSuccess(Entity.USER_GETALL_OK, result.Data.Count(), HttpStatusCode.OK));
                else
                    result.Set(HandleSuccess(Entity.USER_NOFOUND_OK, HttpStatusCode.NoContent));
            }
            catch (BusinessException ex)
            {
                result.Set(HandleServiceException(ex));
            }
            catch (Exception ex)
            {
                result.Set(HandleException(ex, HttpStatusCode.InternalServerError, Domain.ERROR));
            }

            return ResponseApi(result);
        }


        [HttpGet("by-wrapper")]
        public async Task<ActionResult<IApiResult<IEnumerable<UserResponse>>>> GetAllByWrapper()
        {
            return await HandleRequestAsync(async () =>
            {
                IApiResult<IEnumerable<UserResponse>> result = new ApiResult<IEnumerable<UserResponse>>();

                var users = await _service.GetAllAsync();
                result.Data = _mapper.Map<IEnumerable<UserResponse>>(users);

                if (result.Data.Any())
                    result.Set(HandleSuccess(Entity.USER_GETALL_OK, result.Data.Count(), HttpStatusCode.OK));
                else
                    result.Set(HandleSuccess(Entity.USER_NOFOUND_OK, HttpStatusCode.NoContent));

                return result;
            });
        }

        [HttpGet("by-wrapper/{id}")]
        public async Task<ActionResult<IApiResult<UserResponse>>> GetAllByWrapper([FromRoute] Guid id)
        {
            return await HandleRequestAsync(async () =>
            {
                IApiResult<UserResponse> result = new ApiResult<UserResponse>();

                var user = await _service.GetByIdAsync(id);

                if (user is not null)
                {
                    result.Data = _mapper.Map<UserResponse>(user);
                    result.Set(HandleSuccess(Entity.USER_GETALL_OK, result.Data.Id, HttpStatusCode.OK));
                }
                else
                    result.Set(HandleSuccess(Entity.USER_NOFOUND_OK, HttpStatusCode.NoContent));

                return result;
            });
        }

        [HttpGet("by-middleware")]
        public async Task<ActionResult<IApiResult<IEnumerable<UserResponse>>>> GetAllByMiddleware()
        {
            IApiResult<IEnumerable<UserResponse>> result = new ApiResult<IEnumerable<UserResponse>>();

            var users = await _service.GetAllAsync();
            result.Data = _mapper.Map<IEnumerable<UserResponse>>(users);

            if (result.Data.Any())
                result.Set(HandleSuccess(Entity.USER_GETALL_OK, result.Data.Count(), HttpStatusCode.OK));
            else
                result.Set(HandleSuccess(Entity.USER_NOFOUND_OK, HttpStatusCode.NoContent));

            return ResponseApi(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<IApiResult>> SaveUser([FromBody] UserRegisterRequest dto)
        {
            IApiResult result = new ApiResult();

            User? entity = _mapper.Map<User>(dto);

            if (entity == null)
                return ResponseApi(new ApiResult(Entity.ERROR_CREATE_USER, HttpStatusCode.BadRequest));

            await _authService.RegisterAsync(entity, dto.Password);

            result.Set(HandleSuccess(Entity.USER_REGISTRING_OK, dto.Email));

            return ResponseApi(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ILoginResult<LoginResponse>>> Login([FromServices] ITokenService<User> _tokenService, [FromBody] LoginRequest dto)
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
    }
}