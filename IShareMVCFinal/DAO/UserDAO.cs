using IShareMVCFinal.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IShareMVCFinal.DB;

namespace IShareMVCFinal.DAO
{
    public class UserDAO
    {
        public static void Create(User user)
        {
            var db = MyDB.GetInstance();
            var sql =
                string.Format("INSERT INTO Users VALUES ('{0}','{1}')", user.UserName, user.Password);
            db.ExecuteSql(sql);
        }

    }
}