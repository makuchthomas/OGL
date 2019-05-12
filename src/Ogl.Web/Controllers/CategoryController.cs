using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OGL.Api.Controllers;
using OGL.Infrastructure.Commands;
using OGL.Infrastructure.Commands.Categories;
using OGL.Infrastructure.Services;

namespace Ogl.Web.Controllers
{
    public class CategoryController : ApiControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IAdvertisementService _advertisementService;
        public CategoryController(ICategoryService categoryService, ICommandDispatcher commandDispatcher, IAdvertisementService advertisementService) : base(commandDispatcher)
        {
            _categoryService = categoryService;
            _advertisementService = advertisementService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.BrowseAsync();

            return Json(categories);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetAsync(string name)
        {
            var category = await _categoryService.GetAsync(name);
            if (category == null)
            {
                return NotFound();
            }

            return Json(category);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody]CreateCategory command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created($"category/{command.Name}", null);
        }


        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeleteCategory command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }

        [Authorize]
        [HttpPut]
        [Route("name")]
        public async Task<IActionResult> Put([FromBody]UpdateCategory command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }

    }
}