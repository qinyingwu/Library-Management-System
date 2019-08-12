using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace bookmanager
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.username1;
            button1.Enabled = false;
            textBox3.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() != Form1.passwords1)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                label6.Text = "密码错误！";
                label7.Text = "";
                textBox3.Focus();
            }
            else
                label6.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
            {
                if (textBox3.Text.Trim() == Form1.passwords1 && textBox1.Text.Trim() == textBox2.Text.Trim())
                {
                    button1.Enabled = true;
                    label7.Text = "";
                }
                else
                {
                    label7.Text = "密码不一致！";
                    button1.Enabled = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = label2.Text.Trim();
            string passwords = textBox1.Text.Trim();
            string sqltr = "update dbo.userland set userpasswords='" + passwords + "' where usernumber='"+username+"'";
            SqlCommand comm = new SqlCommand(sqltr,sqlConnection1);
            try
            {
                sqlConnection1.Open();
                if (comm.ExecuteNonQuery() == 1)
                    MessageBox.Show("修改成功！");
                else
                    MessageBox.Show("修改失败！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection1.Close();
            }
            button1.Enabled = false;
        }
    }
}
