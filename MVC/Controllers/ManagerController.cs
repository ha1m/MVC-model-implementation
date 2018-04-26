using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using networkProj.ViewModel;
using networkProj.Models;
using networkProj.Dal;
using networkProj.ModelBinders;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Threading;

namespace networkProj.Controllers
{
    public class ManagerController : Controller
    {
        public ActionResult managerOption()
        {
            return View();
        }

        public ActionResult getUserList()
        {
            //load all users from DB and represent them
            //if click on "Done" button in the view will be back to managerOption view
            UserDal ud = new UserDal();
            List<User> objUsers = ud.Users.ToList<User>();
            VM uvm = new VM();
            uvm.users = objUsers;

            return View(uvm);
        }

        //showing enter products view using view model
        public ActionResult EnterProducts()
        {
            ProductsDal pd = new ProductsDal();
            List<Product> objProducts = pd.Products.ToList<Product>();
            VM pvm = new VM();
            pvm.products = objProducts;

            return View(pvm);
        }

        //showing product using by jason method
        public ActionResult ShowProductsByJson()
        {
            ProductsDal pd = new ProductsDal();
            List<Product> objProducts = pd.Products.ToList<Product>();

            return Json(objProducts, JsonRequestBehavior.AllowGet);
        }

        //will be adding product to DB && using model binders to pass data correctly
        [HttpPost]
        public ActionResult addProduct([ModelBinder(typeof(ProductBinder))] Product prod)
        {
            ProductsDal dal1 = new ProductsDal();

            if (ModelState.IsValid)
            {
                dal1.Products.Add(prod);
                dal1.SaveChanges();
            }
            List<Product> objProducts = dal1.Products.ToList<Product>();

            return Json(objProducts, JsonRequestBehavior.AllowGet);
        }

        //showimg table orders
        public ActionResult DisplayOrders()
        {
            SqlConnection con = new SqlConnection();
            string path = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            con.ConnectionString = path;
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("select * from OrdersDeatails", con);
                adp.Fill(dt);
            }
            catch(Exception) { throw; }

            return View(dt);
        }
    }
}