using RFS.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace RFS.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            var employees = UserService.Instance.GetAllEmployees();
            return View(employees);
        }
        public ActionResult Edit(int Id)
        {
            return View();
        }

    }
}