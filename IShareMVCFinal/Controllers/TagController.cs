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
    public class TagController : Controller
    {
       
        [HttpPost]
        public ActionResult Create(Tag tag)
        {          
            TagDAO.Create(tag);            
            return Content("lol");
        }
    }
}