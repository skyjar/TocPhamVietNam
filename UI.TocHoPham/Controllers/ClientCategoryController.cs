using Core.ApplicationServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.TocHoPham.Controllers
{
    public class ClientCategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;

        public ClientCategoryController(ICategoryService categoryService, IPostService postService)
        {
            _categoryService = categoryService;
            _postService = postService;
        }

        // GET: Category
        public ActionResult Index(int categoryId, int? pageIndex)
        {
            var model = _categoryService.Get(_ => _.Id == categoryId, _ => _.Posts, _ => _.Posts.Select(__ => __.Comments));
            return View(ModelMapper.ConvertToCHViewModel(model));
        }
    }
}