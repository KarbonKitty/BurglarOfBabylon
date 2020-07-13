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

        private Command HandleGeneralCase(KeyEventArgs e)
        {
            if (KeyToDirection(e) != Direction.None)
            {
                return new MoveCommand(gameState.Player, KeyToDirection(e));
            }

            return e.Code switch
            {
                Keyboard.Key.Numpad5 => new WaitCommand(gameState.Player),
                Keyboard.Key.Space => new WaitCommand(gameState.Player),
                Keyboard.Key.Comma => new PickUpCommand(gameState.Player),

                Keyboard.Key.U => SwitchToState(InputState.UseInDirection),

                Keyboard.Key.I => SwitchToState(InputState.UseFromInventory),

                _ => new NullCommand()
            };
        }

        private Command HandleUseInDirection(KeyEventArgs e)
        {
            State = InputState.General;
            if (KeyToDirection(e) != Direction.None)
            {
                return new InteractionCommand(gameState.Player, KeyToDirection(e));
            }
            return new NullCommand();
        }

        private Direction KeyToDirection(KeyEventArgs key) =>
        key.Code switch
        {
            Keyboard.Key.Up => Direction.North,
            Keyboard.Key.Down => Direction.South,
            Keyboard.Key.Left => Direction.West,
            Keyboard.Key.Right => Direction.East,

            Keyboard.Key.W => Direction.North,
            Keyboard.Key.S => Direction.South,
            Keyboard.Key.A => Direction.West,
            Keyboard.Key.D => Direction.East,

            Keyboard.Key.Numpad7 => Direction.NorthWest,
            Keyboard.Key.Numpad8 => Direction.North,
            Keyboard.Key.Numpad9 => Direction.NorthEast,
            Keyboard.Key.Numpad4 => Direction.West,
            Keyboard.Key.Numpad6 => Direction.East,
            Keyboard.Key.Numpad1 => Direction.SouthWest,
            Keyboard.Key.Numpad2 => Direction.South,
            Keyboard.Key.Numpad3 => Direction.SouthEast,

            Keyboard.Key.K => Direction.North,
            Keyboard.Key.J => Direction.South,
            Keyboard.Key.H => Direction.West,
            Keyboard.Key.L => Direction.East,

            _ => Direction.None
        };

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
            State = state;
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
