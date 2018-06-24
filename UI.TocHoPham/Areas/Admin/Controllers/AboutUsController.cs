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
    public class AboutUsController : BaseController
    {
        private readonly IAboutUsService _aboutUsService;

        public AboutUsController(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }

        // GET: Admin/AboutUs
        [HttpGet]
        public ActionResult UpdateAboutUs()
        {
            return View(ModelMapper.ConvertToViewModel(_aboutUsService.Get()));
        }

        [HttpPost]
        public ActionResult UpdateAboutUs(AboutUsViewModel viewModel)
        {
            if (viewModel.PhotoFile != null)
            {
                viewModel.CoverPhoto = this.WriteToFile(viewModel.PhotoFile);
            }
            _aboutUsService.Update(ModelMapper.ConvertToModel(viewModel));
            return RedirectToAction("UpdateAboutUs");
        }
    }
}