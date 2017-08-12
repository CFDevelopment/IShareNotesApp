using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IShareMVCFinal.Models.ViewModels
{
    public class AccountViewModel
    {
        public List<NoteViewModel> LikedNotes { get; set; }
        public List<NoteViewModel> OriginalNotes { get; set; }
        public List<NoteViewModel> RepostedNotes { get; set; }
    }
}