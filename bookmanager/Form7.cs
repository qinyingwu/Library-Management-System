using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace bookmanager
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        bool bool1 = false;
        string[] a=new string[100];
        private void Form7_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                listBox1.Visible = false;
            Regex cn = new Regex("[\u4e00-\u9fa5]+");
            if (cn.IsMatch(textBox1.Text))
            {
                string sql = "select * from dbo.registrant where username like '%" + textBox1.Text + "%'";
                SqlCommand comm = new SqlCommand(sql, sqlConnection1);
                try
                {
                    sqlConnection1.Open();
                    SqlDataReader reader = comm.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                        bool1 = true;
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
                if (bool1 == true && textBox1.Text != "")
                {
                    int j = 0;
                    string sql1 = "select * from dbo.registrant where username like '%" + textBox1.Text + "%'";
                    SqlCommand comm1 = new SqlCommand(sql1, sqlConnection1);
                    try
                    {
                        sqlConnection1.Open();
                        SqlDataReader reader1 = comm1.ExecuteReader();
                        while (reader1.Read())
                        {
                            a[j] = reader1["username"].ToString().Trim();
                            j++;
                        }
                        reader1.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        sqlConnection1.Close();
                    }
                    listBox1.Items.Clear();
                    for (int m = 0; m < j; m++)
                        listBox1.Items.Add(a[m]);
                    listBox1.Visible = true;
                    label2.Visible = false;
                }
                else
                {
                    listBox1.Visible = false;
                }
            }
            else
            {
                string sql = "select * from dbo.registrant where usernumber like '%" + textBox1.Text + "%'";
                SqlCommand comm = new SqlCommand(sql, sqlConnection1);
                try
                {
                    sqlConnection1.Open();
                    SqlDataReader reader = comm.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                        bool1 = true;
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
                if (bool1 == true && textBox1.Text!="")
                {
                    int j = 0;
                    string sql1 = "select * from dbo.registrant where usernumber like '%" + textBox1.Text + "%'";
                    SqlCommand comm1 = new SqlCommand(sql1, sqlConnection1);
                    try
                    {
                        sqlConnection1.Open();
                        SqlDataReader reader1 = comm1.ExecuteReader();
                        while (reader1.Read())
                        {
                            a[j] = reader1["usernumber"].ToString().Trim();
                            j++;
                        }
                        reader1.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        sqlConnection1.Close();
                    }
                    listBox1.Items.Clear();
                    for (int m = 0; m < j; m++)
                        listBox1.Items.Add(a[m]);
                    listBox1.Visible = true;
                    label2.Visible = false;
                }
            }
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                Regex cn = new Regex("[\u4e00-\u9fa5]+");
                if (cn.IsMatch(listBox1.SelectedItem.ToString()))
                {
                    string pq;
                    string sql = "select * from dbo.registrant where username='" + listBox1.SelectedItem.ToString() + "'";
                    SqlCommand comm = new SqlCommand(sql, sqlConnection1);
                    try
                    {
                        sqlConnection1.Open();
                        SqlDataReader reader = comm.ExecuteReader();
                        reader.Read();
                        if (reader["shifou"].ToString().Trim() == "1")
                            pq = "已经选课";
                        else
                            pq = "还未选课";
                        label2.Text = "学号：" + reader["usernumber"].ToString().Trim() + "\n" + "姓名：" + reader["username"].ToString().Trim() + "\n" + "性别：" + reader["sex"].ToString().Trim() + "\n" + "年龄：" + reader["age"].ToString().Trim() + "\n" + "电话号码：" + reader["phone"].ToString().Trim() + "\n" + "宿舍：" + reader["department"].ToString().Trim() + "\n" + "系别：" + reader["major"].ToString().Trim() + "\n" + "选课情况：" + pq;
                        label2.Visible = true;
                        listBox1.Visible = false;
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
                }
                else
                {
                    string pq;
                    string sql = "select * from dbo.registrant where usernumber='" + listBox1.SelectedItem.ToString() + "'";
                    SqlCommand comm = new SqlCommand(sql, sqlConnection1);
                    try
                    {
                        sqlConnection1.Open();
                        SqlDataReader reader = comm.ExecuteReader();
                        reader.Read();
                        if (reader["shifou"].ToString().Trim() == "1")
                            pq = "已经选课";
                        else
                            pq = "还未选课";
                        label2.Text = "学号：" + reader["usernumber"].ToString().Trim() + "\n" + "姓名：" + reader["username"].ToString().Trim() + "\n" + "性别：" + reader["sex"].ToString().Trim() + "\n" + "年龄：" + reader["age"].ToString().Trim() + "\n" + "电话号码：" + reader["phone"].ToString().Trim() + "\n" + "宿舍：" + reader["department"].ToString().Trim() + "\n" + "系别：" + reader["major"].ToString().Trim() + "\n" + "选课情况：" + pq;
                        label2.Visible = true;
                        listBox1.Visible = false;
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
                }
            }
        }
    }
}
