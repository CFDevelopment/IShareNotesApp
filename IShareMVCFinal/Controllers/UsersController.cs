using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IShareMVCFinal.DAO;
using IShareMVCFinal.Models.Tables;

namespace IShareMVCFinal.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }
              
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            UserDAO.Create(user);
            return Redirect("Login");
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var activeUser = UserDAO.GetUser(user);
            if (activeUser != null)
            {
                var userCookie = new HttpCookie("userId", activeUser.Id.ToString());
                Response.AppendCookie(userCookie);
                return RedirectToAction("Index", "Home");
            }
            return Redirect("Login");
        }

        public ActionResult Account()
        {
            return View();
        }    
    }
}