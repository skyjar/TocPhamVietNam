namespace UI.TocHoPham.ViewModel
{
    using PagedList;
    using System.Collections.Generic;

    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
    }

    public class CategoryHomeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<PostViewModel> Posts { get; set; }
    }

    public class CategoryPagedViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IPagedList<PostViewModel> Posts { get; set; }
    }
    
}