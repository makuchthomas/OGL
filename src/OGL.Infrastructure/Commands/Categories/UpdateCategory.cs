using System;
using System.Collections.Generic;
using System.Text;

namespace OGL.Infrastructure.Commands.Categories
{
    public class UpdateCategory : ICommand
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}
