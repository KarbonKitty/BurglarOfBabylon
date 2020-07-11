using System.Linq;
using BurglarOfBabylon.AI;
using BurglarOfBabylon.Commands;
using RogueSheep;
using RogueSheep.Display;
using RogueSheep.FieldOfView;
using SFML.Graphics;
using SFML.Window;

namespace BurglarOfBabylon
{
    public class GameLoop
    {
        private readonly RenderWindow window;
        private readonly GameDisplay mainDisplay;
        private readonly GameDisplay borderDisplay;
        private readonly GameDisplay hudDisplay;
        private readonly GameDisplay messageDisplay;
        private readonly GameState gameState;

        private bool CheckForAlertLevel = false;

        public GameLoop()
        {
            window = WindowBuilder.CreateWindow(DisplayConsts.GameTitle, DisplayConsts.WindowWidth, DisplayConsts.WindowHeight);
            var mapTilemapConfiguration = new TilemapConfiguration(DisplayConsts.MainFontHeight, DisplayConsts.MainFontWidth, DisplayConsts.FontRows, DisplayConsts.FontColumns);
            var textTilemapConfiguration = new TilemapConfiguration(DisplayConsts.MainFontHeight, DisplayConsts.TextFontWidth, DisplayConsts.FontRows, DisplayConsts.FontColumns);
            mainDisplay = new GameDisplay(DisplayConsts.MainDisplaySize, DisplayConsts.MainDisplayOffset, mapTilemapConfiguration);
            borderDisplay = new GameDisplay(DisplayConsts.BorderDisplaySize, DisplayConsts.BorderDisplayOffset, mapTilemapConfiguration);
            hudDisplay = new GameDisplay(DisplayConsts.HudDisplaySize, DisplayConsts.HudDisplayOffset, textTilemapConfiguration);
            messageDisplay = new GameDisplay(DisplayConsts.MessageDisplaySize, DisplayConsts.MessageDisplayOffset, textTilemapConfiguration);

            for (var i = 0; i < DisplayConsts.MainDisplayHeightInTiles; i++)
            {
                borderDisplay.Draw(CP437Glyph.DoubleVerticalLine, (0, i), RogueColor.GreenYellow);
            }

            messageDisplay.Draw($"Hello to {DisplayConsts.GameTitle}", (1, 1));

            gameState = new GameState();
            var inputHandler = new InputHandler(gameState);

            window.KeyPressed += inputHandler.Window_KeyPressed;
            window.MouseButtonPressed += Window_MouseButtonPressed;
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
                var visibilityGrid = fovFactory.Compute(gameState.Player.Position, 8, VisibilityAngle.HalfCircle, gameState.Player.Direction);

                var guardsVisibility = new GameGrid<bool>(gameState.CurrentMap.Size);

                foreach (var actor in gameState.CurrentMap.Actors)
                {
                    if (!(actor.Brain is PlayerBrain))
                    {
                        guardsVisibility = fovFactory.Compute(actor.Position, 6, VisibilityAngle.QuarterCircle, actor.Direction);
                    }
                }

                AlertLevelChecks(guardsVisibility);

                var viewport = gameState.CurrentMap.GetMaskedViewportWithViewcones(mainDisplay.Size, gameState.Player.Position, visibilityGrid, guardsVisibility);

                mainDisplay.Draw(viewport, (0, 0));

                // and finally blit this all to the window
                mainDisplay.DrawToWindow(window);

                borderDisplay.DrawToWindow(window);

                DisplayHud();
                hudDisplay.DrawToWindow(window);

                // TODO: clear and redraw each iteration
                messageDisplay.DrawToWindow(window);

                window.Display();
            }
        }

        private void DisplayHud()
        {
            hudDisplay.Clear();
            hudDisplay.Draw($"Alert level: {gameState.AlertLevel}/5", (1, 1));
            if (gameState.AlertLevel >= 5)
            {
                hudDisplay.Draw("You have caused an alarm and failed!", (1, 2), RogueColor.Red);
            }

            for (var i = 0; i < 6; i++)
            {
                if (gameState.Player.Inventory.Count > i)
                {
                    hudDisplay.Draw($"{i+1} - {gameState.Player.Inventory[i].Name}", (1, 4 + i));
                }
            }
        }

        private void AlertLevelChecks(GameGrid<bool> guardsVisibility)
        {
            if (CheckForAlertLevel && guardsVisibility[gameState.CurrentMap.Actors.Single(a => a.Role == ActorRole.Inflirtator).Position])
            {
                gameState.AlertLevel++;
            }

            CheckForAlertLevel = false;
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
                    if (gameState.Scheduler.Current().Role == ActorRole.Inflirtator)
                    {
                        CheckForAlertLevel = true;
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void Window_MouseButtonPressed(object? sender, MouseButtonEventArgs e)
        {
            if (e.X > mainDisplay.Offset.X && e.X < (mainDisplay.Offset.X + mainDisplay.SizePx.X)
                &&
                e.Y > mainDisplay.Offset.Y && e.Y < (mainDisplay.Offset.Y + mainDisplay.SizePx.Y))
            {
                messageDisplay.Clear();

                Point2i pixelPositionInside = (e.X - mainDisplay.Offset.X, e.Y - mainDisplay.Offset.Y);
                Point2i gridPositionInside = (pixelPositionInside.X / DisplayConsts.MainFontWidth, pixelPositionInside.Y / DisplayConsts.MainFontHeight);

                var description = gameState.CurrentMap.GetDescription(gridPositionInside);

                messageDisplay.Draw($"{description}", (1, 1));
            }
        }
    }
}
