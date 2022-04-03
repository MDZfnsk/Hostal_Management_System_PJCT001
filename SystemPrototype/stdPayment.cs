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
    public partial class stdPayment : Form
    {
        public stdPayment()
        {
            InitializeComponent();
        }

        

        public void MyFunction()
        {
            SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\NSBM\1st_Year\3rd_Semester\C# Programming\Assignments\Final Group Project\VIVA\Project\SystemPrototypeDb.mdf;Integrated Security=True;Connect Timeout=30");
            string querry = "SELECT ISNULL (MAX(CAST (PayID as int)),0)+1 FROM StudentPay";
            SqlDataAdapter sda = new SqlDataAdapter(querry, con1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            guna2PayID.Text = dt.Rows[0][0].ToString();
        }

        private void stdPayment_Load(object sender, EventArgs e)
        {
            MyFunction();
            this.ActiveControl = guna2StdID;
        }

        public void TxtEmptyFunction()
        {
            guna2StdID.Text = "";
            bunifuDatePaid.Text = "";
            bunifuMonth.Text = "";
            guna2Amount.Text = "";
            lblStd_Nm.Text = "";
            label2.Text = "";
            label4.Text = "";

        }


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            if (guna2StdID.Text == "" || bunifuDatePaid.Text == "" || bunifuMonth.Text == "" || guna2Amount.Text == "")
            {
                MessageBox.Show("Please Fill in the Empty Fields !!!");

            }
            else if (lblStd_Nm.Text == string.Empty && label2.Text == string.Empty && label4.Text == string.Empty)
            {
                MessageBox.Show("This Student ID is not in the Database. Please Check Again !!!");
                guna2Amount.Text = "";
                bunifuDatePaid.Text = "";
                bunifuMonth.Text = "";
                label1.Text = "";
                label3.Text = "";
                label5.Text = "";

            }

            else
            {
                Encap ep = new Encap();
                ep.Set_ID(int.Parse(guna2StdID.Text));
                ep.Set_Amount(float.Parse(guna2Amount.Text));


               
                int pay_ID = int.Parse(guna2PayID.Text);
                string dt_pyd = bunifuDatePaid.Text;
                string for_mnt = bunifuMonth.Text;
            

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Project IGI\SystemPrototypeDb.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "INSERT INTO StudentPay VALUES (" + pay_ID + "," + ep.Get_ID() + ",'" + dt_pyd + "','" + for_mnt + "'," + ep.Get_Amount() + ")";
                SqlCommand com = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    com.ExecuteNonQuery();
                    //CUSTOM MESSEGE BOX
                    customMessegeBox cm = new customMessegeBox();
                    cm.Show();

                    this.MyFunction();
                    this.TxtEmptyFunction();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error" + ex.ToString());
                }
                finally
                {
                    con.Close();
                }

            }
        }

        private void txtStd_ID_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Amount_Click(object sender, EventArgs e)
        {

        }

        private void Date_Pyd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2StdID_TextChanged(object sender, EventArgs e)
        {
            if (guna2StdID.Text == "")
            {
                label1.Text = "";
                lblStd_Nm.Text = "";
                label3.Text = "";
                label2.Text = "";
                label5.Text = "";
                label4.Text = "";
            }
            else
            {
                Encap en = new Encap();
                en.Set_ID(int.Parse(guna2StdID.Text));

               
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\NSBM\1st_Year\3rd_Semester\C# Programming\Assignments\Final Group Project\VIVA\Project\SystemPrototypeDb.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "SELECT Student_Name, Mobile_Number, Room_Number FROM Prototype WHERE Student_Id = " + en.Get_ID() + "";
                SqlCommand com = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    SqlDataReader sdr = com.ExecuteReader();


                    if (sdr.Read())
                    {
                        label1.Text = "STUDENT NAME    :";
                        lblStd_Nm.Text = sdr["Student_Name"].ToString();

                        label3.Text = "MOBILE NUMBER :";
                        label2.Text = sdr["Mobile_Number"].ToString();

                        label5.Text = "ROOM NUMBER    :";
                        label4.Text = sdr["Room_Number"].ToString();
                    }
                    else
                    {
                        label1.Text = " ";
                        lblStd_Nm.Text = string.Empty;

                        label3.Text = " ";
                        label2.Text = string.Empty;

                        label5.Text = " ";
                        label4.Text = string.Empty;
                    }
                }
                catch (SqlException excp)
                {
                    MessageBox.Show(" Eror " + excp);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void guna2StdID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                MessageBox.Show(" Invalid Input ");
                e.Handled = true;
            }
        }

        private void guna2Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                MessageBox.Show(" Invalid Input ");
                e.Handled = true;
            }
        }
    }
}
