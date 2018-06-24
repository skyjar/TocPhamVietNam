using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.TocHoPham.ViewModel
{
    public class MenuViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<MenuViewModel> Children { get; set; }

    }
}