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
    public class NotesController : Controller
    {
        
        public ActionResult Create()
        {
            var cookieId = Request.Cookies["userId"];
            string userId = "";

            if (cookieId != null)
            {
                userId = cookieId.Value;
                var user = UserDAO.GetUser(int.Parse(userId));
                var note = new Note();
                
                var createItem = new CreateNoteUserModelView
                {
                    UserItem = user,
                    NoteItem = note                   
                };
                return View(createItem);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(Note note)
        {
            try
            {
                // TODO: Add insert logic here
                NoteDAO.Create(note);
                return RedirectToAction("Index", "Home");
                //return RedirectToAction("Display", "Notes", note);
            }
            catch
            {
                return View();
            }
        }

    }
}