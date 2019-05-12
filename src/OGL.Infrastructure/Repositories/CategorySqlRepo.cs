using Microsoft.EntityFrameworkCore;
using OGL.Core.Domain;
using OGL.Core.Repositories;
using OGL.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OGL.Infrastructure.Repositories
{
    /*public class CategorySqlRepo : ICategoryRepository, ISqlRepository
    {
        private readonly OglContext _context;
        public CategorySqlRepo(OglContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        //public async Task DeleteAsync(int id)
        public async Task DeleteAsync(Guid id)
        {
            var category = await GetAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
            => await _context.Categories.ToListAsync();

        //public async Task<Category> GetAsync(int id)
        public async Task<Category> GetAsync(Guid id)
            => await _context.Categories.SingleOrDefaultAsync(x => x.CategoryId == id);

        public async Task<Category> GetAsync(string name)
            => await _context.Categories.SingleOrDefaultAsync(x => x.Name == name);

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }*/
}
