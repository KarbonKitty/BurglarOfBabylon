using System;
using RogueSheep;
using RogueSheep.Display;
using SFML.Graphics;
using SFML.Window;

namespace BurglarOfBabylon
{
    internal static class Program
    {
        private static RenderWindow window;
        private static GameDisplay mainDisplay;
        private static Point2i playerPosition;

        private static void Main()
        {
            window = WindowBuilder.CreateWindow("Burglar of Babylon", 16 * 60, 16 * 60);
            var mapTilemapConfiguration = new TilemapConfiguration(16, 16, 16, 16);
            mainDisplay = new GameDisplay((60, 60), (0, 0), mapTilemapConfiguration);
            playerPosition = (4, 4);
            window.KeyPressed += Window_KeyPressed;

            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear();

                mainDisplay.Clear();
                mainDisplay.Draw("@", playerPosition, Color.Green, new RogueColor(127, 127, 127));
                mainDisplay.DrawToWindow(window);

                window.Display();
            }
        }

        private static void Window_KeyPressed(object? sender, KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Keyboard.Key.Up:
                    playerPosition += (0, -1);
                    break;
                case Keyboard.Key.Down:
                    playerPosition += (0, 1);
                    break;
                case Keyboard.Key.Left:
                    playerPosition += (-1, 0);
                    break;
                case Keyboard.Key.Right:
                    playerPosition += (1, 0);
                    break;
            }
        }
    }
}
