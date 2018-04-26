using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using networkProj.Models;

namespace networkProj.ModelBinders
{
    public class ProductBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpContextBase objC = controllerContext.HttpContext;

            string pmanufacturer = objC.Request.Form["product.manufacturer"];
            string pmodel = objC.Request.Form["product.model"];
            string pcategory = objC.Request.Form["product.category"];
            string pprice = objC.Request.Form["product.price"];
            string pdiscount = objC.Request.Form["product.discount"];

            Product obj = new Product()
            {
                manufacturer = pmanufacturer,
                model = pmodel,
                category = pcategory,
                price = int.Parse(pprice),
                discount = int.Parse(pdiscount)
            };

            return obj;
        }
    }
}