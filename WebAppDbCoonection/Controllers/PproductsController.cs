﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppDbCoonection.Models;

namespace WebAppDbCoonection.Controllers
{
    public class PproductsController : Controller
    {
        private PProductsDBEntities3 db = new PProductsDBEntities3();

        // GET: Pproducts
        public ActionResult Index()
        {
            return View(db.Pproducts.ToList());
        }

        // GET: Pproducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pproduct pproduct = db.Pproducts.Find(id);
            if (pproduct == null)
            {
                return HttpNotFound();
            }
            return View(pproduct);
        }

        // GET: Pproducts/Create
        public ActionResult Create()
        {
            return View(new Pproduct());
        }

        // POST: Pproducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PId,Pname,PPrice,PMfgDate,PExpDate")] Pproduct pproduct)
        {
            if (ModelState.IsValid)
            {
                db.Pproducts.Add(pproduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pproduct);
        }

        // GET: Pproducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pproduct pproduct = db.Pproducts.Find(id);
            if (pproduct == null)
            {
                return HttpNotFound();
            }
            return View(pproduct);
        }

        // POST: Pproducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PId,Pname,PPrice,PMfgDate,PExpDate")] Pproduct pproduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pproduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pproduct);
        }

        // GET: Pproducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pproduct pproduct = db.Pproducts.Find(id);
            if (pproduct == null)
            {
                return HttpNotFound();
            }
            return View(pproduct);
        }

        // POST: Pproducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pproduct pproduct = db.Pproducts.Find(id);
            db.Pproducts.Remove(pproduct);
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
