using Newtonsoft.Json;
using OGL.Infrastructure.Commands.Users;
using OGL.Infrastructure.DTO;
using OGL.Web;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OGL.Tests.Integration.Controllers
{
    public class UsersControllerTests : ControllerTestsBase
    {

        [Fact]
        public async Task Given_valid_email_user_should_exist()
        {
            var email = "user1@email.com";
            var user = await GetUserAsync(email);
            Assert.Equal(user.Email, email);
        }

        [Fact]
        public async Task Given_invalid_email_user_should_not_exist()
        {
            var email = "user1@gmail.com";
            var response = await Client.GetAsync($"users/{email}");
            response.StatusCode.Equals(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Given_unique_email_user_should_be_created()
        {
            var command = new CreateUser
            {
                Email = "test@googlemail.com",
                Username = "testowany",
                Password = "test123",
                Role = "user"
            };
            var payload = GetPayload(command);
            var response = await Client.PostAsync("users", payload);
            //response.StatusCode.CompareTo(HttpStatusCode.Created);
            response.StatusCode.Equals(HttpStatusCode.Created);
            response.Headers.Location.ToString().CompareTo($"users/{command.Email}");

            var user = await GetUserAsync(command.Email);
            Assert.Equal(user.Email, command.Email);
        }

        [Fact]
        public async Task Given_valid_current_and_new_password_it_should_be_changed()
        {
            var command = new ChangeUserPassword
            {
                CurrentPassword = "password",
                NewPassword = "secret"
            };
            var payload = GetPayload(command);
            var response = await Client.PutAsync("users/password", payload);
            response.StatusCode.Equals(HttpStatusCode.NoContent);
        }


        protected async Task<UserDto> GetUserAsync(string email)
        {
            var response = await Client.GetAsync($"users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }
    }
}
