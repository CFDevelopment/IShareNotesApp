using IShareMVCFinal.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IShareMVCFinal.Models.ViewModels
{
    public class CreateNoteUserModelView
    {
        public Note NoteItem { get; set; }
        public User UserItem { get; set; }
    }
}