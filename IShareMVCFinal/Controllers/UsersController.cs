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
                var userCookie = new HttpCookie("userId", activeUser.Id.ToString());
                Response.AppendCookie(userCookie);
                return RedirectToAction("Index", "Home");
            }
            return Redirect("Login");
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            UserDAO.Create(user);
            return Redirect("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        /*Pass ID of NoteId you select & RETURN User who wrote it*/
        public ActionResult GetAuthor(User user)
        {
           // var x = UserDAO.GetUser(user.Id);
           // var authorCookie = new HttpCookie("authorName", x.UserName);
           // Response.AppendCookie(authorCookie);
            return View();
        }
    }
}