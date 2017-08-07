using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IShareMVCFinal.DB;
using IShareMVCFinal.Models.Tables;

namespace IShareMVCFinal.DAO
{
    public class TagDAO
    {
        /*CheckTagExists Makes sure that you don't already have the tag in the databaseso you don't duplicate tags..*/
        /*WE ARE GOING TO PUT ALL TAGS IN LOWER CASE IN THE DATABASE - FOR SEARCHING PURPOSES*/
     
        public static void Create(Tag tag)
        {
            if (!CheckTagExists(tag))
            {
                var db = MyDB.GetInstance();
                var sql =
                    string.Format("INSERT INTO Tags VALUES ('{0}')", tag.Name.ToLower());
                db.ExecuteSql(sql);            
            }
        }

        public static bool CheckTagExists(Tag tag)
        {
            var db = MyDB.GetInstance();
            var sql =
                string.Format("SELECT * FROM Tags WHERE tagName = '{0}'", tag.Name.ToLower());
            var result = db.ExecuteSelectSql(sql);
            if (result.HasRows)
            {
                return true; //return true if there is a matching tag - aka dont create it again
            }
            return false; //return false if no tag matches in database
        }

        //return list of notes where tagName
       
    }
}