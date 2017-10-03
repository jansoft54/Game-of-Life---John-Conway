using SFML.Window;
using SFML.Audio;
using SFML.Graphics;

namespace GameOfLive
{
    class Entry
    {
       public const int width = 800;
        public const int height = 800;
        static void Main(string[] args)
        {
           
            Manager man = new Manager(800, 800, "GOL");
            man.Run();
        }
    }
}
