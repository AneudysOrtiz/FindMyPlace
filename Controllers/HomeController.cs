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
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var inmuebles = db.Inmuebles.Include(i => i.Categoria).Include(i => i.Condicion).Include(i => i.TipoVenta).Include(i => i.Moneda);
            return View(inmuebles.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}