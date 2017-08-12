using IShareMVCFinal.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IShareMVCFinal.DB;
using IShareMVCFinal.Models.ViewModels;

namespace IShareMVCFinal.DAO
{
    public class LikeDAO
    {
        public static void Create(Like like)
        {
            if (!CheckIfLikeExists(like))
            {
                var db = MyDB.GetInstance();
                var sql =
                    string.Format("INSERT INTO Likes VALUES ('{0}', '{1}')", like.UserId, like.NoteId);
                db.ExecuteSql(sql);
            }
            else
            {
                //dislike functionality 
                Delete(like);
            }
        }

        public static bool CheckIfLikeExists(Like like)
        {
            var db = MyDB.GetInstance();
            var sql =
                string.Format("SELECT * FROM Likes WHERE userId = '{0}' AND noteId = {1}", like.UserId, like.NoteId);
            var result = db.ExecuteSelectSql(sql);
            if (result.HasRows)
            {
                return true; 
            }
            return false; 
        }

        public static void Delete(Like like)
        {
            var db = MyDB.GetInstance();
            var sql =
                string.Format("DELETE FROM Likes WHERE userId = '{0}' AND noteId = '{1}'", like.UserId, like.NoteId);
            db.ExecuteSql(sql);
        }

        public static List<NoteViewModel> GetLikedPostsByUser(int id)
        {
            var list = new List<NoteViewModel>();
            var db = MyDB.GetInstance();
            var sql = String.Format("SELECT noteId FROM Likes WHERE userId = '{0}'", id);
            var results = db.ExecuteSelectSql(sql);
            
            while (results.Read())
            {
                var likedNotes = new NoteViewModel
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

                list.Add(likedNotes);
            }
            return list;
        }

    }
}