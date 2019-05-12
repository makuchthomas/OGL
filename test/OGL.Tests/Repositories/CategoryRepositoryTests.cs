using OGL.Core.Domain;
using OGL.Core.Repositories;
using OGL.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OGL.Tests.Repositories
{
    public class CategoryRepositoryTests
    {
        [Fact]
        public async Task When_adding_new_category_it_should_be_added_correctly_to_the_list()
        {
            //Arrange
            var category = new Category(Guid.NewGuid(), "fruits");
            ICategoryRepository repository = new CategoryRepository();

            //Act
            await repository.AddAsync(category);

            //Assert
            var existingCategoryId = await repository.GetAsync(category.CategoryId);
            var existingName = await repository.GetAsync(category.Name);
            Assert.Equal(category, existingCategoryId);
            Assert.Equal(category, existingName);
        }

        [Fact]
        public async Task When_removing_category_it_should_be_correctly_removed()
        {
            //Arrange
            var category = new Category(Guid.NewGuid(), "fruits");
            ICategoryRepository repository = new CategoryRepository();
            await repository.AddAsync(category);

            //Act
            var getCategory = await repository.GetAsync("fruits");
            await repository.DeleteAsync(getCategory.CategoryId);
            var categoryNew = await repository.GetAsync(getCategory.Name);

            //Assert
            Assert.Null(categoryNew);
        }
    }
}
