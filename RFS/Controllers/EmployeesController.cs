using RFS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RFS.Controllers
{
    public class EmployeesController : Controller
    {
        private RFSContext db = new RFSContext();
        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
        public ActionResult Edit(int Id)
        {
            return View();
        }

    }
}