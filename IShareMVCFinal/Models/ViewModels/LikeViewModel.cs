using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IShareMVCFinal.DB;
using IShareMVCFinal.Models.Tables;

namespace IShareMVCFinal.Models.ViewModels
{
    public class LikeViewModel
    {
        public User UserItem { get; set; }
        public User Author { get; set; }
        public List<NoteViewModel> NoteList { get; set; }
        public Like LikedItem { get; set; }
        public List<int> LikedList { get; set; }
        public Note NoteItem { get; set; }

    }
}