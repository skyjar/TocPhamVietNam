namespace Core.ObjectModels.Entities
{
    using System.Collections.Generic;

    public partial class Category : _BaseEntity
    {
        public string Name { get; set; }

        public int? ParentId { get; set; }

        public string CategoryPath { get; set; }

        public Category Parent { get; set; }

        public ICollection<Category> Childrens { get; set; }

        public ICollection<Post> Posts { get; set; }

        public bool IsPublished { get; set; }
    }

    public partial class Category
    {
        public bool HaveChildrens
            => Childrens?.Count > 0;

        public bool HasParent => ParentId.HasValue;
    }
}
