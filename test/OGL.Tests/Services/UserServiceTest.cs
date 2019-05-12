using AutoMapper;
using Moq;
using OGL.Core.Domain;
using OGL.Core.Repositories;
using OGL.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OGL.Tests.Services
{
    public class UserServiceTest
    {
        [Fact]
        public async Task Register_async_should_invoke_add_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encrypterMock = new Mock<IEncrypter>();
            encrypterMock.Setup(x => x.GetSalt(It.IsAny<string>())).Returns("hash");
            encrypterMock.Setup(x => x.GetHash(It.IsAny<string>(), It.IsAny<string>())).Returns("salt");

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object, encrypterMock.Object);
            await userService.RegisterAsync(Guid.NewGuid(),"user15@email.com", "user5", "user5", "user");

            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task When_calling_get_async_and_user_exists_it_should_invoke_user_repository_get_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encrypterMock = new Mock<IEncrypter>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object, encrypterMock.Object);
            await userService.GetAsync("user1@email.com");
            var user = new User(Guid.NewGuid(), "user1@email.com", "user1", "secret", "user", "salt", "hash");
            //userRepositoryMock.Setup(x => x.GetAsync("user1@email.com"), );
            userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(user);
            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task When_calling_get_async_and_user_does_not_exist_it_should_invoke_user_repository_get_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encrypterMock = new Mock<IEncrypter>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object, encrypterMock.Object);
            await userService.GetAsync("user1@email.com");
            var user = new User(Guid.NewGuid(), "user1@gmail.com", "user1", "secret", "user", "salt", "hash");
            userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(() => null);
            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task When_we_take_user_email_shoud_login()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            var encrypterMock = new Mock<IEncrypter>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object, encrypterMock.Object);
            await userService.GetAsync("user1@email.com");
            var user = new User(Guid.NewGuid(), "user1@email.com", "user1", "secret", "user", "salt", "hash");
           // await userService.LoginAsync("user1@email.com", "secret");
            //await userService.GetAsync("user1@email.com");
            //var user = new User("user1@gmail.com", "user1", "secret", "user", "salt", "hash");
            //userRepositoryMock.Setup(x => x.Equals(It.IsAny<string>())).ReturnsAsync(() => null);
            //userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(() => null);
           // userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
        }
    }
}
