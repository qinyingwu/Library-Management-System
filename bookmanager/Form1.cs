using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace bookmanager
{
    public partial class Form1 : Form
    {
        public static string username1;
        public static string passwords1;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string passwords = textBox2.Text.Trim();
            string sqltr = "select count(*) from dbo.userland where usernumber='" + username + "' and userpasswords='"+passwords+"'";
            SqlCommand comm = new SqlCommand(sqltr,sqlConnection1);
            try
            {
                sqlConnection1.Open();
                int a = (int)comm.ExecuteScalar();
                if (a == 1)
                {
                    Form2 f2 = new Form2();
                    username1 = username;
                    passwords1 = passwords;
                    f2.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("登录失败");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection1.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Class1.f1 = this;
        }
  
        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select count(*) from dbo.teacher where tno='"+textBox1.Text.Trim()+"' and passwords='"+textBox2.Text.Trim()+"'";
            SqlCommand comm = new SqlCommand(sql,sqlConnection1);
            try
            {
                sqlConnection1.Open();
                int a = (int)comm.ExecuteScalar();
                if (a == 1)
                {
                    Class1.teacher = textBox1.Text.Trim();
                    Form5 f5 = new Form5();
                    f5.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("登录失败");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection1.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "select count(*) from dbo.manager where mno='" + textBox1.Text.Trim() + "' and passwords='" + textBox2.Text.Trim() + "'";
            SqlCommand comm = new SqlCommand(sql, sqlConnection1);
            try
            {
                sqlConnection1.Open();
                int a = (int)comm.ExecuteScalar();
                if (a == 1)
                {
                    Class1.teacher1 = textBox1.Text.Trim();
                    Form6 f6 = new Form6();
                    f6.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("登录失败");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection1.Close();
            }
        }
    }
}
