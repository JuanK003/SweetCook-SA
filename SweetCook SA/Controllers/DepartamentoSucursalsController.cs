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
    public class DepartamentoSucursalsController : Controller
    {
        private Db_Context db = new Db_Context();

        // GET: DepartamentoSucursals
        public ActionResult Index()
        {
            return View(db.departamentoSucursales.ToList());
        }

        // GET: DepartamentoSucursals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartamentoSucursal departamentoSucursal = db.departamentoSucursales.Find(id);
            if (departamentoSucursal == null)
            {
                return HttpNotFound();
            }
            return View(departamentoSucursal);
        }

        // GET: DepartamentoSucursals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartamentoSucursals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreDepartamento")] DepartamentoSucursal departamentoSucursal)
        {
            if (ModelState.IsValid)
            {
                db.departamentoSucursales.Add(departamentoSucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departamentoSucursal);
        }

        // GET: DepartamentoSucursals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartamentoSucursal departamentoSucursal = db.departamentoSucursales.Find(id);
            if (departamentoSucursal == null)
            {
                return HttpNotFound();
            }
            return View(departamentoSucursal);
        }

        // POST: DepartamentoSucursals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreDepartamento")] DepartamentoSucursal departamentoSucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departamentoSucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departamentoSucursal);
        }

        // GET: DepartamentoSucursals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartamentoSucursal departamentoSucursal = db.departamentoSucursales.Find(id);
            if (departamentoSucursal == null)
            {
                return HttpNotFound();
            }
            return View(departamentoSucursal);
        }

        // POST: DepartamentoSucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DepartamentoSucursal departamentoSucursal = db.departamentoSucursales.Find(id);
            db.departamentoSucursales.Remove(departamentoSucursal);
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
