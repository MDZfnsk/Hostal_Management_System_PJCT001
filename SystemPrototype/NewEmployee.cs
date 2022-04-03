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
    public partial class NewEmployee : Form
    {
        public NewEmployee()
        {
            InitializeComponent();
        }

        public bool Phone_Num_01_Check()
        {
            CommonVali digiCheck_1 = new CommonVali();
            bool result_1 = digiCheck_1.DigitsOnly(guna2TextBox3.Text);

            if (guna2TextBox3.Text == "")
            {
                return false;
            }
            else if (guna2TextBox3.Text.Length != 10 || !result_1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Phone_Num_02_Check()
        {
            CommonVali digiCheck_1 = new CommonVali();
            bool result_1 = digiCheck_1.DigitsOnly(guna2TextBox4.Text);

            if (guna2TextBox4.Text == "")
            {
                return false;
            }
            else if (guna2TextBox4.Text.Length != 10 || !result_1)
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
            CommonVali digiCheck_2 = new CommonVali();
            bool result_2 = digiCheck_2.DigitsOnly(guna2TextBox2.Text);

            if (guna2TextBox2.Text == "")
            {
                return false;
            }
            else if (guna2TextBox2.Text.Length > 9 || !result_2)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool TxtBX_EmptyCheck()
        {

            if (guna2TextBox2.Text == "" || guna2TextBox1.Text == "" || guna2TextBox3.Text == "")
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
                int phnnum = int.Parse(guna2TextBox3.Text);
                return 1;

            }
            catch (Exception exc)
            {
                string eror = exc.ToString();
                MessageBox.Show("Invalid Value as Number");
                guna2TextBox3.Text = "";
                return 0;

            }

        }


        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (TxtBX_EmptyCheck())
            {

                if (!Phone_Num_01_Check())
                {
                    lbl_CnNO_01_error.Text = "*Invalid Phone Number";
                }

                if (!empID_Check())
                {
                    lbl_IDerror.Text = "Invslid ID";
                }

                if (Phone_Num_01_Check() && empID_Check())
                {
                    if (IntVali() == 1)
                    {
                        if (guna2TextBox4.Text == "")
                        {
                            int empid = int.Parse(guna2TextBox2.Text);
                            string emp_nm = guna2TextBox1.Text;
                            int con_no_1 = int.Parse(guna2TextBox3.Text);

                            DataInClass DinOBJ = new DataInClass();
                            int rezult = DinOBJ.InsFunction(empid, emp_nm, con_no_1);

                            if (rezult == 2)
                            {
                                MessageBox.Show(" Employee with the same ID already in the System");
                                guna2TextBox3.Text = "";
                                guna2TextBox2.Text = "";
                                guna2TextBox1.Text = "";
                            }
                            else if (rezult == 1)
                            {
                                new customMessegeBox().Show();
                                guna2TextBox3.Text = "";
                                guna2TextBox2.Text = "";
                                guna2TextBox1.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Error");
                            }
                        }
                        else
                        {
                            if (!Phone_Num_02_Check())
                            {
                                lbl_CnNO_02_error.Text = "*Invalid Phone Number";
                            }
                            else
                            {
                                int empid = int.Parse(guna2TextBox2.Text);
                                string emp_nm = guna2TextBox1.Text;
                                int con_no_1 = int.Parse(guna2TextBox3.Text);
                                int con_no_2 = int.Parse(guna2TextBox4.Text);


                                DataInClass DinOBJ = new DataInClass();
                                int rezult = DinOBJ.InsFunction(empid, emp_nm, con_no_1, con_no_2);

                                if (rezult == 2)
                                {
                                    MessageBox.Show(" Employee with the same ID already in the System");
                                    guna2TextBox3.Text = "";
                                    guna2TextBox2.Text = "";
                                    guna2TextBox1.Text = "";
                                }
                                else if (rezult == 1)
                                {
                                    new customMessegeBox().Show();
                                    guna2TextBox3.Text = "";
                                    guna2TextBox4.Text = "";
                                    guna2TextBox2.Text = "";
                                    guna2TextBox1.Text = "";
                                }
                                else
                                {
                                    MessageBox.Show("Error");
                                }

                            }

                        }

                    }


                }

            }
            else
            {

                MessageBox.Show("Fill In all the Required Fields ");

            }
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            lbl_CnNO_01_error.Text = "";

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            lbl_CnNO_02_error.Text = "";
        }
    }
}
