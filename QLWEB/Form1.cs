using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLWEB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void quaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLBV f1 = new frmQLBV();
            f1.Show();
        }

        private void quảnLýNgườiĐọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQLND f2 = new frmQLND();
            f2.Show();
        }
    }
}
