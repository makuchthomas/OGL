using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OGL.Infrastructure.Commands;
using OGL.Infrastructure.Services;

namespace OGL.Api.Controllers
{
    [Route("[controller]")]
    public abstract class ApiControllerBase : Controller
    {

        protected readonly ICommandDispatcher CommandDispatcher;
        protected ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;
        }

    }
}