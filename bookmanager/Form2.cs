using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace bookmanager
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string[] a=new string[9];
        string[,] xuhao=new string[8,6];
        private void Form2_Load(object sender, EventArgs e)
        {
            bool b1 = false;
            string sqltr7 = "select * from dbo.registrant where usernumber='" + Form1.username1 + "'";
            SqlCommand comm7 = new SqlCommand(sqltr7,sqlConnection1);
            try
            {
                sqlConnection1.Open();
                SqlDataReader reader7 = comm7.ExecuteReader();
                reader7.Read();
                textBox1.Text = reader7["username"].ToString().Trim();
                textBox8.Text = reader7["class"].ToString().Trim();
                textBox2.Text = reader7["age"].ToString().Trim();
                textBox4.Text = reader7["department"].ToString().Trim();
                textBox6.Text = reader7["major"].ToString().Trim();
                textBox3.Text = reader7["sex"].ToString().Trim();
                textBox5.Text = reader7["phone"].ToString().Trim();
                textBox7.Text = Form1.username1;
                if (reader7["shifou"].ToString().Trim() == "1")
                    b1 = true;
                reader7.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection1.Close();
            }
            if (b1)
                button3.Enabled = false;
            Class1.btn[1, 1] = this.label16;
            Class1.btn[1, 2] = this.label23;
            Class1.btn[1, 3] = this.label30;
            Class1.btn[1, 4] = this.label37;
            Class1.btn[1, 5] = this.label44;
            Class1.btn[2, 1] = this.label15;
            Class1.btn[2, 2] = this.label22;
            Class1.btn[2, 3] = this.label29;
            Class1.btn[2, 4] = this.label36;
            Class1.btn[2, 5] = this.label43;
            Class1.btn[3, 1] = this.label14;
            Class1.btn[3, 2] = this.label21;
            Class1.btn[3, 3] = this.label28;
            Class1.btn[3, 4] = this.label35;
            Class1.btn[3, 5] = this.label42;
            Class1.btn[4, 1] = this.label13;
            Class1.btn[4, 2] = this.label20;
            Class1.btn[4, 3] = this.label27;
            Class1.btn[4, 4] = this.label34;
            Class1.btn[4, 5] = this.label41;
            Class1.btn[5, 1] = this.label12;
            Class1.btn[5, 2] = this.label19;
            Class1.btn[5, 3] = this.label26;
            Class1.btn[5, 4] = this.label33;
            Class1.btn[5, 5] = this.label40;
            Class1.btn[6, 1] = this.label11;
            Class1.btn[6, 2] = this.label18;
            Class1.btn[6, 3] = this.label25;
            Class1.btn[6, 4] = this.label32;
            Class1.btn[6, 5] = this.label39;
            Class1.btn[7, 1] = this.label10;
            Class1.btn[7, 2] = this.label17;
            Class1.btn[7, 3] = this.label24;
            Class1.btn[7, 4] = this.label31;
            Class1.btn[7, 5] = this.label38;
            string sqltr = "select * from dbo.oldchoose where usernumber='"+Form1.username1+"'";
            SqlCommand comm = new SqlCommand(sqltr,sqlConnection1);
            try
            {
                sqlConnection1.Open();
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                int b = (int)reader["number"];
                for (int i = 0; i < b; i++)
                {
                    a[i] = reader.GetValue(i + 2).ToString();
                    
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection1.Close();
            }
            
            for (int k = 0; k < a.Length; k++)
            {
                if (a[k] != null)
                {
                    string p = a[k].Trim();
                    string sqltr1 = "select * from dbo.subject where sno='" + p + "'";
                    SqlCommand comm1 = new SqlCommand(sqltr1, sqlConnection1);
                    try
                    {
                        sqlConnection1.Open();
                        SqlDataReader reader1 = comm1.ExecuteReader();
                        reader1.Read();
                        string d = reader1.GetValue(1).ToString().Trim();
                        string q = reader1.GetValue(0).ToString().Trim();
                        string b = (string)reader1["classtime"];
                        string c = b.Trim();
                        int[] time1 = new int[10];
                        int j = 0;
                        for (int i = 0; i < 10; i++)
                            time1[i] = 0;
                        char[] time = c.ToCharArray();
                        for (int n = 0; n < time.Length; n++)
                        {
                            try
                            {
                                string l = "" + time[n];
                                time1[j] = int.Parse(l);
                                j++;
                            }
                            catch
                            {

                            }
                        }
                        for (int i = 0; i < 6; i = i + 2)
                        {
                            if (time1[i] != 0 && time1[i + 1] != 0)
                            {
                                Class1.btn[time1[i], time1[i + 1]].Text = d;
                                xuhao[time1[i], time1[i + 1]] = q;
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
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Class1.f1.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }
        private void xinxi(string mn,Label k)
        {
            if (mn != null)
            {
                string sqltr2 = "select * from dbo.subject where sno='" + mn + "'";
                SqlCommand comm = new SqlCommand(sqltr2, sqlConnection1);
                try
                {
                    sqlConnection1.Open();
                    SqlDataReader reader = comm.ExecuteReader();
                    reader.Read();
                    string ad = reader["sno"].ToString().Trim() + "\n" + reader["name"].ToString().Trim() + "(" + reader["shuxing"].ToString().Trim() + ")" + "\n" + reader["teacher"].ToString().Trim() + "\n" + reader["classdidian"].ToString().Trim() + "(" + reader["maxstudent"].ToString().Trim() + ")" + "\n" + reader["classzhouci"].ToString().Trim() + "上";
                    this.toolTip1.SetToolTip(k, ad);
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

        private void label16_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[1, 1], Class1.btn[1, 1]);
        }

        private void label15_MouseHover_1(object sender, EventArgs e)
        {
            xinxi(xuhao[2, 1], Class1.btn[2, 1]);
        }

        private void label14_MouseHover_1(object sender, EventArgs e)
        {
            xinxi(xuhao[3, 1], Class1.btn[3, 1]);
        }

        private void label13_MouseHover_1(object sender, EventArgs e)
        {
            xinxi(xuhao[4, 1], Class1.btn[4, 1]);
        }

        private void label12_MouseHover_1(object sender, EventArgs e)
        {
            xinxi(xuhao[5, 1], Class1.btn[5, 1]);
        }

        private void label11_MouseHover_1(object sender, EventArgs e)
        {
            xinxi(xuhao[6, 1], Class1.btn[6, 1]);
        }

        private void label10_MouseHover_1(object sender, EventArgs e)
        {
            xinxi(xuhao[7, 1], Class1.btn[7, 1]);
        }

        private void label23_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[1, 2], Class1.btn[1, 2]);
        }

        private void label22_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[2,2], Class1.btn[2,2]);
        }

        private void label21_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[3,2], Class1.btn[3,2]);
        }

        private void label20_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[4,2], Class1.btn[4,2]);
        }

        private void label19_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[5,2], Class1.btn[5,2]);
        }

        private void label18_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[6,2], Class1.btn[6,2]);
        }

        private void label17_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[7,2], Class1.btn[7,2]);
        }

        private void label30_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[1,3], Class1.btn[1,3]);
        }

        private void label29_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[2,3], Class1.btn[2,3]);
        }

        private void label28_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[3, 3], Class1.btn[3, 3]);
        }

        private void label27_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[4,3], Class1.btn[4,3]);
        }

        private void label26_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[5,3], Class1.btn[5,3]);
        }

        private void label25_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[6,3], Class1.btn[6,3]);
        }

        private void label24_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[7,3], Class1.btn[7,3]);
        }

        private void label37_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[1,4], Class1.btn[1,4]);
        }

        private void label36_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[2,4], Class1.btn[2,4]);
        }

        private void label35_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[3,4], Class1.btn[3,4]);
        }

        private void label34_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[4, 4], Class1.btn[4, 4]);
        }

        private void label33_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[5,4], Class1.btn[5,4]);
        }

        private void label32_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[6,4], Class1.btn[6,4]);
        }

        private void label31_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[7,4], Class1.btn[7,4]);
        }

        private void label44_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[1,5], Class1.btn[1,5]);
        }

        private void label43_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[2,5], Class1.btn[2,5]);
        }

        private void label42_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[3,5], Class1.btn[3,5]);
        }

        private void label41_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[4,5], Class1.btn[4,5]);
        }

        private void label40_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[5, 5], Class1.btn[5, 5]);
        }

        private void label39_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[6,5], Class1.btn[6,5]);
        }

        private void label38_MouseHover(object sender, EventArgs e)
        {
            xinxi(xuhao[7,5], Class1.btn[7,5]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 =new Form4();
            f4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
        }
    }
}
