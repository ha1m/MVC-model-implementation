using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using networkProj.Models;
using networkProj.Dal;

namespace networkProj.Controllers
{
    public class UserController : Controller
    {
        //calling to form for registration
        public ActionResult regUser()
        {
            return View(new User());
        }
   
        //this action will cheak if the form is valid so adding object to DB
        [HttpPost]
        public ActionResult addUser(User usr)
        {
            if (ModelState.IsValid)
            {
                //will be adding user to DB
                UserDal dal = new UserDal();
                dal.Users.Add(usr);
                dal.SaveChanges();

                return RedirectToAction("mainPage", "Pages");
            }
            else
                return View("regUser");
        }
    }
}