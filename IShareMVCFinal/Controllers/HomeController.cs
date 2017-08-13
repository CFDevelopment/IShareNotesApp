using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IShareMVCFinal.DAO;
using IShareMVCFinal.Models.Tables;
using IShareMVCFinal.Models.ViewModels;

namespace IShareMVCFinal.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult LoginValidate(string UserName, string Password)
        {
            var user = UserDAO.GetUser(UserName, Password);
            var usernameExist = UserDAO.UsernameExists(UserName);

            if (user != null) //username and psss are correct, login success
            {
                var cookie = new HttpCookie("UserID", user.Id.ToString());
                Response.AppendCookie(cookie);
            }

            if (usernameExist) //passwod wrong, go to login page retry.
            {
                return RedirectToAction("Index", "Home");
            }

            // username does not exist, ask user to sign up.
            return RedirectToAction("Register", "Users");
        }


        public ActionResult Login()
        {
            return View();
        }
        
        public ActionResult Index()
        {
            var cookieId = Request.Cookies["userId"];
            if (cookieId == null)
            {
                return RedirectToAction("Login", "Users");
            }


            string userId = "";

            if (cookieId != null)
            {
                userId = cookieId.Value;
                var user = UserDAO.GetUser(int.Parse(userId));
                var noteList = NoteDAO.GetNotes();
                var likedList = NoteDAO.GetLikedPosts(user.Id);
                var repostedist = NoteDAO.GetRepostedNotes(user.Id);
                var originalPosts = NoteDAO.GetOriginalPosts(user.Id);             
                //  list of items they have not deleted to populate
                var like = new Like();
                var author = new User();
                var repost = new Note();
                
                var likeItem = new LikeViewModel
                {
                    UserItem = user,
                    Author = author,
                    LikedItem = like, //should be list of Like 
                    Repost = repost,
                    NoteList = noteList,
                    LikedList = likedList,                   
                    RepostedNotes = repostedist,
                    OriginalNotes = originalPosts
                };
                            
                return View(likeItem);
            }
            return RedirectToAction("Login","Users");
        }

        public ActionResult ParseNews()
        {
            return View();
        }


        public ActionResult LogOut()
        {
            HttpCookie cookie = ControllerContext.HttpContext.Request.Cookies["userId"];
            cookie.Expires = DateTime.Now.AddDays(-1);
            ControllerContext.HttpContext.Response.Cookies.Add(cookie);

            return RedirectToAction("Login", "Users");
        }

    }
}