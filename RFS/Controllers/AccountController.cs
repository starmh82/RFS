using RFS.Filters;
using System.Web.Mvc;
using System.Linq;
using RFS.Application;

namespace RFS.Controllers
{
    [CheckLogin]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string UserName,string Password)
        {
            var user = UserService.Instance.FindUser(UserName, Password);
            if(user != null)
            {
                Session["UserName"] = UserName;
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "User Name or Password is incorrect!");
            return View();
        }
        public ActionResult Logout()
        {
            Session["UserName"] = null;
           return  RedirectToAction("Login", "Account");
        }

    }
}