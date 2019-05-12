using Microsoft.EntityFrameworkCore;
using OGL.Core.Domain;
using OGL.Core.Repositories;
using OGL.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGL.Infrastructure.Repositories
{
    /*public class UserSqlRepo : IUserRepository, ISqlRepository
    {
        private readonly OglContext _context;

        public UserSqlRepo(OglContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
            => await _context.Users.ToListAsync();

        public async Task<User> GetAsync(Guid id)
            => await _context.Users.SingleOrDefaultAsync(x => x.UserId == id);

        public async Task<User> GetAsync(string email)
            => await _context.Users.SingleOrDefaultAsync(x => x.Email == email);

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }*/
}
