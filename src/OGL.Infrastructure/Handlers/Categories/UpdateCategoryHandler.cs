using OGL.Infrastructure.Commands;
using OGL.Infrastructure.Commands.Categories;
using OGL.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OGL.Infrastructure.Handlers.Categories
{
    public class UpdateCategoryHandler : ICommandHandler<UpdateCategory>
    {
        private readonly ICategoryService _categoryService;
        public UpdateCategoryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task HandleAsync(UpdateCategory command)
        {
            await _categoryService.GetAsync(command.Name);
            //await _categoryService.GetAsync(command.CategoryId);
        }
    }
}
