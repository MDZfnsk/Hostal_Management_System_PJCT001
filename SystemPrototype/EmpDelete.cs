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
    public partial class EmpDelete : Form
    {
        public EmpDelete()
        {
            InitializeComponent();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]

        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessege(System.IntPtr one, int two, int three, int four);



        public bool TxtBX_EmptyCheck()
        {

            if (guna2TextBox1.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        public bool empID_Check()
        {
            CommonVali digiCheck_5 = new CommonVali();
            bool result_5 = digiCheck_5.DigitsOnly(guna2TextBox1.Text);

            if (guna2TextBox1.Text == "")
            {
                return false;
            }
            else if (guna2TextBox1.Text.Length > 9 || !result_5)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (TxtBX_EmptyCheck())
            {
                if (empID_Check())
                {
                    int Empid = int.Parse(guna2TextBox1.Text);
                    CommonVali IDvalidate = new CommonVali();
                    bool flag = IDvalidate.ID_Validation(Empid);
                    if (flag)
                    {
                        EmpConnection connect = new EmpConnection();
                        string qerry = "DELETE FROM Employee WHERE Emp_ID = " + Empid + "";
                        int answer = connect.ExecuteQRY(qerry);
                        if (answer == 1)
                        {
                            MessageBox.Show("Record Deleted Successfully ");
                            guna2TextBox1.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Employee is baring the enterd ID !!!");
                    }
                }
                else
                {
                    lbl_IDError.Text = "* Invalid ID";
                }
            }
            else
            {
                MessageBox.Show("Please Fill In The Required Fields");
            }

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessege(Handle, 0x112, 0xf012, 0);
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            lbl_IDError.Text = "";
        }
    }
}
