using OGL.Infrastructure.Commands;
using OGL.Infrastructure.Commands.Advertisements;
using OGL.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OGL.Infrastructure.Handlers.Advertisements
{
    class CreateAvertisementHandler : ICommandHandler<CreateAvertisement>
    {
        private readonly IAdvertisementService _advertisementService;
        public CreateAvertisementHandler(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }
        public async Task HandleAsync(CreateAvertisement command)
        {
            await _advertisementService.AddAsync(Guid.NewGuid(), command.Title, command.Content, command.UserId, command.CategoryId);
        }
    }
}
