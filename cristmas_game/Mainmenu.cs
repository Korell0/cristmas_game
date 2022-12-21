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
        public Mainmenu()
        {
            InitializeComponent();
           
        }


        private void Day_Click(object sender, EventArgs e)
        {
            Form1 uj = new Form1("Day");
            uj.Show();
            this.Hide();
        }

        private void Night_Click(object sender, EventArgs e)
        {
            Form1 uj = new Form1("Night");
            uj.Show();
            this.Hide();

        }
    }
}
