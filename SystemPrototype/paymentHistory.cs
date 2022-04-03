using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace SystemPrototype
{
    public partial class paymentHistory : Form
    {
        public paymentHistory(int y)
        {
            InitializeComponent();

            myFunction(y);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]

        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessege(System.IntPtr one, int two, int three, int four);

        public void myFunction(int value)
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\NSBM\1st_Year\3rd_Semester\C# Programming\Assignments\Final Group Project\VIVA\Project\SystemPrototypeDb.mdf;Integrated Security=True;Connect Timeout=30";
            string query = "SELECT *FROM StudentPay WHERE StudentID = "+value+"";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "StudentPay");
                DGV3.DataSource = ds.Tables["StudentPay"];
            }

            catch(SqlException SE)
            {
                MessageBox.Show(SE + ToString());
            }
        }
         
       
      
        
     
      

        

        public void DGV3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessege(Handle, 0x112, 0xf012, 0);
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {

        }

    }

    
        



    }




