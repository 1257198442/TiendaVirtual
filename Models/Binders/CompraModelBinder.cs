using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaVirtual.Models.Binders
{
    public class CompraModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            Compra cc = (controllerContext.HttpContext.Session != null) ?
                (controllerContext.HttpContext.Session["key_cc"] as Compra) :
                 null;

            if (cc == null)
            {
                cc = new Compra();
                controllerContext.HttpContext.Session["key_cc"] = cc;
            }

            return cc;
        }
    }
}