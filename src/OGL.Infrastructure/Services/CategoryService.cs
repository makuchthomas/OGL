using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NLog;
using OGL.Core.Domain;
using OGL.Core.Repositories;
using OGL.Infrastructure.DTO;

namespace OGL.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public static IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> BrowseAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);
        }

        public async Task DeleteAsync(Guid categoryId)
        {
            var category = await _categoryRepository.GetAsync(categoryId);
            if (category == null)
            {
                throw new Exception($"Category with id {categoryId} does not exists.");
            }
            await _categoryRepository.DeleteAsync(categoryId);
        }

        public async Task<CategoryDetailDto> GetAsync(Guid categoryId)
        {
            var category = await _categoryRepository.GetAsync(categoryId);

            return _mapper.Map<Category, CategoryDetailDto>(category);
        }

        public async Task<CategoryDetailDto> GetAsync(string name)
        {
            var category = await _categoryRepository.GetAsync(name);

            return _mapper.Map<Category, CategoryDetailDto>(category);
        }

        public async Task RegisterAsync(Guid categoryId, string name)
        {
            var category = await _categoryRepository.GetAsync(name);
            if (category != null)
            {
                throw new Exception($"Category with {name} already exists.");
            }
            category = new Category(categoryId, name);
            await _categoryRepository.AddAsync(category);
        }
    }
}
