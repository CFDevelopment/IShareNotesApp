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
            var cookieId = Request.Cookies["userId"];
            string userId = "";

            if (cookieId != null)
            {
                userId = cookieId.Value;
                var user = UserDAO.GetUser(int.Parse(userId));
                var likedList = NoteDAO.GetLikedPosts(user.Id);
                var repostedist = NoteDAO.GetRepostedNotes(user.Id);
                var originalPosts = NoteDAO.GetOriginalPosts(user.Id);
                
                var accountViewItem = new AccountViewModel
                {
                    LikedNotes = likedList,
                    RepostedNotes = repostedist,
                    OriginalNotes = originalPosts            
                };

                return View(accountViewItem);
            } 
              
            return View();
        }


        public ActionResult AllUsers()
        {
            var users = UserDAO.GetUsers();
            return View(users);
        }


        public ActionResult UserAccount(int id)
        {
            if (id != 0)
            {
                var user = UserDAO.GetUser(id);
                var likedList = NoteDAO.GetLikedPosts(user.Id);
                var repostedist = NoteDAO.GetRepostedNotes(user.Id);
                var originalPosts = NoteDAO.GetOriginalPosts(user.Id);

                var accountViewItem = new AccountViewModel
                {
                    LikedNotes = likedList,
                    RepostedNotes = repostedist,
                    OriginalNotes = originalPosts
                };

                return View(accountViewItem);
            }

            return View();
        }




    }
}