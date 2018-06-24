namespace Core.ObjectModels.Entities
{
    public class AboutUs : _BaseEntity
    {
        public string Title { get; set; }

        public string BodyHtml { get; set; }

        public string CoverPhoto { get; set; }
    }
}
