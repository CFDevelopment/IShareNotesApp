using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IShareMVCFinal.Models.ViewModels
{
    public class NoteViewModel
    {
        public int NoteId { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public int OriginalAuthor { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime Uploaded { get; set; }
        public string TagList { get; set; }
    }
}