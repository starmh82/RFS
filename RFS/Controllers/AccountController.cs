using RFS.Filters;
using System.Web.Mvc;
using RFS.Core;
using RFS.Repositories;
using System.Linq;

namespace RFS.Controllers
{
    [CheckLogin]
    public class AccountController : Controller
    {
        private RFSContext db = new RFSContext();
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
            var user = db.Users.Where(u => u.UserName.Equals(UserName) && u.Password.Equals(Password)).FirstOrDefault();
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