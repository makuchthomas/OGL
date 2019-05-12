using AutoMapper;
using Moq;
using OGL.Core.Repositories;
using OGL.Infrastructure.Services;
using OGL.Infrastructure.Commands.Categories;
using OGL.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using OGL.Api;
using OGL.Core.Domain;

namespace OGL.Tests.Services
{
    public class CategoryServiceTest
    {
        [Fact]
        public async Task Register_async_should_invoke_add_async_on_repository()
        {
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            var mapperMock = new Mock<IMapper>();

            var categoryService = new CategoryService(categoryRepositoryMock.Object, mapperMock.Object);
            await categoryService.RegisterAsync(Guid.NewGuid(), "newCategory");

            categoryRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Category>()), Times.Once);
        }

        [Fact]
        public async Task When_calling_get_async_and_category_exists_it_should_invoke_category_repository_get_async()
        {
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            var mapperMock = new Mock<IMapper>();

            var categoryService = new CategoryService(categoryRepositoryMock.Object, mapperMock.Object);
            await categoryService.GetAsync("cate1");
            var category = new Category(Guid.NewGuid(), "cate1");
            
            categoryRepositoryMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(category);
            categoryRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task When_calling_get_async_and_category_does_not_exist_it_should_invoke_category_repository_get_async()
        {
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            var mapperMock = new Mock<IMapper>();

            var categoryService = new CategoryService(categoryRepositoryMock.Object, mapperMock.Object);
            await categoryService.GetAsync("cate1");
            var category = new Category(Guid.NewGuid(), "newCategory");
            categoryRepositoryMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(() => null);
            categoryRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
        }

    }
}
