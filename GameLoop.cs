using RogueSheep;
using RogueSheep.Display;
using SFML.Graphics;
using SFML.Window;

namespace BurglarOfBabylon
{
    public class GameLoop
    {
        private readonly RenderWindow window;
        private readonly GameDisplay mainDisplay;
        private static Point2i playerPosition;

        public GameLoop()
        {
            window = WindowBuilder.CreateWindow(DisplayConsts.GameTitle, DisplayConsts.WindowWidth, DisplayConsts.WindowHeight);
            var mapTilemapConfiguration = new TilemapConfiguration(DisplayConsts.MainFontHeight, DisplayConsts.MainFontWidth, DisplayConsts.FontRows, DisplayConsts.FontColumns);
            mainDisplay = new GameDisplay((DisplayConsts.MainDisplayWidthInTiles, DisplayConsts.MainDisplayHeightInTiles), (0, 0), mapTilemapConfiguration);

            playerPosition = (4, 4);

            window.KeyPressed += Window_KeyPressed;
        }

        public void Run()
        {
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
