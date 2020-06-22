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

                Keyboard.Key.Numpad7 => new MoveCommand(gameState.Player, (-1, -1)),
                Keyboard.Key.Numpad8 => new MoveCommand(gameState.Player, (0, -1)),
                Keyboard.Key.Numpad9 => new MoveCommand(gameState.Player, (1, -1)),
                Keyboard.Key.Numpad4 => new MoveCommand(gameState.Player, (-1, 0)),
                Keyboard.Key.Numpad6 => new MoveCommand(gameState.Player, (1, 0)),
                Keyboard.Key.Numpad1 => new MoveCommand(gameState.Player, (-1, 1)),
                Keyboard.Key.Numpad2 => new MoveCommand(gameState.Player, (0, 1)),
                Keyboard.Key.Numpad3 => new MoveCommand(gameState.Player, (1, 1)),

                _ => new NullCommand()
            };

            CommandProcessor.ProcessCommand(command, gameState);
        }
    }
}
