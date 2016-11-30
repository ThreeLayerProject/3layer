using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Objects;

namespace DataAccess
{
    public static class DBLogins
    
{
        static SqlConnection GetSqlConnection()
        {
            string Mycon = "server=.;database=DBentekhab;integrated security=true";
            SqlConnection cn = new SqlConnection(Mycon);
            return cn;
        }
        static public List<Logins> GetAllLogins(string strSQL)
        {
            List<Logins> result = null;
            Logins OneObject = null;

            SqlConnection cn = GetSqlConnection();
            cn.Open();

            SqlCommand Mycmd = new SqlCommand(strSQL, cn);

            IDataReader Dreader = Mycmd.ExecuteReader();
            while (Dreader.Read())
            {
                OneObject = new Logins();
                if (Dreader["ID"] != DBNull.Value)
                    OneObject.ID =int.Parse(Dreader["ID"].ToString());
                if (Dreader["Username"] != DBNull.Value)
                    OneObject.Username =Dreader["Username"].ToString();
                if (Dreader["Password"] != DBNull.Value)
                    OneObject.Password = Dreader["Password"].ToString();


                if (result == null) result = new List<Logins>();
                result.Add(OneObject);
            }

            cn.Close();
            cn.Dispose();
            return result;
        }

        static public int INSERTLogins(Logins Object)
        {
            int result = -1;

            SqlConnection cn = GetSqlConnection();
            cn.Open();

            string sqlQuery = "INSERT INTO Logins (Username, Password)";
            sqlQuery += " VALUES (@Username, @Password)";


            SqlCommand Mycmd = new SqlCommand(sqlQuery, cn);

            Mycmd.Parameters.AddWithValue("@Username", SqlDbType.NVarChar).Value = Object.Username;
            Mycmd.Parameters.AddWithValue("@Password", SqlDbType.NVarChar).Value = Object.Password;

            result = Mycmd.ExecuteNonQuery();


            cn.Close();
            cn.Dispose();
            return result;
        }

    }
}