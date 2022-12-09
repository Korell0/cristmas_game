using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cristmas_game
{
    public partial class Mainmenu : Form
    {
        static List<PictureBox> hopihek = new List<PictureBox>();
        public Mainmenu()
        {
            InitializeComponent();
           
        }

       


        private void start_Btn_Click(object sender, EventArgs e)
        {
            Form1 uj = new Form1();
            uj.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
