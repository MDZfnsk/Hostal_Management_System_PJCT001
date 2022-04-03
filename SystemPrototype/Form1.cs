using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Security.Cryptography;



namespace SystemPrototype
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int left,
            int top,
            int right,
            int bottom,
            int width,
            int height
            );

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0,0,Width,Height,7,7));
        }


        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.AcceptButton = this.guna2GradientTileButton1;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)

        {
            string name = guna2TextBox1.Text;
            string pwd = guna2TextBox2.Text;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\NSBM\1st_Year\3rd_Semester\C# Programming\Assignments\Final Group Project\VIVA\Project\SystemPrototypeDb.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT COUNT(*) FROM Login WHERE (username = '" + name + "') AND (password = '" + Utilis.Security.HashSHA1(pwd) + "'); ";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                int NameExist = (int)cmd.ExecuteScalar();
                int PassExist = (int)cmd.ExecuteScalar();

                if (PassExist > 0 && NameExist > 0)
                {
                    new DashBoard().Show();
                    this.Hide();
                    
                }
                else
                {
                    label1.Text = "The username or password you entered is incorrect.";
                    guna2TextBox2.BorderColor = Color.Red;
                }


            }
            catch (SqlException SE)
            {
                MessageBox.Show(SE + ToString());
            }
            finally
            {
                con.Close();
            }

            

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("The Caps Lock key is ON.");
            }
        }

        private void guna2CircleButton1_MouseDown(object sender, MouseEventArgs e)
        {
            guna2TextBox2.UseSystemPasswordChar = false;
        }

        private void guna2CircleButton1_MouseUp(object sender, MouseEventArgs e)
        {
            guna2TextBox2.UseSystemPasswordChar = true;
        }

        private void guna2TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                guna2GradientTileButton1.PerformClick();
            }
        }
    }
}
