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
    public class PedidoesController : Controller
    {
        private TiendaEntities1 db = new TiendaEntities1();

        // GET: Pedidoes
        public ActionResult Index()
        {
            return View(db.Pedidoes.ToList());
        }

        // GET: Pedidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedidoes.Find(id);
            db.Pedidoes.Remove(pedido);
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
        public ActionResult GenerateOrder(double amount) {
            Pedido pedido = new Pedido();
            pedido.amount = amount;
            pedido.time = DateTime.Now;
            db.Pedidoes.Add(pedido);
            foreach (var item in db.Compras) {
                db.Productoes.Find(item.ProductoId).Stock.stockQuantity -= item.compradoQuantity;
            }
            db.Compras.RemoveRange(db.Compras);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
