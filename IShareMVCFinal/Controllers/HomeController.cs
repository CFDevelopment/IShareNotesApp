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

        public ActionResult Login()
        {
            return View();
        }
        
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
                var author = new User();

                //note list should be the ones they dont delete
                //select * notes where user like them
                //return the note id, list of id

                var likeItem = new LikeViewModel
                {
                    UserItem = user,
                    NoteList = noteList,
                    LikedList = likedList,
                    Author = author,
                    LikedItem = like
                };
                            
                return View(likeItem);
            }

            return View();
        }

    }
}