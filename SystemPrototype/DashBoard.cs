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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
            panelNavi.Height = guna2GradientButton1.Height;
            panelNavi.Top = guna2GradientButton1.Top;
            panelNavi.Left = guna2GradientButton1.Left;
            guna2GradientButton1.FillColor = Color.FromArgb(26, 32, 42);
            guna2GradientButton1.FillColor2 = Color.FromArgb(26, 32, 42);

            openChildForm(new newStudent());

            
            
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            panelNavi.Height = guna2GradientButton1.Height;
            panelNavi.Top = guna2GradientButton1.Top;
            panelNavi.Left = guna2GradientButton1.Left;
            guna2GradientButton1.FillColor = Color.FromArgb(26, 32, 42);
            guna2GradientButton1.FillColor2 = Color.FromArgb(26, 32, 42);

            openChildForm(new newStudent());



        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            panelNavi.Height = guna2GradientButton2.Height;
            panelNavi.Top = guna2GradientButton2.Top;
            guna2GradientButton2.FillColor = Color.FromArgb(26, 32, 42);
            guna2GradientButton2.FillColor2 = Color.FromArgb(26, 32, 42);

            openChildForm(new StudentUpdateDelete());
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            panelNavi.Height = guna2GradientButton3.Height;
            panelNavi.Top = guna2GradientButton3.Top;
            guna2GradientButton3.FillColor = Color.FromArgb(26, 32, 42);
            guna2GradientButton3.FillColor2 = Color.FromArgb(26, 32, 42);

            openChildForm(new DetailsStudent());

        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            panelNavi.Height = guna2GradientButton4.Height;
            panelNavi.Top = guna2GradientButton4.Top;
            guna2GradientButton4.FillColor = Color.FromArgb(26, 32, 42);
            guna2GradientButton4.FillColor2 = Color.FromArgb(26, 32, 42);

            openChildForm(new stdPayment());
            
        }   

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            panelNavi.Height = guna2GradientButton5.Height;
            panelNavi.Top = guna2GradientButton5.Top;
            guna2GradientButton5.FillColor = Color.FromArgb(26, 32, 42);
            guna2GradientButton5.FillColor2 = Color.FromArgb(26, 32, 42);

            openChildForm(new NewEmployee());
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            panelNavi.Height = guna2GradientButton6.Height;
            panelNavi.Top = guna2GradientButton6.Top;
            guna2GradientButton6.FillColor = Color.FromArgb(26, 32, 42);
            guna2GradientButton6.FillColor2 = Color.FromArgb(26, 32, 42);

            openChildForm(new EmployeeDetails());
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
           
            
        }

        private void guna2GradientButton1_Leave(object sender, EventArgs e)
        {
            guna2GradientButton1.FillColor = Color.FromArgb(0, 107, 56);
            guna2GradientButton1.FillColor2 = Color.FromArgb(16, 24, 32);
        }

        private void guna2GradientButton2_Leave(object sender, EventArgs e)
        {
            guna2GradientButton2.FillColor = Color.FromArgb(0, 107, 56);
            guna2GradientButton2.FillColor2 = Color.FromArgb(16, 24, 32);
        }

        private void guna2GradientButton3_Leave(object sender, EventArgs e)
        {
            guna2GradientButton3.FillColor = Color.FromArgb(0, 107, 56);
            guna2GradientButton3.FillColor2 = Color.FromArgb(16, 24, 32);
        }

        private void guna2GradientButton4_Leave(object sender, EventArgs e)
        {
            guna2GradientButton4.FillColor = Color.FromArgb(0, 107, 56);
            guna2GradientButton4.FillColor2 = Color.FromArgb(16, 24, 32);
        }

        private void guna2GradientButton5_Leave(object sender, EventArgs e)
        {
            guna2GradientButton5.FillColor = Color.FromArgb(0, 107, 56);
            guna2GradientButton5.FillColor2 = Color.FromArgb(16, 24, 32);
        }

        private void guna2GradientButton6_Leave(object sender, EventArgs e)
        {
            guna2GradientButton6.FillColor = Color.FromArgb(0, 107, 56);
            guna2GradientButton6.FillColor2 = Color.FromArgb(16, 24, 32);
        }

        private void guna2GradientButton7_Leave(object sender, EventArgs e)
        {
            
        }

        private Form activeForm = null;
        private void openChildForm(Form StudentForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = StudentForm;
            StudentForm.TopLevel = false;
            StudentForm.FormBorderStyle = FormBorderStyle.None;
            StudentForm.Dock = DockStyle.Fill;
            panel1.Controls.Add(StudentForm);
            panel1.Tag = StudentForm;
            StudentForm.BringToFront();
            StudentForm.Show();
            labelTitle.Text = StudentForm.Text;
        }


        private void homeBtn_Click(object sender, EventArgs e)
        {
           
        }

        //DRAG FORM BY TITLE BAR    
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void titlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
