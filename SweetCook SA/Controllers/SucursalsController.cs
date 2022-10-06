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
    public class SucursalsController : Controller
    {
        private Db_Context db = new Db_Context();

        // GET: Sucursals
        public ActionResult Index()
        {
            var sucursales = db.sucursales.Include(s => s.TablaDepartamentoSucursal);
            return View(sucursales.ToList());
        }

        // GET: Sucursals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal sucursal = db.sucursales.Find(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            return View(sucursal);
        }

        // GET: Sucursals/Create
        public ActionResult Create()
        {
            ViewBag.DepartamentoSucursalId = new SelectList(db.departamentoSucursales, "Id", "NombreDepartamento");
            return View();
        }

        // POST: Sucursals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreTienda,Telefono,Email,DepartamentoSucursalId")] Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                db.sucursales.Add(sucursal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartamentoSucursalId = new SelectList(db.departamentoSucursales, "Id", "NombreDepartamento", sucursal.DepartamentoSucursalId);
            return View(sucursal);
        }

        // GET: Sucursals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal sucursal = db.sucursales.Find(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoSucursalId = new SelectList(db.departamentoSucursales, "Id", "NombreDepartamento", sucursal.DepartamentoSucursalId);
            return View(sucursal);
        }

        // POST: Sucursals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreTienda,Telefono,Email,DepartamentoSucursalId")] Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoSucursalId = new SelectList(db.departamentoSucursales, "Id", "NombreDepartamento", sucursal.DepartamentoSucursalId);
            return View(sucursal);
        }

        // GET: Sucursals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursal sucursal = db.sucursales.Find(id);
            if (sucursal == null)
            {
                return HttpNotFound();
            }
            return View(sucursal);
        }

        // POST: Sucursals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sucursal sucursal = db.sucursales.Find(id);
            db.sucursales.Remove(sucursal);
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
