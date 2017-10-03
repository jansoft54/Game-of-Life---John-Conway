using System;
using SFML.Graphics;
using SFML.Window;
namespace GameOfLive
{
    class Cell
    {
        //On Cell is currently 16x16
        static Random random = new Random();
        static Color death = new Color(100, 100, 100);
        static Color life = new Color(0, 0, 0);
        public Cell(float x, float y)
        {

            byte num = (byte)random.Next(0, 11);
            byte color = (byte)(num < 5 ? 0 : 100);

            DeathColor = death;
            LifeColor = life;

            RectangleShape rec = new RectangleShape(new Vector2f(800/Screen.cellsperDim, 800 / Screen.cellsperDim));
            rec.FillColor =  DeathColor ;
            rec.Position = new Vector2f(x, y);

            cell = rec;
            IsDead = true;
          
        }
        public Color DeathColor { get; set; }
        public Color LifeColor { get; set; }
        public bool IsDead
        {
            get;
            set;
        }
        public RectangleShape cell
        {
            get;
            set;
        }

    }
}
