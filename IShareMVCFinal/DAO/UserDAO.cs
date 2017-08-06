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

        public static User GetUser(User user)
        {            
            var db = MyDB.GetInstance();
            var sql =
                string.Format("SELECT * FROM Users WHERE userName = '{0}' AND userPassword = '{1}'", user.UserName, user.Password);
            var result = db.ExecuteSelectSql(sql);
            if (result.HasRows)
            {
                result.Read();
                return new User
                {
                    Id = (int)result["userId"],
                    UserName = result["userName"].ToString(),
                    Password = result["userPassword"].ToString()                   
                };
            }
            return null;
        }

        public static User GetUser(int id)
        {
            var db = MyDB.GetInstance();
            var sql =
                string.Format("SELECT * FROM Users WHERE userId = '{0}'", id);
            var result = db.ExecuteSelectSql(sql);
            if (result.HasRows)
            {
                result.Read();
                return new User
                {
                    Id = (int)result["userId"],
                    UserName = result["userName"].ToString(),
                    Password = result["userPassword"].ToString()
                };
            }
            return null;
        }


    }
}