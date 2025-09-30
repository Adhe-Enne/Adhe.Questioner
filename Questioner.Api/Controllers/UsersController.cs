using Core.Framework.ApiContracts;
using Core.Framework.Controllers;
using Core.SharedServices;
using Microsoft.AspNetCore.Mvc;
using Questioner.Data.Entities;

namespace Questioner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(ILogger<UsersController> logger,
        IGenericService<User> service
        ) : BaseController(logger)
    {
        private readonly IGenericService<User> _service = service;

        [HttpGet]
        public async Task<ActionResult<ApiResult<IEnumerable<User>>>> GetAll()
        {
            IApiResult<IEnumerable<User>> result = new ApiResult<IEnumerable<User>>();
            var users = await _service.GetAllAsync();
            result.Data = users.ToList();

            return ResponseApi(result);
        }
    }
}
