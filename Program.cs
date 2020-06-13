using System;
using RogueSheep.Display;
using SFML.Graphics;

namespace BurglarOfBabylon
{
    internal static class Program
    {
        private static RenderWindow window;
        private static GameDisplay mainDisplay;
        private static void Main()
        {
            window = WindowBuilder.CreateWindow("Burglar of Babylon", 16 * 60, 16 * 60);
            var mapTilemapConfiguration = new TilemapConfiguration(16, 16, 16, 16);
            mainDisplay = new GameDisplay((60, 60), (0, 0), mapTilemapConfiguration);

            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear();

                mainDisplay.Draw("Hello world!", (4, 4), Color.Cyan, Color.White);
                mainDisplay.DrawToWindow(window);

                window.Display();
            }
        }
    }
}
