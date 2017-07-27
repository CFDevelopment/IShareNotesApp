using IShareMVCFinal.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IShareMVCFinal.DB;


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
    }
}