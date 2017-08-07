using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IShareMVCFinal.Models.Tables;

namespace IShareMVCFinal.Models.ViewModels
{
    public class TagNoteViewModel
    {
        public List<Tag> TagItem { get; set; }
        public Note NoteItem { get; set; }
    }
}