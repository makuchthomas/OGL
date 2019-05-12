using System;
using System.Collections.Generic;
using System.Text;

namespace OGL.Infrastructure.Commands.Advertisements
{
    public class UpdateAvertisement : AuthenticatedCommandBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
