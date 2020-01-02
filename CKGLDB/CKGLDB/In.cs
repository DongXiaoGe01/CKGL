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
    public partial class In : Form
    {
        public In()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)//单号
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)//供应商编号
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)//货物号
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)//数量
        {

        }

        private void In_Load(object sender, EventArgs e)
        {

        }
        private void textBox5_TextChanged(object sender, EventArgs e)//金额
        {

        }
        private void textBox6_TextChanged(object sender, EventArgs e)//日期
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//刷新
        {
            try
            {
                string ConStr = "server=DESKTOP-PV2RSHT;database=CKGL;Trusted_Connection=SSPI";
                SqlConnection conn = new SqlConnection(ConStr);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    string sql = "select * from Intable";
                    SqlCommand sc = new SqlCommand(sql, conn);
                    SqlDataAdapter sda = new SqlDataAdapter(sc);
                    DataSet ds = new DataSet();
                    sda.Fill(ds, "表名");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "表名";
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string ConStr = "server=DESKTOP-PV2RSHT;database=CKGL;Trusted_Connection=SSPI";
                SqlConnection conn = new SqlConnection(ConStr);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    string sql = "insert into Intable (in_no,supplier_no,hw_no,in_num,in_money,in_date) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";//编号
                    SqlCommand cmd = conn.CreateCommand();//创建数据库命令
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    int x = int.Parse(textBox4.Text);//增加的数字

                    sql = string.Format("Select hw_num from HW where hw_no='{0}'", textBox3.Text);
                    SqlCommand command = new SqlCommand(sql, conn);//执行操作
                    object obj = command.ExecuteScalar(); 
                    int now = (int)obj;
                    now += x;

                    //更新HW表
                    sql = string.Format("update HW set hw_num = '{0}' where hw_no = '{1}'",now.ToString(),textBox3.Text);
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    conn.Dispose();
                    MessageBox.Show("添加成功");
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
