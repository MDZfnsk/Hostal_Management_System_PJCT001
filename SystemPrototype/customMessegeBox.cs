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
    public partial class customMessegeBox : Form
    {
        public customMessegeBox()
        {
            InitializeComponent();

            
        }

        private void customMessegeBox_Load(object sender, EventArgs e)
        {
            
        }

        private void bunifuColorTransition1_ColorChanged(object sender, Bunifu.UI.WinForms.BunifuColorTransition.ColorChangedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Opacity==1)
            {
                timer1.Stop();
            }
            Opacity += .2;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Drag Form By Picture
           
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }



}
