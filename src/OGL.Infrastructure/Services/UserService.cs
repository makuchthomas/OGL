using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using NLog;
using OGL.Core.Domain;
using OGL.Core.Repositories;
using OGL.Infrastructure.DTO;

namespace OGL.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private static IUserRepository _userRepository;
        public static IMapper _mapper;
        private readonly IEncrypter _encrypter;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public UserService(IUserRepository userRepository, IMapper mapper, IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _encrypter = encrypter;
        }
        public async Task<UserDetailDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);

            return _mapper.Map<User, UserDetailDto>(user);
        }

        public async Task<IEnumerable<UserDto>> BrowseAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if (user == null)
            {
                throw new Exception("Invalid credentials");
            }

            var hash = _encrypter.GetHash(password, user.Salt);
            if (user.Password == hash)
            {
                return;
            }
            throw new Exception("Invalid credentials");
        }

        public async Task RegisterAsync(Guid userId, string email, string username, string password, string role)
        {
            var user = await _userRepository.GetAsync(email);
            if (user != null)
            {
                throw new Exception($"User with: '{email}' already exists.");
            }
            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            user = new User(userId, email, username, password, role, salt, hash);
            await _userRepository.AddAsync(user);
        }
    }
}
