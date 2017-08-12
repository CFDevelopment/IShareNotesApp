using IShareMVCFinal.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IShareMVCFinal.DB;
using IShareMVCFinal.Models.ViewModels;

namespace IShareMVCFinal.DAO
{
    public class NoteDAO
    {
        public static void Create(Note note)
        {
            /*Hardcoded user to 1 for testing sake*/
            var db = MyDB.GetInstance();
            var sql =
                string.Format("INSERT INTO Notes VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}' )", note.Title, note.Description, note.UserId, DateTime.Now, note.Content, note.OriginalAuthor, note.TagList);
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
            var results = db.ExecuteSelectSql(sql);
            if (results.HasRows)
            {
                results.Read();
                return new Note
                {
                    NoteId = (int)results["noteId"],
                    UserId = (int)results["userId"],
                    Title = results["noteTitle"].ToString(),
                    Description = results["noteDescription"].ToString(),
                    Content = results["noteContent"].ToString(),
                    Uploaded = (DateTime)results["uploaded"],
                    OriginalAuthor = (int)results["originalAuthor"],
                    TagList = results["tagList"].ToString()
                };
            }
            return null;
        }

        public static List<NoteViewModel> GetNotes()
        {
            var list = new List<NoteViewModel>();
            var db = MyDB.GetInstance();
            var sql = string.Format("select * from Notes n join Users u ON n.userId = u.userId");

            var results = db.ExecuteSelectSql(sql);

            while (results.Read())
            {
                var noteViewModel = new NoteViewModel
                {
                    NoteId = (int)results["noteId"],
                    UserId = (int)results["userId"],
                    UserName = results["userName"].ToString(),
                    Title = results["noteTitle"].ToString(),
                    Description = results["noteDescription"].ToString(),
                    Content = results["noteContent"].ToString(),
                    Uploaded = (DateTime)results["uploaded"],
                    OriginalAuthor = (int)results["originalAuthor"],
                    TagList = results["tagList"].ToString()
                };
                list.Add(noteViewModel);
            }
            return list;
        }

        public static List<NoteViewModel> GetRepostedNotes(int id)
        {
            var list = new List<NoteViewModel>();
            var db = MyDB.GetInstance();
            var sql = string.Format("SELECT * FROM Notes n JOIN Users u ON n.userId = u.userId WHERE n.userId = '{0}' AND n.userId != '{1}'", id, id);

            var results = db.ExecuteSelectSql(sql);

            while (results.Read())
            {
                var noteViewModel = new NoteViewModel
                {
                    NoteId = (int)results["noteId"],
                    UserId = (int)results["userId"],
                    UserName = results["userName"].ToString(),
                    Title = results["noteTitle"].ToString(),
                    Description = results["noteDescription"].ToString(),
                    Content = results["noteContent"].ToString(),
                    Uploaded = (DateTime)results["uploaded"],
                    OriginalAuthor = (int)results["originalAuthor"],
                    TagList = results["tagList"].ToString()
                };
                list.Add(noteViewModel);
            }
            return list;
        }

        public static List<NoteViewModel> GetOriginalPosts(int id)
        {
            var list = new List<NoteViewModel>();
            var db = MyDB.GetInstance();
            var sql = string.Format("select * from Notes n join Users u ON n.userId = u.userId WHERE n.userId = '{0}' AND n.userId = '{1}'", id, id);

            var results = db.ExecuteSelectSql(sql);

            while (results.Read())
            {
                var noteViewModel = new NoteViewModel
                {
                    NoteId = (int)results["noteId"],
                    UserId = (int)results["userId"],
                    UserName = results["userName"].ToString(),
                    Title = results["noteTitle"].ToString(),
                    Description = results["noteDescription"].ToString(),
                    Content = results["noteContent"].ToString(),
                    Uploaded = (DateTime)results["uploaded"],
                    OriginalAuthor = (int)results["originalAuthor"],
                    TagList = results["tagList"].ToString()
                };
                list.Add(noteViewModel);
            }
            return list;
        }

        public static List<NoteViewModel> GetLikedPosts(int id)
        {
            var list = new List<NoteViewModel>();
            var db = MyDB.GetInstance();
            var sql = string.Format("select * from Notes n join Likes l on n.noteId = l.noteId join Users u on u.userId = n.userId where l.userId = '{0}'", id);

            var results = db.ExecuteSelectSql(sql);

            while (results.Read())
            {
                var noteViewModel = new NoteViewModel
                {
                    NoteId = (int)results["noteId"],
                    UserId = (int)results["userId"],
                    UserName = results["userName"].ToString(),
                    Title = results["noteTitle"].ToString(),
                    Description = results["noteDescription"].ToString(),
                    Content = results["noteContent"].ToString(),
                    Uploaded = (DateTime)results["uploaded"],
                    OriginalAuthor = (int)results["originalAuthor"],
                    TagList = results["tagList"].ToString()
                };
                list.Add(noteViewModel);
            }
            return list;
        }


    }
}