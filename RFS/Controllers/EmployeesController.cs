using RFS.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace RFS.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index(int? page)
        {
            var employees = UserService.Instance.GetAllEmployees();

            int PageSize = 10;
            int pageNumber = (page ??1);

            return View(employees.ToPagedList(pageNumber, PageSize));
        }
        public ActionResult Edit(int Id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

    }
}