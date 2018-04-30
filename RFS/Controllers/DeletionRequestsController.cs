using PagedList;
using RFS.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RFS.Application.Dto;

namespace RFS.Web.Controllers
{
    public class DeletionRequestsController : Controller
    {
        // GET: DeletionRequests
        public ActionResult Index(int? page)
        {
            var requests = DeletionRequestService.Instance.GetAllRequests();

            int PageSize = 10;
            int pageNumber = (page ?? 1);

            return View(requests.ToPagedList(pageNumber, PageSize));
        }
        public ActionResult Create()
        {
            DeletionRequestCreateDto drViewModel = new DeletionRequestCreateDto();
            ViewBag.Nationalities = new SelectList(GetNationalities(), "Value", "Text");
            ViewBag.DeletionReasons = new SelectList(DeletionReasonService.Instance.GetAllReasons(), "Id", "Title");

            return View(drViewModel);
        }
        protected List<SelectListItem> GetNationalities()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "Saudi", Value = "1" });
            list.Add(new SelectListItem() { Text = "Non Saudi", Value = "2" });

            return list;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DeletionRequestCreateDto model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (ModelState.IsValid)
            {
                DeletionRequestService.Instance.CreateDeletionRequest(model);
                return RedirectToAction("Index");

            }
            else
            {
                return View(model);
            }

        }
    }
}