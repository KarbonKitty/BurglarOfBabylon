using RogueSheep;
using RogueSheep.Display;
using SFML.Graphics;

namespace BurglarOfBabylon
{
    public class GameLoop
    {
        private readonly RenderWindow window;
        private readonly GameDisplay mainDisplay;
        private readonly GameState gameState;

        public GameLoop()
        {
            window = WindowBuilder.CreateWindow(DisplayConsts.GameTitle, DisplayConsts.WindowWidth, DisplayConsts.WindowHeight);
            var mapTilemapConfiguration = new TilemapConfiguration(DisplayConsts.MainFontHeight, DisplayConsts.MainFontWidth, DisplayConsts.FontRows, DisplayConsts.FontColumns);
            mainDisplay = new GameDisplay((DisplayConsts.MainDisplayWidthInTiles, DisplayConsts.MainDisplayHeightInTiles), (0, 0), mapTilemapConfiguration);

            gameState = new GameState();
            var inputHandler = new InputHandler(gameState);

            window.KeyPressed += inputHandler.Window_KeyPressed;
        }

        public void Run()
        {
            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear();

                mainDisplay.Clear();
                mainDisplay.Draw("@", gameState.PlayerPosition, Color.Green, new RogueColor(127, 127, 127));
                mainDisplay.DrawToWindow(window);

                window.Display();
            }
        }
    }
}
