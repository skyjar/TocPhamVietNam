namespace UI.TocHoPham.Areas.Admin.ViewModels
{
    using System.Web;
    using System.Web.Mvc;

    public class AboutUsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [AllowHtml]
        public string BodyHtml { get; set; }

        public string CoverPhoto { get; set; }

        public HttpPostedFileBase PhotoFile { get; set; }
    }
}