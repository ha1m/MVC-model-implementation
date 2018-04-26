using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using networkProj.Models;
using networkProj.Dal;
using networkProj.ViewModel;
using System.Data.Entity;
using System.Threading;
using System.Web.UI;

namespace networkProj.Controllers
{
    public class PagesController : Controller
    {
        public static int userid;
        public static int c;
        public static Boolean existProd;

        public ActionResult mainPage()
        {
            return View();
        }

        //return login page
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        //the function check if some user is registerd
        //if true, add the user to DB
        //else showing message
        public ActionResult ifRegisterd(User usr)
        {     
            //server side validation
            if (ModelState.IsValid)
            {
                using (MVCprojectEntities1 ue = new MVCprojectEntities1())
                {
                    //checking in DB
                    var log = ue.Users.Where(a => a.usrName.Equals(usr.usrName) && a.password.Equals(usr.password) && a.status.Equals("admin")).FirstOrDefault();

                    if (log!=null)
                    {
                        Session["username"] = log.usrName;
                        return RedirectToAction("managerOption", "Manager");
                    }
                    else
                        { log = ue.Users.Where(a => a.usrName.Equals(usr.usrName) && a.password.Equals(usr.password) && a.status.Equals("user")).FirstOrDefault(); }

                    if (log != null)
                    {
                        userid = log.uid;
                        Session["username"] = log.usrName;
                        return RedirectToAction("PlForUser");
                    }
                    else
                        ViewBag.Message = "Invaild User Name Or Password, Please Try Again";
                }
            }
            return View("login");
        }

        //this function showing specipiec view for registerd user
        //showing the products in web site
        public ActionResult PlForUser()
        {
            if(existProd)
            {
                ViewBag.Message = "Invaild Product id, Please insert available id";
                existProd = false;
            }

            //create data accsess layer
            ProductsDal pd = new ProductsDal();
            OrdersDal od = new OrdersDal();
            List<Product> objProducts = pd.Products.ToList<Product>();
            List<Orders> objOrders = od.Order.ToList<Orders>();

            VM pvm = new VM();
            pvm.products = objProducts;
            c = pvm.products.Count();
            pvm.orders = objOrders;

            return View(pvm);
        }

        //showing specifiec view for guest users
        //showing the products in web site
        public ActionResult productsList()
        {
            ProductsDal pd = new ProductsDal();
            List<Product> objProducts = pd.Products.ToList<Product>();
            VM pvm = new VM();
            pvm.products = objProducts;
            return View(pvm);
        }

        //adding order user to order table in DB
        [HttpPost]
        public ActionResult addOrderToDB(VM vm)
        {
            string pid = Request["pid"];
            vm.order = new Orders
            {
                pid = int.Parse(pid),
                uid = userid
            };
            if (ModelState.IsValid && vm.order.pid > 0 && vm.order.pid <= c)
            {
                //will be adding user to DB
                OrdersDal dal2 = new OrdersDal();
                dal2.Order.Add(vm.order);                
                dal2.SaveChanges();

                return View("login");
            }
            else
            {
                existProd = true;

                return RedirectToAction("PlForUser");
            }
  
        }
    }
}