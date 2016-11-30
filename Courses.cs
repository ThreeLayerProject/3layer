using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Objects
{
    public class Courses
    {
	private int _ID;
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
	private int _CourseID;
        public int CourseID
        {
            get
            {
                return _CourseID;
            }
            set
            {
                _CourseID = value;
            }
        }
	private int _TrainID;
        public int TrainID
        {
            get
            {
                return _TrainID;
            }
            set
            {
                _TrainID = value;
            }
        }
	private string _CourseName;
        public string CourseName
        {
            get
            {
                return _CourseName;
            }
            set
            {
                _CourseName = value;
            }
        }
	private string _ProfessorName;
        public string ProfessorName
        {
            get
            {
                return _ProfessorName;
            }
            set
            {
                _ProfessorName = value;
            }
        }
	private DateTime _ClassTime;
        public DateTime ClassTime
        {
            get
            {
                return _ClassTime;
            }
            set
            {
                _ClassTime = value;
            }
        }
       
    }
}

