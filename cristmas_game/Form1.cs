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
        static int Size = 15;
        static int Obstacles = 5;
        static Keys key;
        static Fields[,] Map = new Fields[Size,Size];
        static SantaSnake Santa = new SantaSnake();
        static Random R = new Random();
        static int Moverow;
        public Form1()
        {
            InitializeComponent();
            this.Width = 1500;
            this.Height = 1000;
            GenerateMap();
            GenerateObstacle();
            GenerateSantaSnake();

        }

        private void GenerateSantaSnake()
        {

            int randomrow = R.Next(1, Size - 1);
            int randomcolumn = R.Next(1, Size - 1);


            if (Map[randomrow, randomcolumn].Name == "Obstacle" || !NeighborhoodCheck(randomrow, randomcolumn))
            {
                GenerateSantaSnake();
            }
            else
            {
                Map[randomrow, randomcolumn].Name = "Santa";
                Map[randomrow, randomcolumn].Background.BackColor = Color.Blue;
                Santa.Helyzet.X = randomrow;
                Santa.Helyzet.Y = randomcolumn;
            }



        }

        private bool NeighborhoodCheck(int row, int column)
        {
                MessageBox.Show($"{row}, {column}, {Map[row,column].Name}");

            if(Map[row, column].Name != "Obstacle")
            {
                //Down
                for (int sor = row; sor >= row - 2 || sor < 0; sor--)
                {
                    if (Map[sor,column].Name != "Cell")
                    {
                        return false;
                    }
                }

                //Up
                for (int sor = row; sor <= row + 2 || sor > Size; sor++)
                {
                    if (Map[sor, column].Name != "Cell")
                    {
                        return false;
                    }
                }

                //Right
                for (int oszlop = column; oszlop < column + 2 || oszlop > Size; oszlop++)
                {
                    if (Map[row,oszlop].Name != "Cell")
                    {
                        return false;
                    }
                }

                //Left
                for (int oszlop = column; oszlop > column - 2 || oszlop < 0; oszlop--)
                {
                    if (Map[row, oszlop].Name != "Cell")
                    {
                        return false;  
                    }
                }

                return true;

            }
            else
            {
            return false;

            }
        }

        private void GenerateObstacle()
        {
            Random r = new Random();
            int Sr = 0;

            for (int i = 0; i < Size * Size; i++)
            {
                if (Sr !=Obstacles)
                {
                    int row = r.Next(1, Size - 1);
                    int column = r.Next(1, Size - 1);

                    if (Map[row, column].Background.BackColor == Color.Wheat)
                    {
                        Map[row, column].Name = "Obstacle";
                        Map[row, column].Background.BackColor = Color.Red;
                        Sr++;
                    }
                }
                else
                {
                    break;
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Timer.Start();
            }

            key = e.KeyCode;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("JEeeee");
            //UP
            if (key == Keys.W || key == Keys.Up)
            {
                Moverow = Santa.Helyzet.X - 1;
                if (FieldCheck(Moverow))
                {
                    Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackColor = Color.Wheat;
                    Map[Moverow, Santa.Helyzet.Y].Background.BackColor = Color.Blue;
                    Santa.Helyzet.X = Moverow;
                }
            }
        }

        private bool FieldCheck(int check)
        {
            if (key == Keys.W || key == Keys.Up)
            {
                if (Map[check, Santa.Helyzet.Y].Name != "Obstacle" || Map[check,Santa.Helyzet.Y].Name != "Wall")
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Fal / akadály");
                }
            }
            return false;
        }
    }
                /*||
                e.KeyCode == Keys.S || e.KeyCode == Keys.Down||
                e.KeyCode == Keys.A || e.KeyCode == Keys.Left||
                e.KeyCode == Keys.D || e.KeyCode == Keys.Right*/
}
