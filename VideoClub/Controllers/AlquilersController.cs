using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VideoClub.Models;

namespace VideoClub.Controllers
{
    public class AlquilersController : Controller
    {
        private VideoClubDBEntities db = new VideoClubDBEntities();

        // GET: Alquilers
        public ActionResult Index()
        {
            var alquilers = db.Alquilers.Include(a => a.Cliente).Include(a => a.Pelicula);
            return View(alquilers.ToList());
        }

        // GET: Alquilers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alquiler alquiler = db.Alquilers.Find(id);
            if (alquiler == null)
            {
                return HttpNotFound();
            }
            return View(alquiler);
        }

        // GET: Alquilers/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "DNI");
            ViewBag.PeliculaID = new SelectList(db.Peliculas, "PeliculaID", "Titulo");
            return View();
        }

        // POST: Alquilers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlquilerID,PeliculaID,ClienteID,FechaEntrega,FechaDevolucion,DiasExtra,Penalizacion,TotalPagar")] Alquiler alquiler)
        {
            if (ModelState.IsValid)
            {
                db.Alquilers.Add(alquiler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "DNI", alquiler.ClienteID);
            ViewBag.PeliculaID = new SelectList(db.Peliculas, "PeliculaID", "Titulo", alquiler.PeliculaID);
            return View(alquiler);
        }

        // GET: Alquilers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alquiler alquiler = db.Alquilers.Find(id);
            if (alquiler == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "DNI", alquiler.ClienteID);
            ViewBag.PeliculaID = new SelectList(db.Peliculas, "PeliculaID", "Titulo", alquiler.PeliculaID);
            return View(alquiler);
        }

        // POST: Alquilers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlquilerID,PeliculaID,ClienteID,FechaEntrega,FechaDevolucion,DiasExtra,Penalizacion,TotalPagar")] Alquiler alquiler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alquiler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "DNI", alquiler.ClienteID);
            ViewBag.PeliculaID = new SelectList(db.Peliculas, "PeliculaID", "Titulo", alquiler.PeliculaID);
            return View(alquiler);
        }

        // GET: Alquilers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alquiler alquiler = db.Alquilers.Find(id);
            if (alquiler == null)
            {
                return HttpNotFound();
            }
            return View(alquiler);
        }

        // POST: Alquilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Alquiler alquiler = db.Alquilers.Find(id);
            db.Alquilers.Remove(alquiler);
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
