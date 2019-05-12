using OGL.Core.Domain;
using OGL.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGL.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private static ISet<Category> _categories = new HashSet<Category>();
        /*private static ISet<Category> _categories = new HashSet<Category> {
            //new Category(Guid.NewGuid(), "vegetables"),
            //new Category(Guid.NewGuid(), "fruits")
            new Category(1, "vegetables"),
            new Category(2, "fruits")
        };*/

        public async Task AddAsync(Category category)
        {
            _categories.Add(category);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await GetAsync(id);
            _categories.Remove(category);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
            => await Task.FromResult(_categories);

        public async Task<Category> GetAsync(Guid id)
            => await Task.FromResult(_categories.SingleOrDefault(x => x.CategoryId == id));

        public async Task<Category> GetAsync(string name)
            => await Task.FromResult(_categories.SingleOrDefault(x => x.Name == name));

        public async Task UpdateAsync(Category category)
        {
            await Task.CompletedTask;
        }
    }
}
