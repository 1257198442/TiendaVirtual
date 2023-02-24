using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual;

namespace TiendaVirtual.Controllers
{
    public class ComprasController : Controller
    {
        private TiendaEntities1 db = new TiendaEntities1();

        // GET: Compras
        public ActionResult Index()
        {
            var compras = db.Compras.Include(c => c.Producto);
            return View(compras.ToList());
        }

        // GET: Compras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: Compras/Create
        public ActionResult Create()
        {
            ViewBag.ProductoId = new SelectList(db.Productoes, "Id", "name");
            return View();
        }

        // POST: Compras/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,compradoQuantity,ProductoId")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Compras.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductoId = new SelectList(db.Productoes, "Id", "name", compra.ProductoId);
            return View(compra);
        }
        public ActionResult AddProducto(int productoId, int compradoQuantity) {
            if (db.Compras.Any(item => item.ProductoId == productoId))
            {
                var compra = db.Compras.Where(item => item.ProductoId == productoId).ToList()[0];
                compra.compradoQuantity = compra.compradoQuantity+1;
                if (compra.compradoQuantity > db.Productoes.Find(compra.ProductoId).Stock.stockQuantity)
                {
                    compra.compradoQuantity = db.Productoes.Find(compra.ProductoId).Stock.stockQuantity;
                }
                compra.compradoProductoAmount = compra.compradoQuantity * db.Productoes.Find(productoId).price;
                db.Entry(compra).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else { 
            Compra compra = new Compra();
            compra.ProductoId = productoId;
            compra.compradoQuantity = compradoQuantity;
            compra.compradoProductoAmount = compradoQuantity * db.Productoes.Find(productoId).price;
            db.Compras.Add(compra);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            
        }


        // GET: Compras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductoId = new SelectList(db.Productoes, "Id", "name", compra.ProductoId);
            return View(compra);
        }

        // POST: Compras/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,compradoQuantity,ProductoId")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                if (compra.compradoQuantity > db.Productoes.Find(compra.ProductoId).Stock.stockQuantity) {
                    compra.compradoQuantity = db.Productoes.Find(compra.ProductoId).Stock.stockQuantity;
                }
                compra.compradoProductoAmount = compra.compradoQuantity * db.Productoes.Find(compra.ProductoId).price;
                
                db.Entry(compra).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductoId = new SelectList(db.Productoes, "Id", "name", compra.ProductoId);
            return View(compra);
        }

        // GET: Compras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compra compra = db.Compras.Find(id);
            db.Compras.Remove(compra);
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
