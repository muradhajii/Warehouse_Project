using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse_Project
{
    public partial class loginform : Form
    {
        public loginform()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Red;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Warehouse_ProjectEntities1 wh = new Warehouse_ProjectEntities1();
            var login = from x in wh.admin
                        where x.username == txtUsername.Text && x.password == txtPassword.Text
                        select x;
            if (login.Any())
            {
                mainform mf = new mainform();
                mf.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong username or password!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
