namespace UI.TocHoPham.Areas.Admin.Controllers
{
    using Core.ApplicationServices.Services;
    using System;
    using System.Web.Mvc;
    using UI.TocHoPham.Areas.Admin.ViewModels;
    using UI.TocHoPham.HelperExtension;

    public class GalleryController : BaseController
    {
        private readonly IGalleryService _galleryService;
        private readonly IPhotoService _photoService;

        public GalleryController(IGalleryService galleryService, IPhotoService photoService)
        {
            _galleryService = galleryService;
            _photoService = photoService;
        }

        // GET: Admin/Gallery
        public ActionResult Index()
        {
            return View(ModelMapper.ConvertToGetViewModel(_galleryService.GetAll()));
        }

        [HttpPost]
        public JsonResult AddGallery(AddGalleryViewModel viewModel)
        {
            try
            {
                _galleryService.Create(ModelMapper.ConvertToModel(viewModel));
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        [HttpGet]
        public ActionResult AlbumIndex(int albumId)
        {
            return View(_galleryService.Get(albumId));
        }

        [HttpPost]
        public JsonResult UpdateAlbumInfo(UpdateGalleryViewModel viewModel)
        {
            try
            {
                _galleryService.Update(ModelMapper.ConvertToModel(viewModel));
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        [HttpPost]
        public ActionResult DeleteGallery(int galleryId)
        {
            try
            {
                _galleryService.Delete(galleryId);
                return RedirectToAction("Index", "Gallery");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public JsonResult AddPhoto(AddPhotoViewModel viewModel)//GalleryID + URL + Type ?
        {
            try
            {
                var model = ModelMapper.ConvertToModel(viewModel);
                if (model.IsPhoto)
                {
                    model.Url = this.WriteToFile(viewModel.PhotoFile);
                }
                _photoService.Create(model);
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        [HttpPost]
        public JsonResult ChangeBackgroundPhoto(int photoId)
        {
            try
            {
                _photoService.ChangeBackgroundPhoto(photoId);
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }

        [HttpPost]
        public JsonResult DeletePhoto(int photoId)
        {
            try
            {
                _photoService.Delete(photoId);
                return Json(true);
            }
            catch (Exception)
            {
                return Json(false);
            }
        }
    }
}