using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace cristmas_game
{
    class SantaSnake
    {
        public string Name = "Santa";
        public List<string> Body = new List<string>();
        public Point Helyzet;
        
        public SantaSnake()
        {
            Body.Add("Santa");
            Body.Add("Bag");
        }
    }
}
