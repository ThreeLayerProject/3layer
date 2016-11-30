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
    public partial class Logins : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            List<Objects.Logins> lsp = DataAccess.DBLogins.GetAllLogins("SELECT * FROM Logins");
            if (lsp==null)
            {
                Logins Myobject1=new Logins();
                Myobject1.Username="admin";
                Myobject1.Password="admin";
                DBLogins.INSERTLogins(Myobject1);
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            List<Objects.Logins> lsp = DBLogins.GetAllLogins("SELECT * FROM Logins WHERE Username='" + txtUsername.Text +"' And Password='" + txtPassword.Text +"'", "");
            if (lsp != null && lsp.Count > 0)
            {
                this.Hide();
                Main main = new Main();
                main.ShowDialog();
                this.Close();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("نام کاربری یا کلمه عبور اشتباه است           .","خطا",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
