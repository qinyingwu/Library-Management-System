using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace bookmanager
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        bool bool1 = false;
        string[] a = new string[100];
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                listBox1.Visible = false;
            Regex cn = new Regex("[\u4e00-\u9fa5]+");
            if (cn.IsMatch(textBox1.Text))
            {
                string sql = "select * from dbo.teacher where name like '%" + textBox1.Text + "%'";
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
                    string sql1 = "select * from dbo.teacher where name like '%" + textBox1.Text + "%'";
                    SqlCommand comm1 = new SqlCommand(sql1, sqlConnection1);
                    try
                    {
                        sqlConnection1.Open();
                        SqlDataReader reader1 = comm1.ExecuteReader();
                        while (reader1.Read())
                        {
                            a[j] = reader1["name"].ToString().Trim();
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
                string sql = "select * from dbo.teacher where tno like '%" + textBox1.Text + "%'";
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
                    string sql1 = "select * from dbo.teacher where tno like '%" + textBox1.Text + "%'";
                    SqlCommand comm1 = new SqlCommand(sql1, sqlConnection1);
                    try
                    {
                        sqlConnection1.Open();
                        SqlDataReader reader1 = comm1.ExecuteReader();
                        while (reader1.Read())
                        {
                            a[j] = reader1["tno"].ToString().Trim();
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                Regex cn = new Regex("[\u4e00-\u9fa5]+");
                if (cn.IsMatch(listBox1.SelectedItem.ToString()))
                {
                    string sql = "select * from dbo.teacher where name='" + listBox1.SelectedItem.ToString() + "'";
                    SqlCommand comm = new SqlCommand(sql, sqlConnection1);
                    try
                    {
                        sqlConnection1.Open();
                        SqlDataReader reader = comm.ExecuteReader();
                        reader.Read();
                        label2.Text = "教工号：" + reader["tno"].ToString().Trim() + "\n" + "姓名：" + reader["name"].ToString().Trim() + "\n"  + "电话号码：" + reader["phone"].ToString().Trim() + "\n" + "系别：" + reader["department"].ToString().Trim() + "\n" + "住址：" + reader["classdidian"].ToString().Trim();
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
                    string sql = "select * from dbo.teacher where tno='" + listBox1.SelectedItem.ToString() + "'";
                    SqlCommand comm = new SqlCommand(sql, sqlConnection1);
                    try
                    {
                        sqlConnection1.Open();
                        SqlDataReader reader = comm.ExecuteReader();
                        reader.Read();
                        label2.Text = "教工号：" + reader["tno"].ToString().Trim() + "\n" + "姓名：" + reader["name"].ToString().Trim() + "\n"  + "电话号码：" + reader["phone"].ToString().Trim() + "\n" + "系别：" + reader["department"].ToString().Trim() + "\n" + "住址：" + reader["classdidian"].ToString().Trim();
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
