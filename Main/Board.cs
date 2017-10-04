using System;
using SFML.Graphics;
using SFML.Window;

namespace GameOfLive
{
    class Board
    {
        public static Color Deathcolor = new Color(100,100,100);
        public static Color Lifecolor = new Color(0, 0, 0);
        public static Vector2f vector;
        public static RectangleShape rect;

        public Board() {
            vector = new Vector2f(800 / Screen.cellsperDim, 800 / Screen.cellsperDim);
            rect = new RectangleShape(new Vector2f(800 / Screen.cellsperDim, 800 / Screen.cellsperDim));
            rect.Position = vector;
        }
        public RectangleShape[,] Rectangle
        {
            get;
            private set;
        }
        public void AddQuads( Screen screen)
        {
            Rectangle = new RectangleShape[Screen.cellsperDim, Screen.cellsperDim];
            for (uint j = 0; j < Screen.cellsperDim; ++j)
            {
                for (int i = 0; i < Screen.cellsperDim; ++i)
                {
                    Rectangle[j, i] = new RectangleShape(new Vector2f(800 / Screen.cellsperDim, 800 / Screen.cellsperDim));
                    Rectangle[j, i].Position = new Vector2f(i * (800 / Screen.cellsperDim), j * (800 / Screen.cellsperDim));
                    Rectangle[j, i].FillColor= screen.Cells[j, i] == 0 ? Deathcolor : Lifecolor;
                       }
            }

        }
    }
}
