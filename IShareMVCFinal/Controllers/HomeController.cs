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
        public ActionResult Index()
        {
            var cookieId = Request.Cookies["userId"];
            string userId = "";

            if (cookieId != null)
            {
                userId = cookieId.Value;
                var user = UserDAO.GetUser(int.Parse(userId));
                var noteList = NoteDAO.GetNotes();
                var likedList = LikeDAO.GetLikedPostsByUser(user.Id);
                var like = new Like();

                //note list should be the ones they dont delete
                //select * notes where user like them
                //return the note id, list of id

                var likeItem = new LikeViewModel
                {
                    UserItem = user,
                    NoteList = noteList,
                    LikedList = likedList,
                    LikedItem = like
                };
                            
                return View(likeItem);
            }

            return View();
        }

        public ActionResult TestHome()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /* Test to add users to add notes */
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User user)
        {
            UserDAO.Create(user);
            return Redirect("Index");

        }

    }
}