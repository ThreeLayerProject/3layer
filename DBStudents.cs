using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Objects;

namespace DataAccess
{
    public static class DBStudents
    
{
        static SqlConnection GetSqlConnection()
        {
            string Mycon = "server=.;database=DBentekhab;integrated security=true";
            SqlConnection cn = new SqlConnection(Mycon);
            return cn;
        }
        static public List<Students> GetAllStudents(string strSQL)
        {
            List<Students> result = null;
            Students OneObject = null;

            SqlConnection cn = GetSqlConnection();
            cn.Open();

            SqlCommand Mycmd = new SqlCommand(strSQL, cn);

            IDataReader Dreader = Mycmd.ExecuteReader();
            while (Dreader.Read())
            {
                OneObject = new Students();
                if (Dreader["ID"] != DBNull.Value)
                    OneObject.ID =int.Parse(Dreader["ID"].ToString());
                if (Dreader["StudentID"] != DBNull.Value)
                    OneObject.StudentID =Dreader["StudentID"].ToString();
                if (Dreader["StudentName"] != DBNull.Value)
                    OneObject.StudentName = Dreader["StudentName"].ToString();
                if (Dreader["StudentFamily"] != DBNull.Value)
                    OneObject.StudentFamily = Dreader["StudentFamily"].ToString();
                if (Dreader["StudentPhone"] != DBNull.Value)
                    OneObject.StudentPhone = Dreader["StudentPhone"].ToString();
                if (Dreader["StudentAddress"] != DBNull.Value)
                    OneObject.StudentAddress =int.Parse(Dreader["StudentAddress"].ToString());
                 if (Dreader["StudentGender"] != DBNull.Value)
                    OneObject.StudentGender =int.Parse(Dreader["StudentGender"].ToString());
                if (Dreader["TrainID"] != DBNull.Value)
                    OneObject.TrainID =int.Parse(Dreader["TrainID"].ToString());

                if (result == null) result = new List<Students>();
                result.Add(OneObject);
            }

            cn.Close();
            cn.Dispose();
            return result;
        }

        static public int INSERTStudents(Students Object)
        {
            int result = -1;

            SqlConnection cn = GetSqlConnection();
            cn.Open();

            string sqlQuery = "INSERT INTO Students (StudentID, StudentName, StudentFamily, StudentPhone, StudentAddress, StudentGender, TrainID)";
            sqlQuery += " VALUES (@StudentID, @StudentName, @StudentFamily, @StudentPhone, @StudentAddress, @StudentGender, @TrainID)";


            SqlCommand Mycmd = new SqlCommand(sqlQuery, cn);

            Mycmd.Parameters.AddWithValue("@StudentID", SqlDbType.NVarChar).Value = Object.StudentID;
            Mycmd.Parameters.AddWithValue("@StudentName", SqlDbType.NVarChar).Value = Object.StudentName;
            Mycmd.Parameters.AddWithValue("@StudentFamily", SqlDbType.NVarChar).Value = Object.StudentFamily;
            Mycmd.Parameters.AddWithValue("@StudentPhone", SqlDbType.NVarChar).Value = Object.StudentPhone;
            Mycmd.Parameters.AddWithValue("@StudentAddress", SqlDbType.NVarChar).Value = Object.StudentAddress;
            Mycmd.Parameters.AddWithValue("@StudentGender", SqlDbType.NVarChar).Value = Object.StudentGender;
            Mycmd.Parameters.AddWithValue("@TrainID", SqlDbType.Int).Value = Object.TrainID;

            result = Mycmd.ExecuteNonQuery();


            cn.Close();
            cn.Dispose();
            return result;
        }

    }
}