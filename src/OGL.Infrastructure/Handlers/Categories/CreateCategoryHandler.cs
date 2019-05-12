using OGL.Infrastructure.Commands;
using OGL.Infrastructure.Commands.Categories;
using OGL.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OGL.Infrastructure.Handlers.Categories
{
    public class CreateCategoryHandler : ICommandHandler<CreateCategory>
    {
        private readonly ICategoryService _categorySerice;
        public CreateCategoryHandler(ICategoryService categorySerice)
        {
            _categorySerice = categorySerice;
        }
        public async Task HandleAsync(CreateCategory command)
        {
            await _categorySerice.RegisterAsync(Guid.NewGuid(), command.Name);
        }
    }
}
