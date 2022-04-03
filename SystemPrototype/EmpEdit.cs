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

namespace SystemPrototype
{
    public partial class EmpEdit : Form
    {
        public EmpEdit()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]

        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessege(System.IntPtr one, int two, int three, int four);



        public bool TxtBX_EmptyCheck()
        {

            if (guna2TextBox1.Text == "" || guna2TextBox2.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Phone_NumCheck()
        {
            CommonVali digiCheck_3 = new CommonVali();
            bool result_3 = digiCheck_3.DigitsOnly(guna2TextBox2.Text);

            if (guna2TextBox2.Text == "")
            {
                return false;
            }
            else if (guna2TextBox2.Text.Length != 10 || !result_3)
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
            CommonVali digiCheck_4 = new CommonVali();
            bool result_4 = digiCheck_4.DigitsOnly(guna2TextBox1.Text);

            if (guna2TextBox1.Text == "")
            {
                return false;
            }
            else if (guna2TextBox1.Text.Length > 9 || !result_4)
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        public int IntVali()
        {
            try
            {
                int phn_num = int.Parse(guna2TextBox2.Text);
                return 1;

            }
            catch (Exception exc)
            {
                string eror = exc.ToString();
                MessageBox.Show("Invalid Value as Number");
                guna2TextBox2.Text = "";
                return 0;

            }

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (TxtBX_EmptyCheck())
            {
                if (!empID_Check())
                {
                    lbl_IDError.Text = "*Invalid ID";
                }

                if (!Phone_NumCheck())
                {
                    lbl_NumError.Text = "*Invalid Number";

                }


                if (Phone_NumCheck() && empID_Check())
                {
                    int Emp_ID = int.Parse(guna2TextBox1.Text);

                    if (IntVali() == 1)
                    {
                        int Emp_Phn = int.Parse(guna2TextBox2.Text);

                        CommonVali IDvalidate = new CommonVali();
                        bool flag = IDvalidate.ID_Validation(Emp_ID);
                        if (flag)
                        {
                            if (!guna2RadioButton1.Checked && !guna2RadioButton2.Checked)
                            {
                                MessageBox.Show("Please select which number to Edit");
                            }
                            else
                            {

                                if (guna2RadioButton1.Checked)
                                {
                                    string query1 = "UPDATE Employee SET Contact_NO_1 = " + Emp_Phn + " WHERE Emp_ID = " + Emp_ID + "";
                                    EmpConnection con1 = new EmpConnection();
                                    int result = con1.ExecuteQRY(query1);
                                    if (result == 1)
                                    {
                                        MessageBox.Show("Edited Successfully. ");
                                        guna2TextBox2.Text = "";
                                        guna2TextBox1.Text = "";

                                      
                                    }
                                    else
                                    {
                                        MessageBox.Show(" Error ");
                                    }
                                }
                                else
                                {
                                    string query1 = "UPDATE Employee SET Contact_NO_2 = " + Emp_Phn + " WHERE Emp_ID = " + Emp_ID + "";
                                    EmpConnection con1 = new EmpConnection();
                                    int result = con1.ExecuteQRY(query1);

                                    if (result == 1)
                                    {
                                        MessageBox.Show("Edited Successfully. ");
                                        guna2TextBox2.Text = "";
                                        guna2TextBox1.Text = "";

                                       
                                       
                                    }
                                    else
                                    {
                                        MessageBox.Show(" Error ");
                                    }
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("No Employee is baring the enterd ID !!!");
                            guna2TextBox1.Text = "";
                            guna2TextBox2.Text = "";
                        }

                    }



                }

            }
            else
            {
                MessageBox.Show("Fill In all the Required Fields ");
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            lbl_IDError.Text = "";
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            lbl_NumError.Text = "";
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessege(Handle, 0x112, 0xf012, 0);
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            EmployeeDetails emp = new EmployeeDetails();
            emp.datagridLoad();
            this.Close();
        }
    }
}
