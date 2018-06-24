namespace UI.TocHoPham.Controllers
{
    using System.Web.Mvc;
    using UI.TocHoPham.ViewModel;

    public abstract class BaseController : Controller
    {
        private _ModelMapping _modelMapper;

        public _ModelMapping ModelMapper => _modelMapper ?? (_modelMapper = new _ModelMapping());
    }
}