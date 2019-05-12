using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OGL.Infrastructure.Commands;
using OGL.Infrastructure.Commands.Users;
using OGL.Infrastructure.Services;
using OGL.Infrastructure.Settings;
using OGL.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using OGL.Infrastructure.DTO;
using OGL.Infrastructure.Extensions;

namespace OGL.Api.Controllers
{

    public class UsersController : ApiControllerBase
    {
        private readonly IJwtHandler _jwtHandler;
        protected readonly IUserService _userService;
        private readonly GeneralSettings _settings;
        private readonly IMemoryCache _cache;
        public UsersController(IUserService userService, GeneralSettings settings, ICommandDispatcher commandDispatcher, IMemoryCache cache, IJwtHandler jwtHandler) : base(commandDispatcher)
        {
            _userService = userService;
            _settings = settings;
            _cache = cache;
            _jwtHandler = jwtHandler;
        }

        [HttpGet]
        [Route("token")]
        public IActionResult GenerateToken()
        {
            var token = _jwtHandler.Createtoken("adminuser1@emai.com", "admin");

            return Json(token);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.BrowseAsync();

            return Json(users);
        }

        //[Authorize]
        [HttpGet("{email}")]
        public async Task<IActionResult> GetAsync(string email)
        {
            var user = await _userService.GetAsync(email);
            if (user == null)
            {
                return NotFound();
            }

            return Json(user);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created($"users/{command.Email}", null);
            //return Created($"users/{command.Email}", new object());
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]Login command)
        {
            command.TokenId = Guid.NewGuid();
            await CommandDispatcher.DispatchAsync(command);
            var jwt = _cache.GetJwt(command.TokenId);

            return Json(jwt);
        }

        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> Put([FromBody]ChangeUserPassword command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }

    }
}
