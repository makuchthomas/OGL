using OGL.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OGL.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDetailDto> GetAsync(string email);
        Task<IEnumerable<UserDto>> BrowseAsync();
        Task RegisterAsync(Guid userId, string email, string username, string password, string role);
        Task LoginAsync(string email, string password);
    }
}
