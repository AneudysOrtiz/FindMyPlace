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
    public class InmueblesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Inmuebles
        public ActionResult Index()
        {
            var inmuebles = db.Inmuebles.Include(i => i.Categoria).Include(i => i.Condicion).Include(i => i.TipoVenta);
            return View(inmuebles.ToList());
        }

        // GET: Inmuebles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inmueble inmueble = db.Inmuebles.Find(id);
            if (inmueble == null)
            {
                return HttpNotFound();
            }
            return View(inmueble);
        }

        // GET: Inmuebles/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nombre");
            ViewBag.CondicionId = new SelectList(db.Condiciones, "CondicionId", "Descripcion");
            ViewBag.TipoVentaId = new SelectList(db.TipoVentas, "TipoVentaId", "Descripcion");
            return View();
        }

        // POST: Inmuebles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InmuebleId,Precio,TipoVentaId,CondicionId,CategoriaId")] Inmueble inmueble)
        {
            if (ModelState.IsValid)
            {
                db.Inmuebles.Add(inmueble);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nombre", inmueble.CategoriaId);
            ViewBag.CondicionId = new SelectList(db.Condiciones, "CondicionId", "Descripcion", inmueble.CondicionId);
            ViewBag.TipoVentaId = new SelectList(db.TipoVentas, "TipoVentaId", "Descripcion", inmueble.TipoVentaId);
            return View(inmueble);
        }

        // GET: Inmuebles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inmueble inmueble = db.Inmuebles.Find(id);
            if (inmueble == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nombre", inmueble.CategoriaId);
            ViewBag.CondicionId = new SelectList(db.Condiciones, "CondicionId", "Descripcion", inmueble.CondicionId);
            ViewBag.TipoVentaId = new SelectList(db.TipoVentas, "TipoVentaId", "Descripcion", inmueble.TipoVentaId);
            return View(inmueble);
        }

        // POST: Inmuebles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InmuebleId,Precio,TipoVentaId,CondicionId,CategoriaId")] Inmueble inmueble)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inmueble).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categorias, "CategoriaId", "Nombre", inmueble.CategoriaId);
            ViewBag.CondicionId = new SelectList(db.Condiciones, "CondicionId", "Descripcion", inmueble.CondicionId);
            ViewBag.TipoVentaId = new SelectList(db.TipoVentas, "TipoVentaId", "Descripcion", inmueble.TipoVentaId);
            return View(inmueble);
        }

        // GET: Inmuebles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inmueble inmueble = db.Inmuebles.Find(id);
            if (inmueble == null)
            {
                return HttpNotFound();
            }
            return View(inmueble);
        }

        // POST: Inmuebles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inmueble inmueble = db.Inmuebles.Find(id);
            db.Inmuebles.Remove(inmueble);
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
