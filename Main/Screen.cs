using System;
using SFML.Graphics;
using SFML.Window;
namespace GameOfLive
{
    class Screen
    {
        public static int cellsperDim = 200;
        public static Random random = new Random();
        private bool[,] cellsalive;

        public Screen()
        {

            Lines = new VertexArray[cellsperDim * 2];
            Cells = new byte[cellsperDim, cellsperDim];
            cellsalive = new bool[cellsperDim, cellsperDim];
            AddCells();
        }
        public VertexArray[] Lines
        {
            get;
            set;
        }
        public byte[,] Cells
        {
            get;
            set;
        }


        public void Update()
        {


            for (int y = 0; y < cellsperDim; ++y)
            {
                for (int x = 0; x < cellsperDim; ++x)
                {
                    byte cell = Cells[y, x];
                    byte lifecounter = 0;
                    for (int k = 0; k < 3; ++k)
                        for (int m = 0; m < 3; ++m)
                        {
                            int x1 = x - 1;
                            int y1 = y - 1;

                            int newX = x1 + m;
                            int newY = y1 + k;

                            if (newX >= 0 && newY >= 0 && newX < cellsperDim && newY < cellsperDim)
                            {
                                byte othercell = Cells[newY, newX];
                                if (othercell == 1 && (newX != x || newY != y))
                                    lifecounter++;
                            }
                           
                        }
                 

                    if (lifecounter < 2 && cell != 0)
                    {
                        cellsalive[y, x] = false;
                    }
                    else if ((lifecounter == 2 || lifecounter == 3) && cell != 0)
                    {
                        cellsalive[y, x] = true;
                    }
                    else if (lifecounter > 3 && cell != 0)
                    {
                        cellsalive[y, x] = false;
                    }
                    else if (lifecounter == 3 && cell == 0)
                    {
                        cellsalive[y, x] = true;
                    }


                }
               
            }
            for (int j = 0; j < cellsperDim; ++j)
            {
                for (int i = 0; i < cellsperDim; ++i)
                    Cells[j, i] = (byte)(cellsalive[j, i] ? 1 : 0);
            }

        }
        public void DrawCells(RenderWindow window, Board board)
        {
            RectangleShape shape = Board.rect;
            for (int j = 0; j < cellsperDim; ++j)
            {
                for (int i = 0; i < cellsperDim; ++i)
                {
                    byte cell = Cells[j, i];
                   
                    Board.vector.Y = j * 800 / cellsperDim;
                    Board.vector.X = i * 800 / cellsperDim;
                    shape.Position = Board.vector;
                    shape.FillColor = cell == 0 ? Board.Deathcolor : Board.Lifecolor;
                    window.Draw(shape);

                }
            }
        }
        public void DrawLines()
        {
            for (int y = 0; y < cellsperDim; ++y)
                Lines[y] = GetVertexArray(0, y * 800 / cellsperDim, 800, y * 800 / cellsperDim);
            for (int x = 0; x < cellsperDim; ++x)
                Lines[x + cellsperDim] = GetVertexArray(x * 800 / cellsperDim, 0, x * 800 / cellsperDim, 800);

            VertexArray GetVertexArray(float v1x, float v1y, float v2x, float v2y)
            {
                VertexArray va = new VertexArray(PrimitiveType.Lines, 2);
                va.Append(new Vertex(new Vector2f(v1x, v1y)));
                va.Append(new Vertex(new Vector2f(v2x, v2y)));
                return va;
            }
        }
        public void AddCells()
        {

            for (int j = 0; j < cellsperDim; ++j)
            {
                for (int i = 0; i < cellsperDim; ++i)
                {
                    Cells[j, i] =(byte) random.Next(0,2);

                }
            }
        }

        public void SetCell(int x, int y, Board board)
        {
            int distance = 800 / cellsperDim;
            int Xdiff = x % (Entry.width / cellsperDim);
            int Ydiff = y % (Entry.height / cellsperDim);
            int newX = x - Xdiff;
            int newY = y - Ydiff;

            for (int j = 0; j < cellsperDim; ++j)
            {
                for (int i = 0; i < cellsperDim; ++i)
                {/*
                    if (board.Rectangle[j, i].Position.X == newX && board.Rectangle[j, i].Position.Y == newY)
                    {
                        board.Rectangle[j, i].FillColor = Cells[j, i] == 0 ? Board.Lifecolor : Board.Deathcolor;
                        Cells[j, i] = (byte)(Cells[j, i] == 0 ? 1 : 0);
                    }
                    */

                }

            }
        }

    }

}
