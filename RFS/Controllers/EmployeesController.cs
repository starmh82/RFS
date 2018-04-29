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
            int pageNumber = (page ?? 1);

            return View(employees.ToPagedList(pageNumber, PageSize));
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

            if (ModelState.IsValid)
            {
                UserService.Instance.CreateEmployee(model);
                return RedirectToAction("Index");

            }
            else
            {
                return View(model);
            }

        }

        public ActionResult Edit(int ID)
        {
            UserDto userViewModel = UserService.Instance.GetUserByID(ID);
            return View(userViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(UserDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (ModelState.IsValid)
            {
                UserService.Instance.UpdateEmployee(model);
                return RedirectToAction("Index");

            }
            else
            {
                return View("Edit", model);
            }

        }
        public ActionResult Delete(int ID)
        {
            UserDto userViewModel = UserService.Instance.GetUserByID(ID);
            return View(userViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UserDto model)
        {
            UserService.Instance.Delete(model);
           return RedirectToAction("Index");
        }

    }
}