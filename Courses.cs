using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Objects;
using DataAccess;

namespace Entekhab
{
    public partial class Courses : Form
    {
        Courses Objects;
        public Course()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if(txtCourseID.Text!="" && txtCourseName.Text!="" && TrainID.Text!="")
            {
                Fillobject();
                DBCourses.INSERTCourses(Objects);
            }
            else
            {
                MessageBox.Show("اطلاعات را تکمیل نمایید.","خطا");
            }
        }
        private Fillobject()
        {
               Objects=new Courses();
               Objects.CourseID=int.Parse(txtCourseID.Text);
               Objects.TrainID=int.Parse(TrainID.Text);
               Objects.CourseName=txtCourseName.Text;
               Objects.ClassTime=Convert.ToDateTime(ClassTime.Text);
               Objects.ProfessorName=ProfessorName.Text;

        }
    }
}
