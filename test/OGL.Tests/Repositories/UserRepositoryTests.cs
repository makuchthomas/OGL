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
    public class UserRepositoryTests
    {
        [Fact]
        public async Task When_adding_new_user_it_should_be_added_correctly_to_the_list()
        {
            //Arrange
            var user = new User(Guid.NewGuid(), "user100@gmail.com", "user1", "secret", "user", "salt", "hash");
            IUserRepository repository = new UserRepository();

            //Act
            await repository.AddAsync(user);

            //Assert
            var existingUserId = await repository.GetAsync(user.UserId);
            var existingEmail = await repository.GetAsync(user.Email);
            Assert.Equal(user, existingUserId);
            Assert.Equal(user, existingEmail);
        }

        [Fact]
        public async Task When_removing_user_it_should_be_correctly_removed()
        {
            //Arrange
            var user = new User(Guid.NewGuid(), "user100@gmail.com", "user1", "secret", "user", "salt", "hash");
            IUserRepository repository = new UserRepository();
            await repository.GetAsync("user100@email.com");

            //Act
            await repository.RemoveAsync(user.UserId);
            var userNew = await repository.GetAsync(user.UserId);

            //Assert
            //Assert.DoesNotContain(user.UserId);
            Assert.Null(userNew);
            //var existingUserId = await repository.GetAsync(user.UserId);
            //var existingEmail = await repository.GetAsync(user.Email);
            //Assert.Equal(user, existingUserId);
            // Assert.Equal(user, existingEmail);
        }


    }
}
