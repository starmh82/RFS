using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RFS.Filters;

namespace RFS.Controllers
{
    [CheckLogin]
    public class RequestsController : Controller
    {

        //// GET: Requests
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: Requests/Details/5
        //public ActionResult Details(int? id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    //Request request = db.Requests.Find(id);
        //    //if (request == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    return View();
        //}

        //// GET: Requests/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Requests/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Type,Status,Client,CreatedAt,CreatedBy,ReferenceNumber")] Request request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Requests.Add(request);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(request);
        //}

        //// GET: Requests/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Request request = db.Requests.Find(id);
        //    if (request == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(request);
        //}

        //// POST: Requests/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Type,Status,Client,CreatedAt,CreatedBy,ReferenceNumber")] Request request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(request).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(request);
        //}

        //// GET: Requests/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Request request = db.Requests.Find(id);
        //    if (request == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(request);
        //}

        //// POST: Requests/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Request request = db.Requests.Find(id);
        //    db.Requests.Remove(request);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
        //// GET: Requests
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: Requests/Details/5
        //public ActionResult Details(int? id)
        //{
        //    //if (id == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    //Request request = db.Requests.Find(id);
        //    //if (request == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}
        //    return View();
        //}

        //// GET: Requests/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Requests/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Type,Status,Client,CreatedAt,CreatedBy,ReferenceNumber")] Request request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Requests.Add(request);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(request);
        //}

        //// GET: Requests/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Request request = db.Requests.Find(id);
        //    if (request == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(request);
        //}

        //// POST: Requests/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Type,Status,Client,CreatedAt,CreatedBy,ReferenceNumber")] Request request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(request).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(request);
        //}

        //// GET: Requests/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Request request = db.Requests.Find(id);
        //    if (request == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(request);
        //}

        //// POST: Requests/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Request request = db.Requests.Find(id);
        //    db.Requests.Remove(request);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
