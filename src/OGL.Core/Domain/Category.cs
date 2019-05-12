using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OGL.Core.Domain
{
    public class Category
    {
        private ISet<Advertisement> _advertisements = new HashSet<Advertisement>();

        public Guid CategoryId { get; protected set; }
        public string Name { get; protected set; }
        public IEnumerable<Advertisement> Advertisements
        {
            get { return _advertisements; }
            set { _advertisements = new HashSet<Advertisement>(value); }
        }
        protected Category() { }

        public Category(Guid categoryId, string name)
        {
            CategoryId = categoryId;
            SetName(name);
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name can not be empty.");
            }
            Name = name;
        }

    }
}
