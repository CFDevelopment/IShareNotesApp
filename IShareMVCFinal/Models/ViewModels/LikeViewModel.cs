using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IShareMVCFinal.Models.Tables;

namespace IShareMVCFinal.Models.ViewModels
{
    public class LikeViewModel
    {
        public User UserItem { get; set; }
        public List<Note> NoteList { get; set; }
        public Like LikedItem { get; set; }
    }
}