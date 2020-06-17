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
                // GetViewport with the same request size
                // as the size of the map will always return full map
                // so we can pass anything we want as the center
                mainDisplay.Draw(gameState.CurrentMap.GetViewport(mainDisplay.Size, (0, 0)), (0, 0));

                // then we draw all the actors on top of stuff
                foreach (var actor in gameState.CurrentMap.Actors)
                {
                    mainDisplay.Draw(actor.Presentation, actor.Position);
                }

                // and finally blit this all to the window
                mainDisplay.DrawToWindow(window);

                window.Display();
            }
        }
    }
}
