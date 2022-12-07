using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace cristmas_game
{
    class Fields
    {
        public string Name;
        public PictureBox Background;
        public int Score;


        public Fields(Point point, Size size, string name, int score, string background)
        {
            Name = name;
            Score = score;

            Background = new PictureBox();
            Background.Visible = true;
            //Background.BackColor = Color.Wheat;
            Background.Size = size;
            Background.Location = point;

            if (background == "Black")
            {
                Background.BackColor = Color.Black;
            }
            if (background == "Wheat")
            {
                Background.BackColor = Color.Wheat;
            }
        }
    }
}
