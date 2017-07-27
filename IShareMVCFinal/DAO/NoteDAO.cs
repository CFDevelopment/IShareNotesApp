using IShareMVCFinal.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IShareMVCFinal.DB;

namespace IShareMVCFinal.DAO
{
    public class NoteDAO
    {
        public static void Create(Note note)
        {
            /*Hardcoded user to 1 for testing sake*/
            var db = MyDB.GetInstance();
            var sql =
                string.Format("INSERT INTO Notes VALUES ('{0}','{1}','{2}','{3}','{4}' )", note.Title, note.Description, 1, DateTime.Now, note.Content);
            db.ExecuteSql(sql);
        }

        public static void Delete(Note note)
        {
            var db = MyDB.GetInstance();
            var sql =
                string.Format("Delete From Notes where noteId = {0}", note.NoteId);
            db.ExecuteSql(sql);
        }

        public static Note GetNote(int id)
        {
            var db = MyDB.GetInstance();
            var sql =
                string.Format("SELECT * FROM Notes WHERE noteId = {0}", id);
            var result = db.ExecuteSelectSql(sql);
            if (result.HasRows)
            {
                result.Read();
                return new Note
                {
                    NoteId = (int)result["noteId"],
                    UserId = (int)result["userId"],
                    Title = result["noteTitle"].ToString(),
                    Description = result["noteDescription"].ToString(),
                    Content = result["noteContent"].ToString(),
                    Uploaded = (DateTime)result["uploaded"]
                };
            }
            return null;
        }
        
    }
}