using IShareMVCFinal.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IShareMVCFinal.Models.ViewModels
{
    public class NoteUserViewModel
    {
        public User AuthorItem { get; set; }
        public Note NoteItem { get; set; }
    }
}