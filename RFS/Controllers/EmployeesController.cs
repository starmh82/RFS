using RFS.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using RFS.Application.Dto;
using RFS.Web.Models;

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
            UserCreateDto userViewModel = new UserCreateDto();
            return View(userViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreateDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if(ModelState.IsValid)
            {
                return View();
            }
            else
            {
                return View(model);
            }
            
        }

    }
}