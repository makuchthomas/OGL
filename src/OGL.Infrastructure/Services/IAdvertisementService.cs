using OGL.Core.Domain;
using OGL.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OGL.Infrastructure.Services
{
    public interface IAdvertisementService : IService
    {
        Task AddAsync(Guid advertisementId, string title, string content, Guid userId, Guid categoryId);
        Task DeleteAsync(Guid userId, string title);
    }
}
