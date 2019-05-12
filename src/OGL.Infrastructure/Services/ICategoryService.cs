using OGL.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OGL.Infrastructure.Services
{
    public interface ICategoryService : IService
    {
        Task<CategoryDetailDto> GetAsync(Guid categoryId);
        Task<CategoryDetailDto> GetAsync(string name);
        Task<IEnumerable<CategoryDto>> BrowseAsync();
        Task RegisterAsync(Guid categoryId, string name);
        Task DeleteAsync(Guid categoryId);
    }
}
