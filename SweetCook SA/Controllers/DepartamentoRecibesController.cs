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
    public class DepartamentoRecibesController : Controller
    {
        private Db_Context db = new Db_Context();

        // GET: DepartamentoRecibes
        public ActionResult Index()
        {
            return View(db.departamentoReciben.ToList());
        }

        // GET: DepartamentoRecibes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartamentoRecibe departamentoRecibe = db.departamentoReciben.Find(id);
            if (departamentoRecibe == null)
            {
                return HttpNotFound();
            }
            return View(departamentoRecibe);
        }

        // GET: DepartamentoRecibes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartamentoRecibes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreDepartamentoRecibe")] DepartamentoRecibe departamentoRecibe)
        {
            if (ModelState.IsValid)
            {
                db.departamentoReciben.Add(departamentoRecibe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departamentoRecibe);
        }

        // GET: DepartamentoRecibes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartamentoRecibe departamentoRecibe = db.departamentoReciben.Find(id);
            if (departamentoRecibe == null)
            {
                return HttpNotFound();
            }
            return View(departamentoRecibe);
        }

        // POST: DepartamentoRecibes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreDepartamentoRecibe")] DepartamentoRecibe departamentoRecibe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departamentoRecibe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departamentoRecibe);
        }

        // GET: DepartamentoRecibes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartamentoRecibe departamentoRecibe = db.departamentoReciben.Find(id);
            if (departamentoRecibe == null)
            {
                return HttpNotFound();
            }
            return View(departamentoRecibe);
        }

        // POST: DepartamentoRecibes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepartamentoRecibe departamentoRecibe = db.departamentoReciben.Find(id);
            db.departamentoReciben.Remove(departamentoRecibe);
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
