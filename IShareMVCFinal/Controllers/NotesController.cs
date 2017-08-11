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
             
                NoteDAO.Create(note);
                //get tags
                var tagList = note.TagList;
                char[] delimiter = {' '};                
                string[] tags = tagList.Split(delimiter);

               foreach (var tag in tags)
                {
                    if(tag != null || tag != "")
                    {
                        var t = new Tag
                        {
                            Name = tag
                        };
                        TagDAO.Create(t);
                    }                 
                }
                
                //return JavaScript("window.location = '" + Url.Action("Index", "Home") + "'");
               return RedirectToAction("Index", "Home");             
            }
            catch
            {
                return RedirectToAction("Index", "Home");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

    }
}