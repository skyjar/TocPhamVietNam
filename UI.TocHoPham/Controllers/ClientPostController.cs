using Core.ApplicationServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.TocHoPham.Controllers
{
    public class ClientPostController : BaseController
    {
        private readonly IPostService _postService;

        public ClientPostController(IPostService postService)
        {
            _postService = postService;
        }


        [HttpGet]
        public ActionResult PostIndex(int postId)
        {
            return View(ModelMapper.ConvertToPostDetailViewModel(_postService.Get(postId)));
        }


    }
}