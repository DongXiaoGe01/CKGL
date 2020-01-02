using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CKGLDB
{
    public partial class Form1 : Form
    {
        string user, pwd;
        public Form1()
        {
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            user = textBox1.Text;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            pwd = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ConStr = "server=DESKTOP-PV2RSHT;database=CKGL;Trusted_Connection=SSPI";
                SqlConnection conn = new SqlConnection(ConStr);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                
                    if (user == "" || pwd == "") {
                        MessageBox.Show("密码和账户不能为空");
                    }
                    string sql = string.Format("select count(*) from Managers where Manage_no='{0}' and Manager_psd='{1}'", user, pwd);//查询是否有该条记录，根据账户密码
                    SqlCommand command = new SqlCommand(sql, conn);
                    int i = Convert.ToInt32(command.ExecuteScalar());
                    if (i > 0)
                    {
                        Form me = new menu();
                        me.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("账户/密码错误");
                    }
                 
                }
                else
                {
                    MessageBox.Show("数据库连接失败");
                }
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }
        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}
