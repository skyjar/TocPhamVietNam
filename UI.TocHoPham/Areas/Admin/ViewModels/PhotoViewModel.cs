namespace UI.TocHoPham.Areas.Admin.ViewModels
{
    using System.Web;

    public class AddPhotoViewModel
    {
        public string Url { get; set; }

        public int GalleryId { get; set; }

        public string Alternative { get; set; }

        public HttpPostedFileBase PhotoFile { get; set; }
    }
}