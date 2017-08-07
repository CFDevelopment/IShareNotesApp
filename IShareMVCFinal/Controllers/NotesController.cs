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
            
            return View();
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
                return Redirect("Home");
                //return RedirectToAction("Display", "Notes", note);
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