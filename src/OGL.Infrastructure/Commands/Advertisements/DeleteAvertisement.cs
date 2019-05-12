using System;
using System.Collections.Generic;
using System.Text;

namespace OGL.Infrastructure.Commands.Advertisements
{
    public class DeleteAvertisement : AuthenticatedCommandBase
    {
        public string Title { get; set; }
    }
}
