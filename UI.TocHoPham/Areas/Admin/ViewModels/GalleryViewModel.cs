namespace UI.TocHoPham.Areas.Admin.ViewModels
{
    using Core.ObjectModels.Entities;
    using System;
    using System.Collections.Generic;

    public class GetGalleryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SummaryPhotoUrl { get; set; }

        public int PhotoNumber { get; set; }
    }

    public class UpdateGalleryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class AddGalleryViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}