namespace Core.ObjectModels.Entities
{
    using System.Collections.Generic;

    public class Label : _BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}