using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaTecnica_AndresFerreira.Models;

namespace PruebaTecnica_AndresFerreira.Controllers
{
    public class CoberturasController : Controller
    {
        private PruebaTecnicaEntities db = new PruebaTecnicaEntities();

        // GET: Coberturas
        public ActionResult Index()
        {
            var cobertura = db.Cobertura.Include(c => c.Producto);
            return View(cobertura.ToList());
        }

        // GET: Coberturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cobertura cobertura = db.Cobertura.Find(id);
            if (cobertura == null)
            {
                return HttpNotFound();
            }
            return View(cobertura);
        }

        // GET: Coberturas/Create
        public ActionResult Create()
        {
            ViewBag.FK_IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre");
            return View();
        }

        // POST: Coberturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCobertura,Nombre,FK_IdProducto,Descripcion")] Cobertura cobertura)
        {
            if (ModelState.IsValid)
            {
                db.Cobertura.Add(cobertura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre", cobertura.FK_IdProducto);
            return View(cobertura);
        }

        // GET: Coberturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cobertura cobertura = db.Cobertura.Find(id);
            if (cobertura == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre", cobertura.FK_IdProducto);
            return View(cobertura);
        }

        // POST: Coberturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCobertura,Nombre,FK_IdProducto,Descripcion")] Cobertura cobertura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cobertura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_IdProducto = new SelectList(db.Producto, "IdProducto", "Nombre", cobertura.FK_IdProducto);
            return View(cobertura);
        }

        // GET: Coberturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cobertura cobertura = db.Cobertura.Find(id);
            if (cobertura == null)
            {
                return HttpNotFound();
            }
            return View(cobertura);
        }

        // POST: Coberturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cobertura cobertura = db.Cobertura.Find(id);
            db.Cobertura.Remove(cobertura);
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
