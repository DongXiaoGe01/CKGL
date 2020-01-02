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
    public partial class QueryHW : Form
    {
        public QueryHW()
        {
            InitializeComponent();
        }
        string hwid;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            hwid = textBox1.Text;
        }
        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void QueryHW_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ConStr = "server=DESKTOP-PV2RSHT;database=CKGL;Trusted_Connection=SSPI";
                SqlConnection conn = new SqlConnection(ConStr);
                conn.Open();
                if (conn.State == ConnectionState.Open)//连接到数据库
                {
                    string sql = string.Format("select hw_name from HW where hw_no='{0}'",hwid);//查询货物名字
                    SqlCommand command = new SqlCommand(sql, conn);//执行操作
                    object obj = command.ExecuteScalar();;
                    if (obj != null)
                    {

                        this.textBox2.Text = obj.ToString();
                    }
                    else
                    {
                        MessageBox.Show("输入id有误！！");
                    }
                    obj = null;//清空
                    sql= string.Format("select hw_inprice from HW where hw_no='{0}'", hwid);//查询货物名字
                    command = new SqlCommand(sql, conn);//执行操作
                    obj = command.ExecuteScalar(); ;
                    if (obj != null)
                    {

                        this.textBox3.Text = obj.ToString();
                    }
                    else
                    {
                        MessageBox.Show("输入id有误！！");
                    }
                    obj = null;//清空
                    sql = string.Format("select hw_outprice from HW where hw_no='{0}'", hwid);//查询货物名字
                    command = new SqlCommand(sql, conn);//执行操作
                    obj = command.ExecuteScalar(); ;
                    if (obj != null)
                    {

                        this.textBox4.Text = obj.ToString();
                    }
                    else
                    {
                        MessageBox.Show("输入id有误！！");
                    }
                    obj = null;//清空
                    sql = string.Format("select hw_num from HW where hw_no='{0}'", hwid);//查询货物名字
                    command = new SqlCommand(sql, conn);//执行操作
                    obj = command.ExecuteScalar(); ;
                    if (obj != null)
                    {

                        this.textBox5.Text = obj.ToString();
                    }
                    else
                    {
                        MessageBox.Show("输入id有误！！");
                    }
                    conn.Close();
                    conn.Dispose();
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
