using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoaisanphamController : Controller
    {
        private ductri1Entities db = new ductri1Entities();

        // GET: Loaisanpham
        public ActionResult Index()
        {
            return View(db.Loaisanphams.ToList());
        }

        // GET: Loaisanpham/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loaisanpham loaisanpham = db.Loaisanphams.Find(id);
            if (loaisanpham == null)
            {
                return HttpNotFound();
            }
            return View(loaisanpham);
        }

        // GET: Loaisanpham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Loaisanpham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MALOAI,TENLOAI")] Loaisanpham loaisanpham)
        {
            if (ModelState.IsValid)
            {
                db.Loaisanphams.Add(loaisanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaisanpham);
        }

        // GET: Loaisanpham/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loaisanpham loaisanpham = db.Loaisanphams.Find(id);
            if (loaisanpham == null)
            {
                return HttpNotFound();
            }
            return View(loaisanpham);
        }

        // POST: Loaisanpham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MALOAI,TENLOAI")] Loaisanpham loaisanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaisanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaisanpham);
        }

        // GET: Loaisanpham/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loaisanpham loaisanpham = db.Loaisanphams.Find(id);
            if (loaisanpham == null)
            {
                return HttpNotFound();
            }
            return View(loaisanpham);
        }

        // POST: Loaisanpham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Loaisanpham loaisanpham = db.Loaisanphams.Find(id);
            db.Loaisanphams.Remove(loaisanpham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
