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

<<<<<<< HEAD
       
=======
        private void GenerateHopihe()
        {
            Random r = new Random();
            
            for (int i = 0; i < 12; i++)
            {
                PictureBox uj = new PictureBox();
                uj.Location = new Point(r.Next(10, 510), 3);
                //uj.Image = Image.FromFile("hopihe.png");
                this.Controls.Add(uj);
                hopihek.Add(uj);
            }
            timer1.Start();
        }
>>>>>>> a9833e86c3f9b627cadf9a194b638d448ed3b757


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
