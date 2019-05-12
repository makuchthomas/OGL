using OGL.Core.Domain;
using OGL.Core.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OGL.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>();
        /* private static ISet<User> _users = new HashSet<User>
         {
             new User(Guid.NewGuid(),"user1@email.com", "user1", "user1", "user", "user", "user"),
             new User(Guid.NewGuid(),"user2@email.com", "user2", "user2", "user", "user", "user"),
             new User(Guid.NewGuid(),"user3@email.com", "user3", "user3", "user", "user", "user"),
             new User(Guid.NewGuid(),"user4@email.com", "user4", "user4", "user", "user", "user"),
             new User(Guid.NewGuid(),"user5@email.com", "user5", "user5", "user", "user", "user")
         };*/

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
            => await Task.FromResult(_users);

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_users.SingleOrDefault(x => x.UserId == id));

        public async Task<User> GetAsync(string email)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Email == email));

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }
        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}
