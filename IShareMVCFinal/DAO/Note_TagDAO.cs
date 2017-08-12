using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IShareMVCFinal.DB;
using IShareMVCFinal.Models.Tables;

namespace IShareMVCFinal.DAO
{
    public class Note_TagDAO
    {
        /*Check if the note already has the tag you are going to give it - don't duplicate*/
        public static void Create(Note_Tag noteTag)
        {
            if (!CheckIfNoteHasTag(noteTag))
            {
                var db = MyDB.GetInstance();
                var sql =
                    string.Format("INSERT INTO Notes_Tags VALUES ('{0}', '{1}')", noteTag.NoteId, noteTag.TagId);
                db.ExecuteSql(sql);
            }
        }

        public static bool CheckIfNoteHasTag(Note_Tag noteTag)
        {
            var db = MyDB.GetInstance();
            var sql =
                string.Format("SELECT * FROM Notes_Tags WHERE noteId = '{0}' AND tagId = '{1}'", noteTag.NoteId, noteTag.TagId);
            var result = db.ExecuteSelectSql(sql);
            if (result.HasRows)
            {
                return true; // true if there is a note with this tag
            }
            return false; //false if there is no tag with this note
        }




    }
}