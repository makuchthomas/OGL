using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OGL.Api.Controllers;
using OGL.Infrastructure.Commands;
using OGL.Infrastructure.Commands.Advertisements;

namespace Ogl.Web.Controllers
{
    public class AdvertisementController : ApiControllerBase
    {

        public AdvertisementController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateAvertisement command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeleteAvertisement command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }

        [Authorize]
        [HttpPut]
        [Route("content")]
        public async Task<IActionResult> Put([FromBody]UpdateAvertisement command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }

    }
}