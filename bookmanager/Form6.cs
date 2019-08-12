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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            string sql = "select * from dbo.manager where mno='" + Class1.teacher1 + "'";
            SqlCommand comm = new SqlCommand(sql, sqlConnection1);
            try
            {
                sqlConnection1.Open();
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                textBox6.Text = Class1.teacher1;
                textBox7.Text = reader["name"].ToString().Trim();
                textBox8.Text = reader["passwords"].ToString();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection1.Close();
            }
            button5.Enabled = false;
            textBox8.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button5.Enabled = true;
            textBox8.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql = "update dbo.manager set passwords='" + textBox8.Text.Trim() + "' where mno='" + Class1.teacher1 + "'";
            SqlCommand comm = new SqlCommand(sql, sqlConnection1);
            try
            {
                sqlConnection1.Open();
                if (comm.ExecuteNonQuery() > 0)
                    MessageBox.Show("修改成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection1.Close();
            }
            button5.Enabled = false;
            textBox8.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Class1.f1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "update dbo.panduan set a='1'";
            SqlCommand comm = new SqlCommand(sql,sqlConnection1);
            try
            {
                sqlConnection1.Open();
                if (comm.ExecuteNonQuery() > 0)
                    MessageBox.Show("选课已经开启！");
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

        private void button7_Click(object sender, EventArgs e)
        {
            string sql = "update dbo.panduan set a='0'";
            SqlCommand comm = new SqlCommand(sql, sqlConnection1);
            try
            {
                sqlConnection1.Open();
                if (comm.ExecuteNonQuery() > 0)
                    MessageBox.Show("选课已经开启！");
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();
        }
    }
}
