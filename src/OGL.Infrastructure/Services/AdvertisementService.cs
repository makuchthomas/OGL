using AutoMapper;
using OGL.Core.Domain;
using OGL.Core.Repositories;
using OGL.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGL.Infrastructure.Services
{
    class AdvertisementService : IAdvertisementService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        public AdvertisementService(IUserRepository userRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task AddAsync(Guid advertisementId, string title, string content, Guid userId, Guid categoryId)
        {
            var user = await _userRepository.GetAsync(userId);
            if (user == null)
            {
                throw new Exception($"User with id: '{userId}' was not found.");
            }
            var category = await _categoryRepository.GetAsync(categoryId);
            if (category == null)
            {
                throw new Exception($"Category with id: '{categoryId}' was not found.");
            }
            //category.AddAdvertisement(advertisementId, title, content, userId, categoryId);
            user.AddAdvertisement(advertisementId, title, content, userId, categoryId);
        }

        public async Task DeleteAsync(Guid userId, string title)
        {
            var adv = await _userRepository.GetAsync(userId);
            //var category = await _categoryRepository.GetAsync(userId);
            adv.DeleteAdvertisement(title);
            //await _categoryRepository.UpdateAsync(category);
            await _userRepository.UpdateAsync(adv);
        }

    }
}
