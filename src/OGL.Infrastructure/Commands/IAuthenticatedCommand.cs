using System;
using System.Collections.Generic;
using System.Text;

namespace OGL.Infrastructure.Commands
{
    public interface IAuthenticatedCommand : ICommand
    {
        Guid UserId { get; set; }
    }
}
