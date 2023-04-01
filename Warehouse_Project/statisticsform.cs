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
    public partial class statisticsform : Form
    {
        public statisticsform()
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

        Warehouse_ProjectEntities1 wh = new Warehouse_ProjectEntities1();
        private void statisticsform_Load(object sender, EventArgs e)
        {
            lblcategory.Text = wh.category.Count().ToString();
            lblgoods.Text = wh.goods.Count().ToString();
            lblbrands.Text = (from x in wh.goods select x.brand).Distinct().Count().ToString();
            lblstocks.Text = wh.goods.Sum(x => x.stock).ToString();
            lblcash.Text = wh.sale.Sum(x => x.price).ToString()+"$";
            lblexpensive.Text = (from x in wh.goods orderby x.price descending select x.g_name + "=" + x.price + "$").FirstOrDefault();
            lblcheap.Text = (from x in wh.goods orderby x.price ascending select x.g_name + "=" + x.price + "$").FirstOrDefault();
        }
    }
}
