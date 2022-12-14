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
        static int Obstacles = 7;
        static int Pontnoveles = 2;
        static Keys key;
        static Fields[,] Map = new Fields[Size, Size];
        static SantaSnake Santa = new SantaSnake();
        static Random R = new Random();
        static int Moverow;
        static int Movecolumn;
        static int Present = 0;
        static int Point = 0;
        public Form1()
        {
            InitializeComponent();
            this.Width = 1500;
            this.Height = 1000;
            GenerateMap();
            GenerateObstacle();
            GenerateSantaSnake();
            GeneratePresent();

        }

        private void GeneratePresent()
        {
            for (int i = 0; i < Size * Size; i++)
            {

                int row = R.Next(1, Size - 1);
                int column = R.Next(1, Size - 1);

                if (Map[row, column].Name == "Cell")
                {
                    Map[row, column].Name = "Present";
                    Map[row, column].Background.BackgroundImage = Image.FromFile("gift_box.png");
                    Map[row, column].Background.BackgroundImageLayout = ImageLayout.Zoom;
                    break;
                }

            }
        }
        private void GenerateSantaSnake()
        {

            int randomrow = R.Next(1, Size - 1);
            int randomcolumn = R.Next(1, Size - 1);


            if (Map[randomrow, randomcolumn].Name == "Obstacle" && !NeighborhoodCheck(randomrow, randomcolumn))
            {
                GenerateSantaSnake();
            }
            else
            {
                Map[randomrow, randomcolumn].Name = "Santa";
                Map[randomrow, randomcolumn].Background.BackgroundImage = Image.FromFile("santa.png");
                Map[randomrow, randomcolumn].Background.BackgroundImageLayout = ImageLayout.Zoom;
                Santa.Helyzet.X = randomrow;
                Santa.Helyzet.Y = randomcolumn;
            }



        }

        private bool NeighborhoodCheck(int row, int column)
        {
            MessageBox.Show($"{row}, {column}, {Map[row, column].Name}");

            if (Map[row, column].Name != "Obstacle")
            {
                //Down
                for (int sor = row; sor > row - 2 && sor < 0; sor--)
                {
                    if (Map[sor, column].Name != "Cell")
                    {
                        return false;
                    }
                }

                //Up
                for (int sor = row; sor < row + 2 && sor == Size; sor++)
                {
                    if (Map[sor, column].Name != "Cell")
                    {
                        return false;
                    }
                }

                //Right
                for (int oszlop = column; oszlop < column + 2 && oszlop == Size; oszlop++)
                {
                    if (Map[row, oszlop].Name != "Cell")
                    {
                        return false;
                    }
                }

                //Left
                for (int oszlop = column; oszlop > column - 2 && oszlop < 0; oszlop--)
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
            int Sr = 0;

            DestroyOldObstacles();
            for (int i = 0; i < Size * Size; i++)
            {
                if (Sr != Obstacles)
                {
                    int row = R.Next(1, Size - 1);
                    int column = R.Next(1, Size - 1);

                    if (Map[row, column].Name == "Cell")
                    {
                        Map[row, column].Name = "Obstacle";
                        Map[row, column].Background.BackgroundImage = Image.FromFile("obstacle.png");
                        Map[row, column].Background.BackgroundImageLayout = ImageLayout.Zoom;
                        Sr++;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        private void DestroyOldObstacles()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Map[i, j].Name == "Obstacle")
                    {
                        Map[i, j].Name = "Cell";
                        Map[i, j].Score = 0;
                        Map[i, j].Background.BackColor = Color.Wheat;
                        Map[i, j].Background.BackgroundImage = null;
                    }

                }

            }
        }

        private void GenerateMap()
        {
            int size = 50;

            int startY = 16;
            int startX = size;

            for (int row = 0; row < Map.GetLength(0); row++)
            {
                for (int column = 0; column < Map.GetLength(1); column++)
                {
                    int xPosition = startX + column * size + column;
                    int yPosition = startY + row * size + row;

                    if (row == 0 || row == Size - 1)
                    {
                        Map[row, column] = new Fields(new Point(xPosition, yPosition), new Size(size, size), "Wall", 0, "Black");
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

            int presentNmbr = Convert.ToInt32(PresentLBL.Text);

            if (presentNmbr == Pontnoveles)
            {
                Obstacles += 3;
                GenerateObstacle();

                Pontnoveles += 3;
                Timer.Interval -= 100;
            }


            //UP
            if (key == Keys.W || key == Keys.Up)
            {
                Moverow = Santa.Helyzet.X - 1;
                if (Santa.Helyzet.X > 1)
                {
                    if (FieldCheck(Moverow))
                    {
                        if (PresentCheck(Moverow))
                        {
                            Present++;
                            if (Present % 5 == 0)
                            {
                                Point++;
                            }
                            else
                            {
                                Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackColor = Color.Wheat;
                            }
                            PresentLBL.Text = $"{Present}";
                            PointLBL.Text = $"{Point}";
                            GeneratePresent();

                            Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackColor = Color.Wheat;
                            Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackgroundImage = null;
                            Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackColor = Color.Wheat;
                            Map[Moverow, Santa.Helyzet.Y].Background.BackgroundImage = Image.FromFile("santa_h.png");
                            Map[Moverow, Santa.Helyzet.Y].Background.BackgroundImageLayout = ImageLayout.Zoom;
                            Map[Moverow, Santa.Helyzet.Y].Name = "Santa";

                            Santa.Helyzet.X = Moverow;
                        }
                        else
                        {
                            Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackColor = Color.Wheat;
                            Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackgroundImage = null;
                            Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackColor = Color.Wheat;
                            Map[Moverow, Santa.Helyzet.Y].Background.BackgroundImage = Image.FromFile("santa_h.png");
                            Map[Moverow, Santa.Helyzet.Y].Background.BackgroundImageLayout = ImageLayout.Zoom;
                            Map[Moverow, Santa.Helyzet.Y].Name = "Santa";

                            Santa.Helyzet.X = Moverow;
                        }
                    }
                    else
                    {
                        Timer.Stop();
                        MessageBox.Show("Akadály!!");
                    }
                }
                else
                {
                    Timer.Stop();
                    MessageBox.Show("Fal!!");
                }
            }

            //Down
            if (key == Keys.S || key == Keys.Down)
            {
                Moverow = Santa.Helyzet.X +1;
                if (Santa.Helyzet.X < Size - 2)
                {
                    if (FieldCheck(Moverow))
                    {
                        if (PresentCheck(Moverow))
                        {
                            Present++;
                            if (Present % 5 == 0)
                            {
                                Point++;
                            }
                            else
                            {
                                Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackColor = Color.Wheat;
                            }
                            PresentLBL.Text = $"{Present}";
                            PointLBL.Text = $"{Point}";
                            GeneratePresent();

                            Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackColor = Color.Wheat;
                            Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackgroundImage = null;
                            Map[Moverow, Santa.Helyzet.Y].Background.BackgroundImage = Image.FromFile("santa.png");
                            Map[Moverow, Santa.Helyzet.Y].Background.BackgroundImageLayout = ImageLayout.Zoom;
                            Map[Moverow, Santa.Helyzet.Y].Name = "Santa";
                            Santa.Helyzet.X = Moverow;
                        }
                        else
                        {
                            Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackColor = Color.Wheat;
                            Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackgroundImage = null;
                            Map[Moverow, Santa.Helyzet.Y].Background.BackgroundImage = Image.FromFile("santa.png");
                            Map[Moverow, Santa.Helyzet.Y].Background.BackgroundImageLayout = ImageLayout.Zoom;
                            Map[Moverow, Santa.Helyzet.Y].Name = "Santa";
                            Santa.Helyzet.X = Moverow;
                        }
                    }
                    else
                    {
                        Timer.Stop();
                        MessageBox.Show("Akadály!!");
                    }
                }
                else
                {
                    Timer.Stop();
                    MessageBox.Show("Fal!!");
                }
            }
            //Right
            if (key == Keys.D || key == Keys.Right)
            {
                Movecolumn = Santa.Helyzet.Y + 1;
                if (Santa.Helyzet.Y < Size - 2)
                {
                    if (FieldCheck(Movecolumn))
                    {
                        if (PresentCheck(Movecolumn))
                        {
                            Present++;
                            if (Present % 5 == 0)
                            {
                                Point++;
                            }
                            else
                            {
                                Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackColor = Color.Wheat;
                            }
                            PresentLBL.Text = $"{Present}";
                            PointLBL.Text = $"{Point}";
                            GeneratePresent();

                            Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackColor = Color.Wheat;
                            Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackgroundImage = null;
                            Map[Santa.Helyzet.X, Movecolumn].Background.BackgroundImage = Image.FromFile("santa_j.png");
                            Map[Santa.Helyzet.X, Movecolumn].Background.BackgroundImageLayout = ImageLayout.Zoom;
                            Map[Santa.Helyzet.X, Movecolumn].Name = "Santa";

                            Santa.Helyzet.Y = Movecolumn;
                        }
                        else
                        {
                            Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackColor = Color.Wheat;
                            Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackgroundImage = null;
                            Map[Santa.Helyzet.X, Movecolumn].Background.BackgroundImage = Image.FromFile("santa_j.png");
                            Map[Santa.Helyzet.X, Movecolumn].Background.BackgroundImageLayout = ImageLayout.Zoom;
                            Map[Santa.Helyzet.X, Movecolumn].Name = "Santa";
                            Santa.Helyzet.Y = Movecolumn;
                        }
                    }
                    else
                    {
                        Timer.Stop();
                        MessageBox.Show("Akadály!!");
                    }
                }
                else
                {
                    Timer.Stop();
                    MessageBox.Show("Fal!!");
                }
            }
            //Left
            if (key == Keys.A || key == Keys.Left)
            {
                Movecolumn = Santa.Helyzet.Y - 1;
                if (Santa.Helyzet.Y > 1)
                {
                    if (FieldCheck(Movecolumn))
                    {
                        if (PresentCheck(Movecolumn))
                        {
                            Present++;
                            if (Present % 5 == 0)
                            {
                                Point++;
                            }
                            else
                            {
                                Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackColor = Color.Wheat;
                            }
                            PresentLBL.Text = $"{Present}";
                            PointLBL.Text = $"{Point}";
                            GeneratePresent();

                            Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackColor = Color.Wheat;
                            Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackgroundImage = null;
                            Map[Santa.Helyzet.X, Movecolumn].Background.BackgroundImage = Image.FromFile("santa.png");
                            Map[Santa.Helyzet.X, Movecolumn].Background.BackgroundImageLayout = ImageLayout.Zoom;
                            Map[Santa.Helyzet.X, Movecolumn].Name = "Santa";
                            Santa.Helyzet.Y = Movecolumn;
                        }
                        Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackColor = Color.Wheat;
                        Map[Santa.Helyzet.X, Santa.Helyzet.Y].Background.BackgroundImage = null;
                        Map[Santa.Helyzet.X, Movecolumn].Background.BackgroundImage = Image.FromFile("santa.png");
                        Map[Santa.Helyzet.X, Movecolumn].Background.BackgroundImageLayout = ImageLayout.Zoom;
                        Map[Santa.Helyzet.X, Movecolumn].Name = "Santa";

                        Santa.Helyzet.Y = Movecolumn;
                    }
                    else
                    {
                        Timer.Stop();
                        MessageBox.Show("Akadály!!");
                    }
                }
                else
                {
                    Timer.Stop();
                    MessageBox.Show("Fal!!");
                }
            }

           
        }

  

        private bool PresentCheck(int check)
        {
            if (key == Keys.A || key == Keys.Left ||
                key == Keys.D || key == Keys.Right)
            {
                if (Map[Santa.Helyzet.X,check].Name == "Present")
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (Map[check,Santa.Helyzet.Y].Name == "Present")
                {
                    return true;
                }
                return false;
            }
        }

        private bool FieldCheck(int check)
        {
            if (key == Keys.A || key == Keys.Left ||
                key == Keys.D || key == Keys.Right)
            {
                if (Map[Santa.Helyzet.X, check].Name == "Obstacle")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (Map[check, Santa.Helyzet.Y].Name == "Obstacle")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }


        }
    }
}
