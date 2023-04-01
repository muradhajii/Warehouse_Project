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
    public partial class categoryform : Form
    {
        public categoryform()
        {
            InitializeComponent();
        }

        Warehouse_ProjectEntities1 wh = new Warehouse_ProjectEntities1();
        private void btnList_Click(object sender, EventArgs e)
        {
            txtbID.Text = "";
            txtbname.Text = "";

            txtbID.Focus();

            var category = wh.category.ToList();
            dataGridView1.DataSource = category;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            mainform mf = new mainform();
            mf.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtbID.Focus();

            category c = new category();

            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                c.cname = txtbname.Text;
                wh.category.Add(c);
                wh.SaveChanges();
            }
            else if (dialogResult == DialogResult.No)
            {
                txtbname.Text = "";
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Red;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtbID.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtbID.Focus();

            int x = Convert.ToInt32(txtbID.Text);

            var c = wh.category.Find(x);

            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                wh.category.Remove(c);
                wh.SaveChanges();
                MessageBox.Show("Deleted!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(dialogResult == DialogResult.No)
            {
                txtbID.Text = "";
                txtbname.Text = "";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtbID.Focus();

            int x = Convert.ToInt32(txtbID.Text);

            var c = wh.category.Find(x);

            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                c.cname = txtbname.Text;
                wh.SaveChanges();
                MessageBox.Show("Updated!","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else if(dialogResult == DialogResult.No)
            {
                txtbname.Text = "";
                txtbID.Text = "";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtbname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnList_MouseHover(object sender, EventArgs e)
        {
            btnList.BackColor = Color.White;
        }

        private void btnList_MouseLeave(object sender, EventArgs e)
        {
            btnList.BackColor = Color.Transparent;
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.White;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Transparent;
        }

        private void btnAdd_MouseHover(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.White;
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.Transparent;
        }

        private void btnUpdate_MouseHover(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.White;
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.Transparent;
        }
    }
}
