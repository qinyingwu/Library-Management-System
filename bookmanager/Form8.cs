using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace bookmanager
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        string[] a=new string[25];
        string[] b=new string[25];
        string[] c=new string[25];
        string[] d = new string[25];
        int m = 0;
        int n = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from dbo.subject where sno='"+textBox1.Text.Trim()+"'";
            SqlCommand comm = new SqlCommand(sql,sqlConnection1);
            try
            {
                sqlConnection1.Open();
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    label1.Text = reader["sno"].ToString().Trim() + "\n" + reader["name"].ToString().Trim() + "\n" + reader["teacher"].ToString().Trim();
                    button2.Visible = true;
                    button2.Enabled = true;
                    a[m] = reader["name"].ToString().Trim();
                    b[m] = reader["teacher"].ToString().Trim();
                    c[m] = reader["sno"].ToString().Trim();
                    d[m] = reader["classtime"].ToString().Trim();
                    m++;
                }
                else
                {
                    label1.Text = "没有该课程！";
                    button2.Visible = false;
                    button2.Enabled = false;
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

        private void button2_Click(object sender, EventArgs e)
        {
            bool b1 = true;
            int k = 0;
            int[] time1=new int[6];
            for (int i = 0; i < 6; i++)
                time1[i] = 0;
            string[] p=new string[3];
            for (int i = 0; i < 3; i++)
                p[i] = "";
            string[] q = new string[3];
            for (int i = 0; i < 3; i++)
                q[i] = "";
            char[] time = d[m-1].ToCharArray();
            for (int n = 0; n < time.Length; n++)
            {
                try
                {
                    string l = "" + time[n];
                    time1[k] = int.Parse(l);
                    k++;
                }
                catch
                {

                }
            }
            int r = 0;
            for (int i = 0; i < 6; i = i + 2)
            {
                if (time1[i] != 0 && time1[i + 1] != 0)
                {
                    p[r] = time1[i].ToString() + time1[i + 1].ToString();
                    r++;
                }
            }
            for (int i = 0; i < m-1; i++)
            {
                if (d[i] != "")
                {
                    int g = 0;
                    int[] time2 = new int[6];
                    for (int po = 0; po < 6; po++)
                        time2[po] = 0;
                    char[] time3 = d[i].ToCharArray();
                    for (int n = 0; n < time3.Length; n++)
                    {
                        try
                        {
                            string l1 = "" + time3[n];
                            time2[g] = int.Parse(l1);
                            g++;
                        }
                        catch
                        {

                        }
                    }
                    int h = 0;
                    for (int i1 = 0; i1 < 6; i1 = i1 + 2)
                    {
                        if (time2[i1] != 0 && time2[i1 + 1] != 0)
                        {
                            q[h] = time2[i1].ToString() + time2[i1 + 1].ToString();
                            h++;
                        }
                    }
                    for(int w=0;w<3;w++)
                        for (int z = 0; z < 3; z++)
                        {
                            if (q[w] != "" && p[z] != "")
                                if (q[w] == p[z])
                                    b1 = false;
                        }
                }
            }
            if (b1)
            {
                listBox1.Items.Add(textBox1.Text.Trim());
                button2.Visible = false;
                button2.Enabled = false;
                label1.Text = "";
                textBox1.Text = "";
            }
            else
            {
                c[m - 1] = "";
                d[m - 1] = "";
                MessageBox.Show("时间冲突！");
                button2.Visible = false;
                button2.Enabled = false;
                label1.Text = "";
                textBox1.Text = "";
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 25; i++)
                a[i] = "";
            for (int i = 0; i < 25; i++)
                b[i] = "";
            for (int i = 0; i < 25; i++)
                c[i] = "";
            for (int i = 0; i < 25; i++)
                d[i] = "";
                button2.Visible = false;
            button2.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                int j = 0;
                for (int i = 0; i < 25; i++)
                {
                    if (c[i] == listBox1.SelectedItem.ToString())
                    {
                        j = i;
                        n = i;
                    }
                }
                label2.Text = c[j] + "\n" + a[j] + "\n" + b[j] + "\n";
                button4.Visible = true;
                button4.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            c[n] = "";
            d[n] = "";
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            label2.Text=c[n];
            button4.Visible = false;
            button4.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int m = 0;
            string[] n=new string[9];
            for(int i=0;i<9;i++)
                n[i]=null;
            for (int i = 0; i < 25; i++)
            {
                if (c[i] != "")
                {
                    n[m]=c[i];
                    m++;
                }
            }
            string sql = "insert into dbo.newchoose values('" + Form1.username1 + "','" + m + "','" + n[0] + 
                "','" + n[1] + "','" + n[2] + "','" + n[3] + "','" + n[4] + "','" + n[5] + "','" + n[6] + "','" + n[7] + "','" + n[8] + "')";
            SqlCommand comm = new SqlCommand(sql,sqlConnection1);
            try
            {
                sqlConnection1.Open();
                if (comm.ExecuteNonQuery() > 0)
                    MessageBox.Show("选课成功!");
                else
                    MessageBox.Show("选课失败！");
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
