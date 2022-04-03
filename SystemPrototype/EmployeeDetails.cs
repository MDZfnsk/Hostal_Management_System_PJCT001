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

namespace SystemPrototype
{
    public partial class EmployeeDetails : Form
    {
        public EmployeeDetails()
        {
            InitializeComponent();

            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Project IGI\SystemPrototypeDb.mdf;Integrated Security=True;Connect Timeout=30";
            string Query = "SELECT * FROM Employee";

            try
            {
                SqlDataAdapter ad = new SqlDataAdapter(Query, connection);
                DataSet ds = new DataSet();

                ad.Fill(ds, "Employee");
                DGV1.DataSource = ds.Tables["Employee"];
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
                
        }

        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            new NewEmployee().Show();
        }

        private void guna2GradientButton1_Click_2(object sender, EventArgs e)
        {
            new EmpEdit().Show();
        }

        private void guna2GradientButton2_Click_1(object sender, EventArgs e)
        {
            new EmpDelete().Show();
        }

        private void EmployeeDetails_Load(object sender, EventArgs e)
        {
            
        }

        public void datagridLoad()
        {

            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\NSBM\1st_Year\3rd_Semester\C# Programming\Assignments\Final Group Project\VIVA\Project\SystemPrototypeDb.mdf;Integrated Security=True;Connect Timeout=30";
            string Query = "SELECT * FROM Employee";

            try
            {
                SqlDataAdapter ad = new SqlDataAdapter(Query, connection);
                DataSet ds = new DataSet();

                ad.Fill(ds, "Employee");
                DGV1.DataSource = ds.Tables["Employee"];
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

       
    }
}
