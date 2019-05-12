using System;
using System.Collections.Generic;
using System.Text;

namespace OGL.Infrastructure.Commands.Categories
{
    public class DeleteCategory : ICommand
    {
        public Guid CategoryId { get; set; }
    }
}
