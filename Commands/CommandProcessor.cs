using System;

namespace BurglarOfBabylon.Commands
{
    public static class CommandProcessor
    {
        public static bool ProcessCommand(Command command, GameState state) => command switch
        {
            MoveCommand m => ProcessMoveCommand(m),
            NullCommand n => true,
            _ => throw new InvalidOperationException("This type of command is not yet handled")
        };

        private static bool ProcessMoveCommand(MoveCommand moveCommand) => moveCommand.Originator!.Move(moveCommand.Vector);
    }
}
