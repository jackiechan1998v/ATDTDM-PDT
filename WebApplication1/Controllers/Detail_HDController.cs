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
    public class Detail_HDController : Controller
    {
        private ductri1Entities db = new ductri1Entities();

        // GET: Detail_HD
        public ActionResult Index()
        {
            var detail_HD = db.Detail_HD.Include(d => d.Hoadon).Include(d => d.Sanpham);
            return View(detail_HD.ToList());
        }

        // GET: Detail_HD/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail_HD detail_HD = db.Detail_HD.Find(id);
            if (detail_HD == null)
            {
                return HttpNotFound();
            }
            return View(detail_HD);
        }

        // GET: Detail_HD/Create
        public ActionResult Create()
        {
            ViewBag.SoHD = new SelectList(db.Hoadons, "SoHD", "SoHD");
            ViewBag.MASP = new SelectList(db.Sanphams, "MASP", "TENSP");
            return View();
        }

        // POST: Detail_HD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoHD,MASP,SL")] Detail_HD detail_HD)
        {
            if (ModelState.IsValid)
            {
                db.Detail_HD.Add(detail_HD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SoHD = new SelectList(db.Hoadons, "SoHD", "SoHD", detail_HD.SoHD);
            ViewBag.MASP = new SelectList(db.Sanphams, "MASP", "TENSP", detail_HD.MASP);
            return View(detail_HD);
        }

        // GET: Detail_HD/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail_HD detail_HD = db.Detail_HD.Find(id);
            if (detail_HD == null)
            {
                return HttpNotFound();
            }
            ViewBag.SoHD = new SelectList(db.Hoadons, "SoHD", "SoHD", detail_HD.SoHD);
            ViewBag.MASP = new SelectList(db.Sanphams, "MASP", "TENSP", detail_HD.MASP);
            return View(detail_HD);
        }

        // POST: Detail_HD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoHD,MASP,SL")] Detail_HD detail_HD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detail_HD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SoHD = new SelectList(db.Hoadons, "SoHD", "SoHD", detail_HD.SoHD);
            ViewBag.MASP = new SelectList(db.Sanphams, "MASP", "TENSP", detail_HD.MASP);
            return View(detail_HD);
        }

        // GET: Detail_HD/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail_HD detail_HD = db.Detail_HD.Find(id);
            if (detail_HD == null)
            {
                return HttpNotFound();
            }
            return View(detail_HD);
        }

        // POST: Detail_HD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Detail_HD detail_HD = db.Detail_HD.Find(id);
            db.Detail_HD.Remove(detail_HD);
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
