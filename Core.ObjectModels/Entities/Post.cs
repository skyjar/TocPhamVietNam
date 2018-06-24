namespace Core.ObjectModels.Entities
{
    using System;
    using System.Collections.Generic;

    public class Post : _BaseEntity
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public string BodyHtml { get; set; }

        public string Author { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public string CoverPhoto { get; set; }

        public bool IsBanner { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<Label> Labels { get; set; }

        public ICollection<Comment> Comments { get; set; }
        
    }
}