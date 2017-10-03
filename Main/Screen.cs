using System;
using SFML.Graphics;
using SFML.Window;
namespace GameOfLive
{
    class Screen
    {
        public static  int cellsperDim = 100;
        private bool[,] cellsalive;
        public Screen()
        {

            Lines = new VertexArray[cellsperDim * 2];
            Cells = new Cell[cellsperDim, cellsperDim];
            cellsalive = new bool[cellsperDim, cellsperDim];
        }
        public VertexArray[] Lines
        {
            get;
            set;
        }
        public Cell[,] Cells
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
                    Cell cell = Cells[y, x];
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
                                Cell othercell = Cells[newY, newX];
                                if (!othercell.IsDead && othercell != cell)
                                    lifecounter++;
                            }
                        }


                    if (lifecounter < 2 && !cell.IsDead)
                    {                     
                        cellsalive[y, x] = false;
                    }
                    else if ((lifecounter == 2 || lifecounter == 3) && !cell.IsDead)
                    {                       
                        cellsalive[y, x] = true;
                    }
                    else if (lifecounter > 3 && !cell.IsDead)
                    {                     
                        cellsalive[y, x] = false;
                    }
                    else if (lifecounter == 3 && cell.IsDead)
                    {
                        cellsalive[y, x] = true;
                    }
                 

                }
            }
            for (int j = 0; j < cellsperDim; ++j)
            {
                for (int i = 0; i < cellsperDim; ++i)
                {
                    Cell cell = Cells[j, i];
                    cell.IsDead = !cellsalive[j, i];
                    cell.cell.FillColor = !cellsalive[j, i] ? cell.DeathColor : cell.LifeColor;

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
                    Cells[j, i] = new Cell(i * 800 / cellsperDim, j * 800 / cellsperDim);

                }
            }
        }

        public void SetCell(int x, int y)
        {
            int distance = 800 / cellsperDim;
            int Xdiff = x % (Entry.width/cellsperDim);
            int Ydiff = y % (Entry.height/cellsperDim);
            int newX = x - Xdiff;
            int newY = y - Ydiff;

            for (int j = 0; j < cellsperDim; ++j)
            {
                for (int i = 0; i < cellsperDim; ++i)
                {
                    if (Cells[j, i].cell.Position.X == newX && Cells[j, i].cell.Position.Y == newY)
                    {
                        Cells[j, i].cell.FillColor =  Cells[j, i].LifeColor ;
                        Cells[j, i].IsDead = false;
                    }

                }
            }
        }
    }

}
