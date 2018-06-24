namespace UI.TocHoPham.Areas.Admin.Controllers
{
    using Core.ApplicationServices.IdentityServices;
    using Core.ObjectModels.Identities;
    using Microsoft.Owin.Security;
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using UI.TocHoPham.Areas.Admin.ViewModels;

    public class AccountController : BaseController
    {
        private readonly IIdentityService _identityService;

        public AccountController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAccount(string s)
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAccount(int id)
        {
            return View();
        }
        

        [HttpGet, AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                if (string.IsNullOrEmpty(returnUrl))
                    return RedirectToAction("ProfileDetails", "Profile");
                else
                {
                    throw new HttpException(403, "Not authorized");
                }
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel user, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IdentityResultTHP result = await _identityService.Login(user.Username, user.Password);

                    if (result.IsErrors)
                    {
                        foreach (var ele in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, ele);
                        }
                    }
                    else
                    {
                        ClaimsIdentity claimsIdentity = result.Data as ClaimsIdentity;
                        CurrentAuthenticationManager.SignOut();
                        CurrentAuthenticationManager.SignIn(new AuthenticationProperties()
                        {
                            IsPersistent = user.RememberMe,
                        }, claimsIdentity);
                        if (string.IsNullOrEmpty(returnUrl))
                            return RedirectToAction("ProfileDetails", "Profile");
                        else
                            return Redirect(returnUrl);
                    }
                }
                else
                {
                    ViewBag.ReturnUrl = returnUrl;
                    return View();
                }
            }
            catch (Exception)
            {
                throw;
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        private IAuthenticationManager CurrentAuthenticationManager
            => HttpContext.GetOwinContext().Authentication;

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(UserRegisterForm registerViewModels)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    IdentityResultTHP infor = await this._identityService.Register(registerViewModels);
                    if (infor.IsErrors)
                    {
                        foreach (var error in infor.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error);
                        }
                        return View();
                    }
                    else
                    {
                        return RedirectToAction(nameof(Login));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}