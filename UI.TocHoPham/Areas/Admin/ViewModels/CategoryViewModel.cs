using System.Collections.Generic;

namespace UI.TocHoPham.Areas.Admin.ViewModels
{
    public class CreateCategoryViewModel
    {
        public string Name { get; set; }

        public int? ParentId { get; set; }
    }

    public class GetCategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }

        public string CategoryPath { get; set; }

        public ICollection<GetCategoryViewModel> Childrens { get; set; }
    }

    public class UpdateCategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}