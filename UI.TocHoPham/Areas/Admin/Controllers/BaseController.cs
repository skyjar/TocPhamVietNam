namespace UI.TocHoPham.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using UI.TocHoPham.Areas.Admin.ViewModels;

    public abstract class BaseController : Controller
    {
        private _ModelMapping _modelMapper;

        public _ModelMapping ModelMapper => _modelMapper ?? (_modelMapper = new _ModelMapping());
    }
}