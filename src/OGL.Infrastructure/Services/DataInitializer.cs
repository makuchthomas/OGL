using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGL.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        private readonly IAdvertisementService _advertisementService;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public DataInitializer(IUserService userService, ICategoryService categoryService, IAdvertisementService advertisementService)
        {
            _userService = userService;
            _categoryService = categoryService;
            _advertisementService = advertisementService;
        }
        public async Task SeedData()
        {
            var users = await _userService.BrowseAsync();
            if (users.Any())
            {
                Logger.Trace("Data was already initialized.");

                return;
            }
            Logger.Trace("Initializing data..");
            var tasks = new List<Task>();
            for (int i = 1; i < 11; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"user{i}";
                var email = $"user{i}@email.com";
                await _userService.RegisterAsync(userId, email, username, "password", "user");
                Logger.Trace($"Adding user: {username}");

            }

            for (int i = 1; i < 5; i++)
            {
                var userId = Guid.NewGuid();
                var username = $"adminuser{i}";
                var email = $"adminuser{i}@email.com";
                await _userService.RegisterAsync(userId, email, username, "password", "admin");
                Logger.Trace($"Adding admin: {username}");

                var categoryId = Guid.NewGuid();
                var name = $"cate{i}";
                await _categoryService.RegisterAsync(categoryId, name);
                Logger.Trace($"Adding category: {categoryId}");

                await _advertisementService.AddAsync(Guid.NewGuid(), $"title{i}", $"content{i}", userId, categoryId);
                Logger.Trace($"Adding advertisement to: {categoryId}");
            }
        }
    }
}
