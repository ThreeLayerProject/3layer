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
    public partial class Students : Form
    {
        Students Objects;
        public Student()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if(txtStudentID.Text!="" && txtStudentName.Text!="" && TrainID.Text!="")
            {
                Fillobject();
                DBStudents.INSERTStudents(Objects);
            }
            else
            {
                MessageBox.Show("اطلاعات را تکمیل نمایید.","خطا");
            }
        }
        private Fillobject()
        {
               Objects=new Students();
               Objects.StudentID=txtStudentID.Text;
               Objects.StudentName=txtStudentName.Text;
               Objects.StudentFamily=txtStudentFamily.Text;
               Objects.StudentPhone=txtStudentPhone.Text;
               Objects.StudentAddress=txtStudentAddress.Text;
               Objects.StudentGender=txtStudentGender.Text;
               Objects.TrainID=int.Parse(TrainID.Text);
        }
    }
}
