namespace Core.ObjectModels.Entities
{
    public class Photo : _BaseEntity
    {
        public string Url { get; set; }

        public bool IsBackground { get; set; }

        public bool IsPhoto { get; set; }

        public int GalleryId { get; set; } 

        public Gallery Gallery { get; set; }

        public string Alternative { get; set; }
    }
}
