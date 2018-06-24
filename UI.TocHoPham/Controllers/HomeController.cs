using Core.ApplicationServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.TocHoPham.ViewModel;

namespace UI.TocHoPham.Controllers
{
    public class HomeController : BaseController 
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly IAboutUsService _aboutUsService;

        public HomeController(IPostService postService, ICategoryService categoryService, IAboutUsService aboutUsService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _aboutUsService = aboutUsService;
        }

        // GET: Home
        public ActionResult Index()
        {
            var list = _categoryService.GetPublished();
            list.ToList().ForEach(_ => { _.Posts = _postService.GetPostByCategory(_.Id).Take(5).ToList(); });
            return View(ModelMapper.ConvertToCHViewModel(list));
        }



        #region Partial View

        public ActionResult _Menu()
        {
            return PartialView(ModelMapper.ConvertToViewModel(_categoryService.GetAllParent()));
        }

        public ActionResult _MenuMobile()
        {
            return PartialView(ModelMapper.ConvertToViewModel(_categoryService.GetAllParent()));
        }

        public ActionResult _AboutUs()
        {
            return PartialView(_aboutUsService.Get());
        }

        public ActionResult _SuggestPost()
        {
            SuggestViewModel model = new SuggestViewModel();

            model.PopularNews = ModelMapper.ConvertToViewModel(_postService.GetAll(_ => _.Categories, _ => _.Comments).Take(4));

            model.MostComments = ModelMapper.ConvertToViewModel(
                _postService.GetAll(_ => _.Categories, _ => _.Comments).OrderByDescending(_ => _.Comments.Count).Take(4));

            return PartialView(model);
        }

        public ActionResult _Banner()
        {
            return PartialView(ModelMapper.ConvertToBannerViewModel(_postService.GetAllBanner()));
        }

        #endregion
    }
}