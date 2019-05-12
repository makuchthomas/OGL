using OGL.Infrastructure.Commands;
using OGL.Infrastructure.Commands.Advertisements;
using OGL.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OGL.Infrastructure.Handlers.Advertisements
{
    public class UpdateAvertisementHandler : ICommandHandler<UpdateAvertisement>
    {
        private readonly IAdvertisementService _advertisementService;
        public UpdateAvertisementHandler(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        public async Task HandleAsync(UpdateAvertisement command)
        {
            await Task.CompletedTask;
        }
    }
}
