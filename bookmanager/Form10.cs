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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

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
                string sql = "select * from dbo.subject where name like '%" + textBox1.Text + "%'";
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
                    string sql1 = "select * from dbo.subject where name like '%" + textBox1.Text + "%'";
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
                string sql = "select * from dbo.subject where sno like '%" + textBox1.Text + "%'";
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
                    string sql1 = "select * from dbo.subject where sno like '%" + textBox1.Text + "%'";
                    SqlCommand comm1 = new SqlCommand(sql1, sqlConnection1);
                    try
                    {
                        sqlConnection1.Open();
                        SqlDataReader reader1 = comm1.ExecuteReader();
                        while (reader1.Read())
                        {
                            a[j] = reader1["sno"].ToString().Trim();
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
                    string sql = "select * from dbo.subject where name='" + listBox1.SelectedItem.ToString() + "'";
                    SqlCommand comm = new SqlCommand(sql, sqlConnection1);
                    try
                    {
                        sqlConnection1.Open();
                        SqlDataReader reader = comm.ExecuteReader();
                        reader.Read();
                        label2.Text = "课程号：" + reader["sno"].ToString().Trim() + "\n" + "名字：" + reader["name"].ToString().Trim() + "\n"  + "课容量：" + reader["maxstudent"].ToString().Trim() + "\n" + "老师：" + reader["teacher"].ToString().Trim() + "\n" + "地点：" + reader["classdidian"].ToString().Trim()+"\n"+"上课时间："+reader["classtime"]+"\n"+ "上课周次：" + reader["classzhouci"].ToString().Trim() + "\n" + "学时：" + reader["classxueshi"].ToString().Trim() + "\n" + "课程属性：" + reader["shuxing"].ToString().Trim() + "\n"+ "学分：" + reader["creditscore"].ToString().Trim() + "\n"  ;
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
                    string sql = "select * from dbo.subject where sno='" + listBox1.SelectedItem.ToString() + "'";
                    SqlCommand comm = new SqlCommand(sql, sqlConnection1);
                    try
                    {
                        sqlConnection1.Open();
                        SqlDataReader reader = comm.ExecuteReader();
                        reader.Read();
                        label2.Text = "课程号：" + reader["sno"].ToString().Trim() + "\n" + "名字：" + reader["name"].ToString().Trim() + "\n"  + "课容量：" + reader["maxstudent"].ToString().Trim() + "\n" + "老师：" + reader["teacher"].ToString().Trim() + "\n" + "地点：" + reader["classdidian"].ToString().Trim()+"\n"+"上课时间："+reader["classtime"]+"\n"+ "上课周次：" + reader["classzhouci"].ToString().Trim() + "\n" + "学时：" + reader["classxueshi"].ToString().Trim() + "\n" + "课程属性：" + reader["shuxing"].ToString().Trim() + "\n"+ "学分：" + reader["creditscore"].ToString().Trim() + "\n"  ;
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
