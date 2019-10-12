using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FindMyPlace.DataAccess;
using FindMyPlace.Models;

namespace FindMyPlace.Controllers
{
    public class CondicionesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Condiciones
        public ActionResult Index()
        {
            return View(db.Condiciones.ToList());
        }

        // GET: Condiciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condicion condicion = db.Condiciones.Find(id);
            if (condicion == null)
            {
                return HttpNotFound();
            }
            return View(condicion);
        }

        // GET: Condiciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Condiciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CondicionId,Descripcion")] Condicion condicion)
        {
            if (ModelState.IsValid)
            {
                db.Condiciones.Add(condicion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(condicion);
        }

        // GET: Condiciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condicion condicion = db.Condiciones.Find(id);
            if (condicion == null)
            {
                return HttpNotFound();
            }
            return View(condicion);
        }

        // POST: Condiciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CondicionId,Descripcion")] Condicion condicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(condicion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(condicion);
        }

        // GET: Condiciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condicion condicion = db.Condiciones.Find(id);
            if (condicion == null)
            {
                return HttpNotFound();
            }
            return View(condicion);
        }

        // POST: Condiciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Condicion condicion = db.Condiciones.Find(id);
            db.Condiciones.Remove(condicion);
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
