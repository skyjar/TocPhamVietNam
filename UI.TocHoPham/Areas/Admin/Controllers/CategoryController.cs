namespace UI.TocHoPham.Areas.Admin.Controllers
{
    using Core.ApplicationServices.Services;
    using Core.ObjectModels.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using UI.TocHoPham.Areas.Admin.ViewModels;

    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllCategory()
        {
            try
            {
                return Json(ModelMapper.ConvertToViewModel(_categoryService.GetAllParent()), 
                    JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AddCategory(CreateCategoryViewModel model)
        {
            try
            {
                _categoryService.Create(base.ModelMapper.ConvertToModel(model));
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        public JsonResult UpdateCategory(UpdateCategoryViewModel model)
        {
            try
            {
                _categoryService.Update(base.ModelMapper.ConvertToModel(model));
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        public JsonResult DeteleCategory(int id)
        {
            try
            {
                _categoryService.Delete(id);
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        public JsonResult PublishCategory(int id)
        {
            try
            {
                _categoryService.UpdatePublish(id);
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}