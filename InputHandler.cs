using BurglarOfBabylon.Commands;
using SFML.Window;

namespace BurglarOfBabylon
{
    public class InputHandler
    {
        private readonly GameState gameState;

        public InputHandler(GameState gameState)
        {
            this.gameState = gameState;
        }

        public void Window_KeyPressed(object? sender, KeyEventArgs e)
        {
            Command command = e.Code switch
            {
                Keyboard.Key.Up => new MoveCommand(gameState.Player, (0, -1)),
                Keyboard.Key.Down => new MoveCommand(gameState.Player, (0, 1)),
                Keyboard.Key.Left => new MoveCommand(gameState.Player, (-1, 0)),
                Keyboard.Key.Right => new MoveCommand(gameState.Player, (1, 0)),
                _ => new NullCommand()
            };

            CommandProcessor.ProcessCommand(command, gameState);
        }
    }
}
