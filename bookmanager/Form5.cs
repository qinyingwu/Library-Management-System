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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                label5.Text = "空值是不能录入的哦！";
                label4.Text = "";
                label6.Text = "";
            }
            else
            {
                string sql = "select * from dbo.chengji where sno='" + textBox1.Text.Trim() + "' and tno='" + Class1.teacher + "'";
                SqlCommand comm = new SqlCommand(sql, sqlConnection1);
                try
                {
                    sqlConnection1.Open();
                    SqlDataReader reader2 = comm.ExecuteReader();
                    reader2.Read();
                    if (!reader2.HasRows)
                    {
                        label4.Text = "您没有教这门课。";
                        label5.Text = "";
                        label6.Text = "";
                        bool1 = false;
                    }
                    else
                    {
                        bool1 = true;
                    }
                    reader2.Close();
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
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "")
            {
                string sqltr2 = "select * from dbo.chengji where sno='" + textBox1.Text.Trim() + "' and usernumber='" + textBox2.Text.Trim() + "'";
                SqlCommand comm2 = new SqlCommand(sqltr2, sqlConnection1);
                try
                {
                    sqlConnection1.Open();
                    SqlDataReader reader1 = comm2.ExecuteReader();
                    reader1.Read();
                    if (reader1.HasRows)
                    {
                        string mn = reader1["score"].ToString().Trim();
                        if (mn != "")
                        {
                            bool1 = false;
                            label6.Text = "该学生成绩已被录入，" + "\n" + "且成绩为" + mn;
                            label4.Text = "";
                            label5.Text = "";
                        }
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
            }
            string sqltr = "update dbo.chengji set score='" + textBox3.Text.Trim() + "' where sno='" + textBox1.Text.Trim() + "' and usernumber='" + textBox2.Text.Trim() + "'";
                SqlCommand comm1 = new SqlCommand(sqltr,sqlConnection1);
                if (bool1)
                {
                    try
                    {
                        sqlConnection1.Open();
                        if (comm1.ExecuteNonQuery()> 0)
                        {
                            label5.Text = "录入成功";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            label4.Text = "";
                            label6.Text = "";
                        }
                        else
                        {
                            label5.Text = "录入失败";
                            label4.Text = "";
                            label6.Text = "";
                            label5.Text = "";
                        }
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

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Class1.f1.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        string teacher;
        Boolean bool1=false;
        private void Form5_Load(object sender, EventArgs e)
        {
            string[] str=new string[10];
            string[] str1 = new string[10];
            for(int n=0;n<str.Length;n++)
                str[n]="";
            string sql = "select * from dbo.teacher where tno='"+Class1.teacher+"'";
            SqlCommand comm = new SqlCommand(sql,sqlConnection1);
            try
            {
                sqlConnection1.Open();
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                teacher = reader["name"].ToString().Trim();
                textBox6.Text = reader["tno"].ToString().Trim();
                textBox7.Text = teacher;
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
            string sql1 = "select * from dbo.chengji where tno='j0009'";
            SqlCommand comm1 = new SqlCommand(sql1, sqlConnection1);
            try
            {
                int l = 0;
                sqlConnection1.Open();
                SqlDataReader reader1=comm1.ExecuteReader();
                reader1.Read();
                    str[l] = reader1["sno"].ToString().Trim();
                    label17.Text= str1[l];
                    l++;
               
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
            /*for (int k = 0; k < str.Length; k++)
            {
                if (str[k] != "")
                {
                    string sql3 = "select cout(*) from dbo.chengji where sno='" + str[k] + "'";
                    SqlCommand comm3 = new SqlCommand(sql3, sqlConnection1);
                    try
                    {
                        sqlConnection1.Open();
                        SqlDataReader reader3 = comm3.ExecuteReader();
                        reader3.Read();
                        if (reader3.HasRows)
                        {
                            str1[k] = comm3.ExecuteScalar().ToString();
                        }
                        reader3.Close();
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
            for (int k = 0; k < str.Length; k++)
            {
                if (str[k] != "")
                {
                    string sql2 = "select * from dbo.subject where sno='"+str[k]+"'";
                    SqlCommand comm2 = new SqlCommand(sql2, sqlConnection1);
                    try
                    {
                        int l = 0;
                        sqlConnection1.Open();
                        SqlDataReader reader2 = comm2.ExecuteReader();
                        reader2.Read();
                        if (reader2.HasRows)
                        {
                            while (reader2.Read())
                            {
                                Class1.lab4[l] = new Label();
                                Class1.lab4[l].AutoSize = false;
                                Class1.lab4[l].Size = new System.Drawing.Size(252, 50);
                                Class1.lab4[l].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                                //Class1.lab4[l].Text = reader2["name"].ToString().Trim() + "\n" + str[l] + "\n" + str1[l];
                                this.flowLayoutPanel1.Controls.Add(Class1.lab4[l]);
                                l++;
                            }
                        }
                        reader2.Close();
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
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqltr2 = "select * from dbo.chengji where sno='" + textBox4.Text.Trim() + "' and usernumber='" + textBox5.Text.Trim() + "'";
            SqlCommand comm2 = new SqlCommand(sqltr2, sqlConnection1);
            try
            {
                sqlConnection1.Open();
                SqlDataReader reader1 = comm2.ExecuteReader();
                reader1.Read();
                if (reader1.HasRows)
                {
                    string mn = reader1["score"].ToString().Trim();
                    if (mn != "")
                    {
                        label9.Text = "学号为" + textBox5.Text.Trim() + "的学生成绩为" + mn;
                    }
                    else
                    {
                        label9.Text = "学号为" + textBox5.Text.Trim() + "的学生成绩还未录入";
                    }
                }
                else
                {
                    label9.Text = "没有该学生！";
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
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "select * from dbo.registrant where usernumber='" + textBox5.Text.Trim() + "'";
            SqlCommand comm = new SqlCommand(sql,sqlConnection1);
            try
            {
                sqlConnection1.Open();
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    label9.Text = "该学生学号为" + reader["usernumber"].ToString().Trim() + "\n" + "姓名为" + reader["username"].ToString().Trim() + "\n" + "性别为" + reader["sex"].ToString().Trim() + "\n" + "年龄为" + reader["age"].ToString().Trim() + "\n" + "电话号码为" + reader["phone"].ToString().Trim() + "\n" + "宿舍楼" + reader["department"].ToString().Trim() + "\n" + "所在班级" + reader["major"].ToString().Trim() + reader["class"].ToString().Trim();
                }
                else
                {
                    label9.Text = "没有该学生！";
                }
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

        private void button5_Click(object sender, EventArgs e)
        {
            string sql = "update dbo.teacher set passwords='"+textBox8.Text.Trim()+"' where tno='"+Class1.teacher+"'";
            SqlCommand comm = new SqlCommand(sql,sqlConnection1);
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

        private void button6_Click(object sender, EventArgs e)
        {
            button5.Enabled = true;
            textBox8.Enabled = true;
        }
    }
}
