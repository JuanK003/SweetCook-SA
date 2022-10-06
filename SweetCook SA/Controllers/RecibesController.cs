using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SweetCook_SA.Models;

namespace SweetCook_SA.Controllers
{
    public class RecibesController : Controller
    {
        private Db_Context db = new Db_Context();

        // GET: Recibes
        public ActionResult Index()
        {
            var reciben = db.reciben.Include(r => r.TablaEnvia);
            return View(reciben.ToList());
        }

        // GET: Recibes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recibe recibe = db.reciben.Find(id);
            if (recibe == null)
            {
                return HttpNotFound();
            }
            return View(recibe);
        }

        // GET: Recibes/Create
        public ActionResult Create()
        {
            ViewBag.EnviaId = new SelectList(db.envias, "Id", "NombreEnvio");
            return View();
        }

        // POST: Recibes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Fecha,EnviaId")] Recibe recibe)
        {
            if (ModelState.IsValid)
            {
                db.reciben.Add(recibe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EnviaId = new SelectList(db.envias, "Id", "NombreEnvio", recibe.EnviaId);
            return View(recibe);
        }

        // GET: Recibes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recibe recibe = db.reciben.Find(id);
            if (recibe == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnviaId = new SelectList(db.envias, "Id", "NombreEnvio", recibe.EnviaId);
            return View(recibe);
        }

        // POST: Recibes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Fecha,EnviaId")] Recibe recibe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recibe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnviaId = new SelectList(db.envias, "Id", "NombreEnvio", recibe.EnviaId);
            return View(recibe);
        }

        // GET: Recibes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recibe recibe = db.reciben.Find(id);
            if (recibe == null)
            {
                return HttpNotFound();
            }
            return View(recibe);
        }

        // POST: Recibes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recibe recibe = db.reciben.Find(id);
            db.reciben.Remove(recibe);
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
