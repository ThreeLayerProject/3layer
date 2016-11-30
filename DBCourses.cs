using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Objects;

namespace DataAccess
{
    public static class DBCourses
    
{
        static SqlConnection GetSqlConnection()
        {
            string Mycon = "server=.;database=DBentekhab;integrated security=true";
            SqlConnection cn = new SqlConnection(Mycon);
            return cn;
        }
        static public List<Courses> GetAllCourses(string strSQL)
        {
            List<Courses> result = null;
            Courses OneObject = null;

            SqlConnection cn = GetSqlConnection();
            cn.Open();

            SqlCommand Mycmd = new SqlCommand(strSQL, cn);

            IDataReader Dreader = Mycmd.ExecuteReader();
            while (Dreader.Read())
            {
                OneObject = new Courses();
                if (Dreader["ID"] != DBNull.Value)
                    OneObject.ID =int.Parse(Dreader["ID"].ToString());
                if (Dreader["CourseID"] != DBNull.Value)
                    OneObject.CourseID =int.Parse(Dreader["CourseID"].ToString());
                if (Dreader["TrainID"] != DBNull.Value)
                    OneObject.TrainID =int.Parse(Dreader["TrainID"].ToString());
                if (Dreader["CourseName"] != DBNull.Value)
                    OneObject.CourseName = Dreader["CourseName"].ToString();
                if (Dreader["ProfessorName"] != DBNull.Value)
                    OneObject.ProfessorName = Dreader["ProfessorName"].ToString();
                if (Dreader["ClassTime"] != DBNull.Value)
                    OneObject.ClassTime =Convert.ToDateTime(Dreader["ClassTime"].ToString());


                if (result == null) result = new List<Courses>();
                result.Add(OneObject);
            }

            cn.Close();
            cn.Dispose();
            return result;
        }

        static public int INSERTCourses(Courses Object)
        {
            int result = -1;

            SqlConnection cn = GetSqlConnection();
            cn.Open();

            string sqlQuery = "INSERT INTO Courses (CourseID, TrainID, CourseName, ProfessorName, ClassTime)";
            sqlQuery += " VALUES (@CourseID, @TrainID, @CourseName, @ProfessorName, @ClassTime)";


            SqlCommand Mycmd = new SqlCommand(sqlQuery, cn);

            Mycmd.Parameters.AddWithValue("@CourseID", SqlDbType.int).Value = Object.CourseID;
            Mycmd.Parameters.AddWithValue("@TrainID", SqlDbType.int).Value = Object.TrainID;
            Mycmd.Parameters.AddWithValue("@CourseName", SqlDbType.NVarChar).Value = Object.CourseName;
            Mycmd.Parameters.AddWithValue("@ProfessorName", SqlDbType.NVarChar).Value = Object.ProfessorName;
            Mycmd.Parameters.AddWithValue("@ClassTime", SqlDbType.DateTime).Value = Object.ClassTime;

            result = Mycmd.ExecuteNonQuery();


            cn.Close();
            cn.Dispose();
            return result;
        }

    }
}