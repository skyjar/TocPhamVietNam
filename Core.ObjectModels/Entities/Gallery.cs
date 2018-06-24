using System;
using System.Collections.Generic;

namespace Core.ObjectModels.Entities
{
    public class Gallery : _BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
    }
}
