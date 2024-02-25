using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VideoClub.Models;

namespace VideoClub.Controllers
{
    public class DistribuidorasController : Controller
    {
        private VideoClubDBEntities db = new VideoClubDBEntities();

        // GET: Distribuidoras
        public ActionResult Index()
        {
            return View(db.Distribuidoras.ToList());
        }

        // GET: Distribuidoras/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distribuidora distribuidora = db.Distribuidoras.Find(id);
            if (distribuidora == null)
            {
                return HttpNotFound();
            }
            return View(distribuidora);
        }

        // GET: Distribuidoras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Distribuidoras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DistribuidoraId,Nombre,Direccion,URL")] Distribuidora distribuidora)
        {
            if (ModelState.IsValid)
            {
                db.Distribuidoras.Add(distribuidora);
                //db.SaveChanges();
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }
                return RedirectToAction("Index");
            }

            return View(distribuidora);
        }

        // GET: Distribuidoras/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distribuidora distribuidora = db.Distribuidoras.Find(id);
            if (distribuidora == null)
            {
                return HttpNotFound();
            }
            return View(distribuidora);
        }

        // POST: Distribuidoras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DistribuidoraId,Nombre,Direccion,URL")] Distribuidora distribuidora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distribuidora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(distribuidora);
        }

        // GET: Distribuidoras/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distribuidora distribuidora = db.Distribuidoras.Find(id);
            if (distribuidora == null)
            {
                return HttpNotFound();
            }
            return View(distribuidora);
        }

        // POST: Distribuidoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Distribuidora distribuidora = db.Distribuidoras.Find(id);
            db.Distribuidoras.Remove(distribuidora);
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
