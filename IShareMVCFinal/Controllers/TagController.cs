using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IShareMVCFinal.DAO;
using IShareMVCFinal.Models.Tables;

namespace IShareMVCFinal.Controllers
{
    public class TagController : Controller
    {
        [HttpPost]
        // GET: Tag
        public ActionResult Index(string tag)
        {
            return Content(tag);
        }

        [HttpPost]
        public ActionResult Create(string tag)
        {
            //Tag newTag = new Tag(); //should have an overload where you pass in string text
           // newTag.Name = tag;
            //string n = tag.name;
            
            //TagDAO.Test();
            return Content(tag);
        }
    }
}