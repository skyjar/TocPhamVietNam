namespace UI.TocHoPham.Areas.Admin.ViewModels
{
    using Core.ObjectModels.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class GetPostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public string CategoryName => String.Join(", ", Categories.Select(_ => _.Name));

        public ICollection<Category> Categories { get; set; }
        
    }

    public class AddPostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        [AllowHtml]
        public string BodyHtml { get; set; }

        public string Author { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public string CoverPhoto { get; set; }

        public IEnumerable<int> Categories { get; set; }

        public IEnumerable<string> Labels { get; set; }

        public HttpPostedFileBase PhotoFile { get; set; }
    }

    public class UpdatePostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        [AllowHtml]
        public string BodyHtml { get; set; }

        public string Author { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public string CoverPhoto { get; set; }

        public IEnumerable<int> Categories { get; set; }

        public IEnumerable<string> Labels { get; set; }

        public HttpPostedFileBase PhotoFile { get; set; }
    }

    public class BannerViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public string CoverPhoto { get; set; }

        public string CategoryName => String.Join(", ", Categories.Select(_ => _.Name));

        public ICollection<Category> Categories { get; set; }

        public bool IsBanner { get; set; }
    }
}