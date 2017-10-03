using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Threading;

namespace GameOfLive
{
    class Manager
    {
        private const float timebetweenFrame = 1 / 60f * 1000f;
        private List<Cell> aliveCells = new List<Cell>();
        public Manager(uint width, uint height, string name)
        {

            Window = (new RenderWindow(new VideoMode(width, height), name));
            Screen = new Screen();
            Screen.DrawLines();
            Screen.AddCells();
            Mouse m = new Mouse();
            Window.SetFramerateLimit(30);

        }
        public RenderWindow Window
        {
            get;
            set;
        }
        private Screen Screen
        {
            get;
            set;
        }

        public void Draw() { }
        public void Update()
        {

            int Mx = Mouse.GetPosition(Window).X;
            int My = Mouse.GetPosition(Window).Y;
           
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
                Screen.SetCell(Mx, My);
            if(Mouse.IsButtonPressed(Mouse.Button.Right))
           Screen.Update();

        }
        public void Run()
        {
            Window.Closed += (object sender, System.EventArgs e) => Window.Close();
                   
            while (Window.IsOpen())
            {
                Window.DispatchEvents();
                Window.Clear();

                Update();
                foreach (Cell cell in Screen.Cells)
                    Window.Draw(cell.cell);
                foreach (VertexArray va in Screen.Lines)
                    Window.Draw(va);

                Window.Display();
            }
        }


    }
}
