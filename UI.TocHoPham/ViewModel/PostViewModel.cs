using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.TocHoPham.ViewModel
{
    public class SuggestViewModel
    {
        public ICollection<PostViewModel> PopularNews { get; set; }

        public ICollection<PostViewModel> MostComments { get; set; }

    }

    public class BannerViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CoverPhoto { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
    }

    public class PostViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string Author { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public string CoverPhoto { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; }

        public int NumberComment { get; set; }
    }

    public class PostDetailViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string BodyHtml { get; set; }

        public string Author { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public string CoverPhoto { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; }

        public ICollection<LabelViewModel> Labels { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }


    }

    public class LabelViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class CommentViewModel
    {
        public string Author { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public string Content { get; set; }
    }
}