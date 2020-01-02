using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CKGLDB
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form que = new QueryHW();
            que.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form ins = new In();
            ins.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form outts = new outtable();
            outts.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form cg = new changepwd();
            cg.Show();
        }
    }
}
