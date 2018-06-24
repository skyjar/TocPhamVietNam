namespace Core.ObjectModels.Entities
{
    using System;

    public class Comment : _BaseEntity
    {
        public string Author { get; set; }

        public string Content { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}