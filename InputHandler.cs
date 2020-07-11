using BurglarOfBabylon.AI;
using BurglarOfBabylon.Commands;
using RogueSheep;
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
                Keyboard.Key.Up => new MoveCommand(gameState.Player, Direction.North),
                Keyboard.Key.Down => new MoveCommand(gameState.Player, Direction.South),
                Keyboard.Key.Left => new MoveCommand(gameState.Player, Direction.West),
                Keyboard.Key.Right => new MoveCommand(gameState.Player, Direction.East),

                Keyboard.Key.Numpad7 => new MoveCommand(gameState.Player, Direction.NorthWest),
                Keyboard.Key.Numpad8 => new MoveCommand(gameState.Player, Direction.North),
                Keyboard.Key.Numpad9 => new MoveCommand(gameState.Player, Direction.NorthEast),
                Keyboard.Key.Numpad4 => new MoveCommand(gameState.Player, Direction.West),
                Keyboard.Key.Numpad6 => new MoveCommand(gameState.Player, Direction.East),
                Keyboard.Key.Numpad1 => new MoveCommand(gameState.Player, Direction.SouthWest),
                Keyboard.Key.Numpad2 => new MoveCommand(gameState.Player, Direction.South),
                Keyboard.Key.Numpad3 => new MoveCommand(gameState.Player, Direction.SouthEast),

                Keyboard.Key.Numpad5 => new WaitCommand(gameState.Player),
                Keyboard.Key.Space => new WaitCommand(gameState.Player),

                _ => new NullCommand()
            };

            if (gameState.Player.Brain is PlayerBrain)
            {
                (gameState.Player.Brain as PlayerBrain)!.StoredCommand = command;
            }
        }
    }
}
