using OGL.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OGL.Core.Repositories
{
    public interface ICategoryRepository : IRepository
    {
        Task<Category> GetAsync(Guid id);
        Task<Category> GetAsync(string name);
        Task<IEnumerable<Category>> GetAllAsync();
        Task AddAsync(Category category);
        Task DeleteAsync(Guid id);
        Task UpdateAsync(Category category);
    }
}
