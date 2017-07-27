using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IShareMVCFinal.Models.Tables
{
    public class Note
    {
        public int NoteId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime Uploaded { get; set; }
    }
}