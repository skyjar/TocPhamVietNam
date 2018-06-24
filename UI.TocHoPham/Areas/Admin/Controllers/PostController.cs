using Core.ApplicationServices.Services;
using Core.ObjectModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.TocHoPham.Areas.Admin.ViewModels;
using UI.TocHoPham.HelperExtension;

namespace UI.TocHoPham.Areas.Admin.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ILabelService _labelService;

        public PostController(IPostService postService, ICategoryService categoryService, ILabelService labelService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _labelService = labelService;
        }

        // GET: Admin/Post
        public ActionResult Index()
        {
            return View(ModelMapper.ConvertToViewModel(_postService.GetAll(_ => _.Categories)));
        }

        [HttpGet]
        public ActionResult AddPost()
        {
            ViewBag.CategoryList = ToSelectList(ModelMapper.ConvertToViewModel(_categoryService.GetAll(), true));
            ViewBag.LabelList = ToSelectList(ModelMapper.ConvertToViewModel(_labelService.GetAll()));
            return View();
        }

        [HttpPost]
        public ActionResult AddPost(AddPostViewModel model)
        {
            model.CoverPhoto = this.WriteToFile(model.PhotoFile);

            _postService.Create(ModelMapper.ConvertToModel(model));
            
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult EditPost(int id)
        {
            UpdatePostViewModel model = ModelMapper.ConvertToUpdatePostViewModel(_postService.Get(id));

            ViewBag.CategoryList = ToSelectList(ModelMapper.ConvertToViewModel(_categoryService.GetAll(), true), model.Categories);
            ViewBag.LabelList = ToSelectList(ModelMapper.ConvertToViewModel(_labelService.GetAll()), model.Labels);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditPost(UpdatePostViewModel model)
        {
            try
            {
                model.CoverPhoto = model.PhotoFile == null? model.CoverPhoto : this.WriteToFile(model.PhotoFile);
                _postService.Update(ModelMapper.ConvertToModel(model));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public JsonResult DeletePost(int id)
        {
            try
            {
                _postService.Delete(id);
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        [HttpGet]
        public ActionResult BannerIndex()
        {
            var tmp = _postService.GetAll(_ => _.Categories).ToList();
            return View(ModelMapper.ConvertToBanner(tmp));
        }

        [HttpPost]
        public JsonResult UpdateBanner(int postId)
        {
            try
            {
                _postService.UpdateBanner(postId);
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }
        

        #region ToSelectList
        private List<SelectListItem> ToSelectList(IEnumerable<LabelViewModel> list)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (var item in list)
            {
                result.Add(new SelectListItem() { Text = item.Name , Value = item.Name });
            }
            return result;
        }

        private List<SelectListItem> ToSelectList(IEnumerable<LabelViewModel> list, IEnumerable<string> selected)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (var item in list)
            {
                if (selected.Contains(item.Name))
                    result.Add(new SelectListItem() { Text = item.Name, Value = item.Name, Selected = true });
                else
                    result.Add(new SelectListItem() { Text = item.Name, Value = item.Name });
            }
            return result;
        }

        private List<SelectListItem> ToSelectList(IEnumerable<GetCategoryViewModel> list)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (var item in list)
            {
                result.Add(new SelectListItem() { Text = item.CategoryPath, Value = item.Id.ToString() });
            }
            return result;
        }

        private List<SelectListItem> ToSelectList(IEnumerable<GetCategoryViewModel> list, IEnumerable<int> selected)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (var item in list)
            {
                if (selected.Contains(item.Id))
                    result.Add(new SelectListItem() { Text = item.CategoryPath, Value = item.Id.ToString(), Selected = true });
                else
                    result.Add(new SelectListItem() { Text = item.CategoryPath, Value = item.Id.ToString() });
            }
            return result;
        } 
        #endregion
    }
}