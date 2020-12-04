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
    public class HoadonController : Controller
    {
        private ductri1Entities db = new ductri1Entities();

        // GET: Hoadon
        public ActionResult Index()
        {
            var hoadons = db.Hoadons.Include(h => h.Detail_HD).Include(h => h.Khachhang);
            return View(hoadons.ToList());
        }

        // GET: Hoadon/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoadon hoadon = db.Hoadons.Find(id);
            if (hoadon == null)
            {
                return HttpNotFound();
            }
            return View(hoadon);
        }

        // GET: Hoadon/Create
        public ActionResult Create()
        {
            ViewBag.SoHD = new SelectList(db.Detail_HD, "SoHD", "MASP");
            ViewBag.MAKH = new SelectList(db.Khachhangs, "MAKH", "TENKH");
            return View();
        }

        // POST: Hoadon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoHD,MAKH,Ngaymua")] Hoadon hoadon)
        {
            if (ModelState.IsValid)
            {
                db.Hoadons.Add(hoadon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SoHD = new SelectList(db.Detail_HD, "SoHD", "MASP", hoadon.SoHD);
            ViewBag.MAKH = new SelectList(db.Khachhangs, "MAKH", "TENKH", hoadon.MAKH);
            return View(hoadon);
        }

        // GET: Hoadon/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoadon hoadon = db.Hoadons.Find(id);
            if (hoadon == null)
            {
                return HttpNotFound();
            }
            ViewBag.SoHD = new SelectList(db.Detail_HD, "SoHD", "MASP", hoadon.SoHD);
            ViewBag.MAKH = new SelectList(db.Khachhangs, "MAKH", "TENKH", hoadon.MAKH);
            return View(hoadon);
        }

        // POST: Hoadon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoHD,MAKH,Ngaymua")] Hoadon hoadon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoadon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SoHD = new SelectList(db.Detail_HD, "SoHD", "MASP", hoadon.SoHD);
            ViewBag.MAKH = new SelectList(db.Khachhangs, "MAKH", "TENKH", hoadon.MAKH);
            return View(hoadon);
        }

        // GET: Hoadon/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoadon hoadon = db.Hoadons.Find(id);
            if (hoadon == null)
            {
                return HttpNotFound();
            }
            return View(hoadon);
        }

        // POST: Hoadon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Hoadon hoadon = db.Hoadons.Find(id);
            db.Hoadons.Remove(hoadon);
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
