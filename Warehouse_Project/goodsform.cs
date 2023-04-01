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
    public partial class goodsform : Form
    {
        public goodsform()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            mainform mf = new mainform();
            mf.Show();
            this.Close();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Red;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void btnList_MouseHover(object sender, EventArgs e)
        {
            btnList.BackColor = Color.White;
        }

        private void btnList_MouseLeave(object sender, EventArgs e)
        {
            btnList.BackColor = Color.Transparent;
        }

        private void btnAdd_MouseHover(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.White;
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.Transparent;
        }

        private void btnDelete_MouseHover(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.White;
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Transparent;
        }

        private void btnUpdate_MouseHover(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.White;
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.Transparent;
        }

        Warehouse_ProjectEntities1 wh = new Warehouse_ProjectEntities1();
        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in wh.goods
                                        select new
                                        {
                                            x.ID,
                                            x.g_name,
                                            x.brand,
                                            x.stock,
                                            x.price,
                                            x.status,
                                            x.category1.cname
                                        }).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtbID.Focus();

            goods g = new goods();

            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                g.g_name = txtbName.Text;
                g.brand = txtbBrand.Text;
                g.stock = int.Parse(txtbStock.Text);
                g.price = decimal.Parse(txtbPrice.Text);
                g.status = true;
                g.category = int.Parse(cmbCategory.SelectedValue.ToString());
                wh.goods.Add(g);
                wh.SaveChanges();
                MessageBox.Show("Good added", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (dialogResult == DialogResult.No)
            {
                txtbID.Text = "";
                txtbName.Text = "";
                txtbStock.Text = "";
                txtbPrice.Text = "";
                txtbStatus.Text = "";
                cmbCategory.Text = "";
                txtbBrand.Text = "";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtbID.Focus();

            int x = Convert.ToInt32(txtbID.Text);
            var good = wh.goods.Find(x);
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                wh.goods.Remove(good);
                wh.SaveChanges();
                MessageBox.Show("Good deleted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dialogResult == DialogResult.No)
            {
                txtbID.Text = "";
                txtbName.Text = "";
                txtbStock.Text = "";
                txtbPrice.Text = "";
                txtbStatus.Text = "";
                cmbCategory.Text = "";
                txtbBrand.Text = "";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtbID.Focus();

            int x = Convert.ToInt32(txtbID.Text);
            var good = wh.goods.Find(x);
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                good.g_name = txtbName.Text;
                good.brand = txtbBrand.Text;
                good.stock = int.Parse(txtbStock.Text);
                wh.SaveChanges();
                MessageBox.Show("Good updated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dialogResult == DialogResult.No)
            {
                txtbID.Text = "";
                txtbName.Text = "";
                txtbStock.Text = "";
                txtbPrice.Text = "";
                txtbStatus.Text = "";
                cmbCategory.Text = "";
                txtbBrand.Text = "";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtbID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtbName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtbBrand.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtbStock.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtbPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtbStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            cmbCategory.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void goodsform_Load(object sender, EventArgs e)
        {
            var category = (from x in wh.category
                            select new
                            {
                                x.ID,
                                x.cname
                            }).ToList();
            cmbCategory.ValueMember = "ID";
            cmbCategory.DisplayMember = "cname";
            cmbCategory.DataSource = category;
        }
    }
}
