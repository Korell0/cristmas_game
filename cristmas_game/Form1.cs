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
    public partial class Form1 : Form
    {
        static int Size = 31;
        static int Obstacles = 5;
        static Fields[,] Map = new Fields[Size,Size];
        public Form1()
        {
            InitializeComponent();
            this.Width = 2000;
            this.Height = 1920;
            GenerateMap();
            GenerateObstacle();

        }

        private void GenerateObstacle()
        {
            Random r = new Random();

            for (int i = 0; i < Obstacles; i++)
            {
                int row = r.Next(1, Size - 1);
                int column = r.Next(1, Size - 1);

                if (Map[row, column].Background.BackColor == Color.Wheat)
                {
                    Map[row, column].Background.BackColor = Color.Red;
                }
            }
        }

        private void GenerateMap()
        {
            int size = 31;

            int startY = 16;
            int startX = groupBox1.Height - 10 * size + 10;

            for (int row = 0; row < Map.GetLength(0); row++)
            {
                for (int column = 0; column < Map.GetLength(1); column++)
                {
                    int xPosition = startX + column * size + column;
                    int yPosition = startY + row * size + row;

                    if (row == 0 || row == Size - 1)
                    {
                        Map[row, column] = new Fields(new Point(xPosition,yPosition), new Size(size,size), "Wall", 0, "Black");
                        this.Controls.Add(Map[row, column].Background);
                    }
                    if (column == 0 || column == Size - 1)
                    {
                        Map[row, column] = new Fields(new Point(xPosition, yPosition), new Size(size, size), "Wall", 0, "Black");
                        this.Controls.Add(Map[row, column].Background);
                    }

                    Map[row, column] = new Fields(new Point(xPosition, yPosition), new Size(size, size), "Cell", 0, "Wheat");

                    this.Controls.Add(Map[row, column].Background);
                }
            }
        }
    }
}
