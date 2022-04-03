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
    public partial class DetailsStudent : Form
    {
        public DetailsStudent()
        {
            InitializeComponent();

            var editColumn = new DataGridViewButtonColumn
            {
                Text = "VIEW",
                UseColumnTextForButtonValue = true,
                Name = "Payment History",
                //DataPropertyName = "Edit"
            };
            DGV1.Columns.Add(editColumn);


            Bunifu.Utils.DatagridViewExt.BindDatagridViewScrollBar(DGV1, bunifuVScrollBar1);
        }


       
    






        private void DetailsStudent_Load(object sender, EventArgs e)
        {
            Updatedb();
 
        }

        public void Updatedb()
        {
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\NSBM\1st_Year\3rd_Semester\C# Programming\Assignments\Final Group Project\VIVA\Project\SystemPrototypeDb.mdf;Integrated Security=True;Connect Timeout=30"; ;
            string query = "SELECT *FROM Prototype";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query,con);
                DataSet ds = new DataSet();
                da.Fill(ds, "Prototype");
                DGV1.DataSource = ds.Tables["Prototype"];
                
            }

            catch(SqlException SE)
            {
                MessageBox.Show(SE + ToString());
            }
        }

        private void DGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

            (DGV1.DataSource as DataTable).DefaultView.RowFilter = string.Format("Student_Name LIKE '%{0}%' OR convert(Student_Id, 'System.String') LIKE '%{0}%'", guna2TextBox1.Text);

        }

       

        private void guna2TextBox1_Leave(object sender, EventArgs e)
        {
           

        }

     


        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
             

            
            string value = DGV1.Rows[e.RowIndex].Cells["Student_Id"].Value.ToString();

            if (DGV1.Rows[e.RowIndex].Cells[columnIndex].Selected == true && DGV1.Columns[columnIndex].Name == "Payment History")
            {
                int x = int.Parse(value);

                 new paymentHistory(x).Show();
            }
        }

       
    }
}
