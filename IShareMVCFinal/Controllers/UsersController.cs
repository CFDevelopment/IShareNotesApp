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
        // GET: Users
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var activeUser = UserDAO.GetUser(user);
            if (activeUser != null)
            {
                return Redirect("Register");
            }

            return View();
        }
        
        public ActionResult Register()
        {
            return View();
        }

    }
}