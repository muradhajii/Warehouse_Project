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
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            categoryform cf = new categoryform();
            cf.Show();
            this.Hide();
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

        private void btnGoods_Click(object sender, EventArgs e)
        {
            goodsform gf = new goodsform();
            gf.Show();
            this.Hide();
        }

        private void btnCategory_Click_1(object sender, EventArgs e)
        {
            categoryform cf = new categoryform();
            cf.Show();
            this.Hide();
        }

        private void btnGoods_Click_1(object sender, EventArgs e)
        {
            goodsform gf = new goodsform();
            gf.Show();
            this.Hide();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            statisticsform sf = new statisticsform();
            sf.Show();
            this.Hide();
        }
    }
}
