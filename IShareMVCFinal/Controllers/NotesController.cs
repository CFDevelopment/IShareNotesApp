using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IShareMVCFinal.DAO;
using IShareMVCFinal.Models.Tables;

namespace IShareMVCFinal.Controllers
{
    public class NotesController : Controller
    {
        // GET: Notes
        public ActionResult Index()
        {
            /*User user = new User();
            user.UserName = "Chris";
            user.Password = "Password";
            UserDAO.Create(user); 
            Note note = new Note();
            note.Title = "First Note";
            note.Description = "Blah blah blah";
            note.UserId = 1;
            note.Uploaded = DateTime.Now;
            note.Content = "Longer text";
            NoteDAO.Create(note);
            Tag tag = new Tag();
            tag.Name = "Music";
            TagDAO.Create(tag);
            Note_Tag item = new Note_Tag();
            item.TagId = 1;
            item.NoteId = 2;
            Note_TagDAO.Create(item);
            Like like = new Like();
            like.NoteId = 2;
            like.UserId = 1;
            LikeDAO.Create(like);*/

            var note = NoteDAO.GetNote(2);
            return View(note);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Note note)
        {
            try
            {
                // TODO: Add insert logic here
                NoteDAO.Create(note);
                return RedirectToAction("Display", "Notes", note);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult Display(Note note)
        {
            return View(note);
        }


        public ActionResult FormLayout()
        {
            return View();
        }


    }
}