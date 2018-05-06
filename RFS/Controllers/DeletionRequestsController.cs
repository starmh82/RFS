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
            //ViewBag.Nationalities = new SelectList(GetNationalities(), "Value", "Text");
            //ViewBag.DeletionReasons = new SelectList(DeletionReasonService.Instance.GetReasons(null), "Id", "Title");

            return View(drViewModel);
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
                //ViewBag.DeletionReasons = new SelectList(DeletionReasonService.Instance.GetReasons(null), "Id", "Title");
                return RedirectToAction("Index");

            }
            else
            {
                //ViewBag.Nationalities = new SelectList(GetNationalities(), "Value", "Text");
                return View(model);
            }

        }
        public JsonResult GetNationalities()
        {
            return Json( LookupsService.Instance.GetNationalities(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetReasons(int NationalityType)
        {
            var reasons = DeletionReasonService.Instance.GetReasons(NationalityType);
            return Json(reasons, JsonRequestBehavior.AllowGet);
        }
    }
}