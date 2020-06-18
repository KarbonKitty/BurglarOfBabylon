using System;

namespace BurglarOfBabylon.Commands
{
    public static class CommandProcessor
    {
        public static bool ProcessCommand(Command command, GameState state) => command switch
        {
            MoveCommand m => ProcessMoveCommand(m, state),
            NullCommand _ => true,
            _ => throw new InvalidOperationException("This type of command is not yet handled")
        };

        private static bool ProcessMoveCommand(MoveCommand moveCommand, GameState state)
        {
            var newPosition = moveCommand.Originator!.Position + moveCommand.Vector;
            if (state.CurrentMap.IsAvailableForMove(newPosition))
            {
                return moveCommand.Originator!.Move(moveCommand.Vector);
            }
            return false;
        }
    }
}
