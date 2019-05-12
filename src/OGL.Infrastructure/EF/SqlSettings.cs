using System;
using System.Collections.Generic;
using System.Text;

namespace OGL.Infrastructure.EF
{
    public class SqlSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public bool InMemory { get; set; }
    }
}
