using OGL.Infrastructure.Commands;
using OGL.Infrastructure.Commands.Advertisements;
using OGL.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OGL.Infrastructure.Handlers.Advertisements
{
    public class DeleteAvertisementHandler : ICommandHandler<DeleteAvertisement>
    {
        private readonly IAdvertisementService _advertisementService;

        public DeleteAvertisementHandler(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        public async Task HandleAsync(DeleteAvertisement command)
        {
            await _advertisementService.DeleteAsync(command.UserId, command.Title);
        }
    }
}
