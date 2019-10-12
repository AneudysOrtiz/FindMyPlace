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
    public class AmenidadesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Amenidades
        public ActionResult Index()
        {
            return View(db.Amenidades.ToList());
        }

        // GET: Amenidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amenidad amenidad = db.Amenidades.Find(id);
            if (amenidad == null)
            {
                return HttpNotFound();
            }
            return View(amenidad);
        }

        // GET: Amenidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Amenidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AmenidadId,Descripcion")] Amenidad amenidad)
        {
            if (ModelState.IsValid)
            {
                db.Amenidades.Add(amenidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(amenidad);
        }

        // GET: Amenidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amenidad amenidad = db.Amenidades.Find(id);
            if (amenidad == null)
            {
                return HttpNotFound();
            }
            return View(amenidad);
        }

        // POST: Amenidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AmenidadId,Descripcion")] Amenidad amenidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(amenidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(amenidad);
        }

        // GET: Amenidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amenidad amenidad = db.Amenidades.Find(id);
            if (amenidad == null)
            {
                return HttpNotFound();
            }
            return View(amenidad);
        }

        // POST: Amenidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Amenidad amenidad = db.Amenidades.Find(id);
            db.Amenidades.Remove(amenidad);
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
