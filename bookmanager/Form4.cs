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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string[] a = new string[25];
            string[] b = new string[25];
            string[] c = new string[25];
            string[] d=new string[25];
            string sqltr1 = "select * from dbo.chengji where usernumber='20160001'";
            SqlCommand comm1 = new SqlCommand(sqltr1, sqlConnection1);
            try
            {
                sqlConnection1.Open();
                SqlDataReader reader = comm1.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    a[i] = reader["score"].ToString().Trim();
                    b[i] = reader["sno"].ToString().Trim();
                    c[i] = reader["teacher"].ToString().Trim();
                    i++;
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
            for (int i = 0; i < b.Length; i++)
            {
                string sqltr2 = "select * from dbo.subject where sno='"+b[i]+"'";
                SqlCommand comm2 = new SqlCommand(sqltr2,sqlConnection1);
                try
                {
                    sqlConnection1.Open();
                    SqlDataReader reader2 = comm2.ExecuteReader();
                    int jk = 0;
                    while (reader2.Read())
                    {
                        d[i] = reader2["name"].ToString().Trim();
                        jk++;
                    }
                    reader2.Close();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }finally{
                    sqlConnection1.Close();
                }
            }
            string sqltr = "select count(*) from dbo.chengji where usernumber='"+Form1.username1+"'";
            SqlCommand comm = new SqlCommand(sqltr, sqlConnection1);
            try
            {
                sqlConnection1.Open();
                int mn = (int)comm.ExecuteScalar();
                for (int l = 0; l < mn; l++)
                {
                    Class1.lab[l] = new Label();
                    Class1.lab[l].AutoSize = false;
                    Class1.lab[l].Size = new System.Drawing.Size(277,50);
                    Class1.lab[l].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    string x;
                    if (a[l] != "")
                    {
                        x = "成绩：" + a[l];
                    }
                    else
                    {
                        x = "未录入";
                    }
                    Class1.lab[l].Text = d[l] + "\n" + b[l] + "  " + c[l] +"\n"+ "                               " + x;
                    this.flowLayoutPanel1.Controls.Add(Class1.lab[l]);
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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
