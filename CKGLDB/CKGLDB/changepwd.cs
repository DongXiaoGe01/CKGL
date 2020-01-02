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
    public partial class changepwd : Form
    {
        public changepwd()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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
                    string user = textBox4.Text;
                    string oldpwd = textBox1.Text;
                    string n1pwd = textBox2.Text;
                    string n2pwd = textBox3.Text;
                    if (user == "" || oldpwd == "")
                    {
                        MessageBox.Show("密码和账户不能为空");
                    }
                    string sql = string.Format("select count(*) from Managers where Manage_no='{0}' and Manager_psd='{1}'", user, oldpwd);//查询是否有该条记录，根据账户密码
                    SqlCommand command = new SqlCommand(sql, conn);
                    int i = Convert.ToInt32(command.ExecuteScalar());
                    if (i > 0)
                    {
                        if (n1pwd != n2pwd)
                        {
                            MessageBox.Show("输入不一致");
                        }
                        else
                        {
                            sql = string.Format("update Managers set Manager_psd = '{0}' where Manage_no = '{1}'", n1pwd, user);
                            SqlCommand cmd = conn.CreateCommand();
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("修改成功");
                        }
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
    }
}
