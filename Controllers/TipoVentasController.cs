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
    public class TipoVentasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoVentas
        public ActionResult Index()
        {
            return View(db.TipoVentas.ToList());
        }

        // GET: TipoVentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoVenta tipoVenta = db.TipoVentas.Find(id);
            if (tipoVenta == null)
            {
                return HttpNotFound();
            }
            return View(tipoVenta);
        }

        // GET: TipoVentas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoVentas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoVentaId,Descripcion")] TipoVenta tipoVenta)
        {
            if (ModelState.IsValid)
            {
                db.TipoVentas.Add(tipoVenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoVenta);
        }

        // GET: TipoVentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoVenta tipoVenta = db.TipoVentas.Find(id);
            if (tipoVenta == null)
            {
                return HttpNotFound();
            }
            return View(tipoVenta);
        }

        // POST: TipoVentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoVentaId,Descripcion")] TipoVenta tipoVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoVenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoVenta);
        }

        // GET: TipoVentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoVenta tipoVenta = db.TipoVentas.Find(id);
            if (tipoVenta == null)
            {
                return HttpNotFound();
            }
            return View(tipoVenta);
        }

        // POST: TipoVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoVenta tipoVenta = db.TipoVentas.Find(id);
            db.TipoVentas.Remove(tipoVenta);
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
