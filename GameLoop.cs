using BurglarOfBabylon.Commands;
using RogueSheep;
using RogueSheep.Display;
using RogueSheep.FieldOfView;
using SFML.Graphics;

namespace BurglarOfBabylon
{
    public class GameLoop
    {
        private readonly RenderWindow window;
        private readonly GameDisplay mainDisplay;
        private readonly GameDisplay borderDisplay;
        private readonly GameDisplay messageDisplay;
        private readonly GameState gameState;

        public GameLoop()
        {
            window = WindowBuilder.CreateWindow(DisplayConsts.GameTitle, DisplayConsts.WindowWidth, DisplayConsts.WindowHeight);
            var mapTilemapConfiguration = new TilemapConfiguration(DisplayConsts.MainFontHeight, DisplayConsts.MainFontWidth, DisplayConsts.FontRows, DisplayConsts.FontColumns);
            var textTilemapConfiguration = new TilemapConfiguration(DisplayConsts.MainFontHeight, DisplayConsts.TextFontWidth, DisplayConsts.FontRows, DisplayConsts.FontColumns);
            mainDisplay = new GameDisplay(DisplayConsts.MainDisplaySize, DisplayConsts.MainDisplayOffset, mapTilemapConfiguration);
            borderDisplay = new GameDisplay(DisplayConsts.BorderDisplaySize, DisplayConsts.BorderDisplayOffset, mapTilemapConfiguration);
            messageDisplay = new GameDisplay(DisplayConsts.MessageDisplaySize, DisplayConsts.MessageDisplayOffset, textTilemapConfiguration);

            for (var i = 0; i < DisplayConsts.MainDisplayHeightInTiles; i++)
            {
                borderDisplay.Draw(CP437Glyph.DoubleVerticalLine, (0, i), RogueColor.GreenYellow);
            }

            messageDisplay.Draw($"Hello to {DisplayConsts.GameTitle}", (1, 1));

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

                ProcessTurn();

                mainDisplay.Clear();
                // GetViewport with the same request size
                // as the size of the map will always return full map
                // so we can pass anything we want as the center
                var fovFactory = new BevelledWallShadowcasting(gameState.CurrentMap.TransparencyGrid);
                var visibilityGrid = fovFactory.Compute(gameState.Player.Position, 8);

                var viewport = gameState.CurrentMap.GetMaskedViewport(mainDisplay.Size, gameState.Player.Position, visibilityGrid);

                mainDisplay.Draw(viewport, (0, 0));

                // and finally blit this all to the window
                mainDisplay.DrawToWindow(window);

                borderDisplay.DrawToWindow(window);

                // TODO: clear and redraw each iteration
                messageDisplay.DrawToWindow(window);

                window.Display();
            }
        }

        private void ProcessTurn()
        {
            while (true)
            {
                var command = gameState.Scheduler.Current().Act(gameState);

                var turnEnded = CommandProcessor.ProcessCommand(command, gameState);

                if (turnEnded)
                {
                    gameState.Scheduler.Next();
                }
                else
                {
                    return;
                }
            }
        }
    }
}
