using System;
using BurglarOfBabylon.AI;
using BurglarOfBabylon.Commands;
using RogueSheep;
using SFML.Window;

namespace BurglarOfBabylon
{
    public class InputHandler
    {
        private readonly GameState gameState;
        public InputState State { get; private set; }

        public InputHandler(GameState gameState)
        {
            this.gameState = gameState;
        }

        public void Window_KeyPressed(object? sender, KeyEventArgs e)
        {
            Command command = State switch
            {
                InputState.General => HandleGeneralCase(e),
                InputState.UseInDirection => HandleUseInDirection(e),
                InputState.UseFromInventory => HandleUseFromInventory(e),

                _ => throw new InvalidOperationException("Only named enum values should be used")
            };

            if (gameState.Player.Brain is PlayerBrain)
            {
                (gameState.Player.Brain as PlayerBrain)!.StoredCommand = command;
            }
        }

        private Command HandleGeneralCase(KeyEventArgs e) => e.Code switch
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

            Keyboard.Key.U => SwitchToState(InputState.UseInDirection),

            Keyboard.Key.I => SwitchToState(InputState.UseFromInventory),

            _ => new NullCommand()
        };

        private Command HandleUseInDirection(KeyEventArgs e)
        {
            State = InputState.General;
            return e.Code switch
            {
                Keyboard.Key.Up => new InteractionCommand(gameState.Player, Direction.North),
                Keyboard.Key.Down => new InteractionCommand(gameState.Player, Direction.South),
                Keyboard.Key.Left => new InteractionCommand(gameState.Player, Direction.West),
                Keyboard.Key.Right => new InteractionCommand(gameState.Player, Direction.East),

                Keyboard.Key.Numpad7 => new InteractionCommand(gameState.Player, Direction.NorthWest),
                Keyboard.Key.Numpad8 => new InteractionCommand(gameState.Player, Direction.North),
                Keyboard.Key.Numpad9 => new InteractionCommand(gameState.Player, Direction.NorthEast),
                Keyboard.Key.Numpad4 => new InteractionCommand(gameState.Player, Direction.West),
                Keyboard.Key.Numpad6 => new InteractionCommand(gameState.Player, Direction.East),
                Keyboard.Key.Numpad1 => new InteractionCommand(gameState.Player, Direction.SouthWest),
                Keyboard.Key.Numpad2 => new InteractionCommand(gameState.Player, Direction.South),
                Keyboard.Key.Numpad3 => new InteractionCommand(gameState.Player, Direction.SouthEast),

                _ => new NullCommand()
            };
        }

        private Command HandleUseFromInventory(KeyEventArgs e)
        {
            State = InputState.General;

            if ((int)e.Code >= 27 && (int)e.Code <= 36)
            {
                var inventoryPosition = (int)e.Code - 27;
                if (gameState.Player.Inventory.Count > inventoryPosition)
                {
                    return new UseCommand(gameState.Player, gameState.Player.Inventory[inventoryPosition]);
                }
            }

            return new NullCommand();
        }

        private Command SwitchToState(InputState state)
        {
            this.State = state;
            return new NullCommand();
        }
    }

    public enum InputState
    {
        General,
        UseInDirection,
        UseFromInventory
    }
}
