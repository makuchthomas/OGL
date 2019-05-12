using OGL.Infrastructure.Commands;
using OGL.Infrastructure.Commands.Categories;
using OGL.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OGL.Infrastructure.Handlers.Categories
{
    public class DeleteCategoryHandler : ICommandHandler<DeleteCategory>
    {
        private readonly ICategoryService _categoryService;

        public DeleteCategoryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task HandleAsync(DeleteCategory command)
        {
            await Task.CompletedTask;
        }
    }
}
