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
    public class EnviasController : Controller
    {
        private Db_Context db = new Db_Context();

        // GET: Envias
        public ActionResult Index()
        {
            var envias = db.envias.Include(e => e.TablaDepartamentoRecibe).Include(e => e.TablaProducto).Include(e => e.TablaSucursal);
            return View(envias.ToList());
        }

        // GET: Envias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Envia envia = db.envias.Find(id);
            if (envia == null)
            {
                return HttpNotFound();
            }
            return View(envia);
        }

        // GET: Envias/Create
        public ActionResult Create()
        {
            ViewBag.DepartamentoRecibeId = new SelectList(db.departamentoReciben, "Id", "NombreDepartamentoRecibe");
            ViewBag.ProductoId = new SelectList(db.productos, "Id", "NombreProducto");
            ViewBag.SucursalId = new SelectList(db.sucursales, "Id", "NombreTienda");
            return View();
        }

        // POST: Envias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NombreEnvio,CantidadEnvia,Fecha,ProductoId,SucursalId,DepartamentoRecibeId")] Envia envia)
        {
            if (ModelState.IsValid)
            {
                db.envias.Add(envia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartamentoRecibeId = new SelectList(db.departamentoReciben, "Id", "NombreDepartamentoRecibe", envia.DepartamentoRecibeId);
            ViewBag.ProductoId = new SelectList(db.productos, "Id", "NombreProducto", envia.ProductoId);
            ViewBag.SucursalId = new SelectList(db.sucursales, "Id", "NombreTienda", envia.SucursalId);
            return View(envia);
        }

        // GET: Envias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Envia envia = db.envias.Find(id);
            if (envia == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoRecibeId = new SelectList(db.departamentoReciben, "Id", "NombreDepartamentoRecibe", envia.DepartamentoRecibeId);
            ViewBag.ProductoId = new SelectList(db.productos, "Id", "NombreProducto", envia.ProductoId);
            ViewBag.SucursalId = new SelectList(db.sucursales, "Id", "NombreTienda", envia.SucursalId);
            return View(envia);
        }

        // POST: Envias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NombreEnvio,CantidadEnvia,Fecha,ProductoId,SucursalId,DepartamentoRecibeId")] Envia envia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(envia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoRecibeId = new SelectList(db.departamentoReciben, "Id", "NombreDepartamentoRecibe", envia.DepartamentoRecibeId);
            ViewBag.ProductoId = new SelectList(db.productos, "Id", "NombreProducto", envia.ProductoId);
            ViewBag.SucursalId = new SelectList(db.sucursales, "Id", "NombreTienda", envia.SucursalId);
            return View(envia);
        }

        // GET: Envias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Envia envia = db.envias.Find(id);
            if (envia == null)
            {
                return HttpNotFound();
            }
            return View(envia);
        }

        // POST: Envias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Envia envia = db.envias.Find(id);
            db.envias.Remove(envia);
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
