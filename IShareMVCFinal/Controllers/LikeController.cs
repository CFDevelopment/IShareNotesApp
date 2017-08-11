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
  
    public class LikeController : Controller
    {
        [HttpPost]
        public ActionResult Add(Like like)
        {            
            LikeDAO.Create(like);
            return View();
        }
    }
}