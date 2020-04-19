using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void SinglePlayButton_Click(object sender, EventArgs e)
        {
            Hide();
            SinglePlayForm singlePlayForm = new SinglePlayForm();
            singlePlayForm.FormClosed += new FormClosedEventHandler(childForm_Closed);
            singlePlayForm.Show();
        }

        void childForm_Closed(object sender, FormClosedEventArgs e)
        {
            Show();
        }
    }
}
