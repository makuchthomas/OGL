using Microsoft.Extensions.Caching.Memory;
using OGL.Infrastructure.Commands;
using OGL.Infrastructure.Commands.Users;
using OGL.Infrastructure.Extensions;
using OGL.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OGL.Infrastructure.Handlers.Users
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;

        public LoginHandler(IUserService userService, IJwtHandler jwtHandler, IMemoryCache cache)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
            _cache = cache;
        }

        public async Task HandleAsync(Login command)
        {
            await _userService.LoginAsync(command.Email, command.Password);

            var user = await _userService.GetAsync(command.Email);
            var jwt = _jwtHandler.Createtoken(command.Email, user.Role);
            _cache.SetJwt(command.TokenId, jwt);
        }
    }
}
