using System;
using RogueSheep;

namespace BurglarOfBabylon.Commands
{
    public static class CommandProcessor
    {
        public static bool ProcessCommand(Command command, GameState state) => command switch
        {
            MoveCommand m => ProcessMoveCommand(m, state),
            InteractionCommand i => ProcessInteractionCommand(i, state),
            NullCommand _ => false,
            _ => throw new InvalidOperationException("This type of command is not yet handled")
        };

        private static bool ProcessMoveCommand(MoveCommand moveCommand, GameState state)
        {
            var newPosition = moveCommand.Originator!.Position + moveCommand.Direction.Vector();
            if (state.CurrentMap.IsAvailableForMove(newPosition))
            {
                return moveCommand.Originator!.Move(moveCommand.Direction);
            }
            else if (state.CurrentMap.IsInteractive(newPosition))
            {
                return ProcessInteractionCommand(new InteractionCommand(moveCommand.Originator, newPosition), state);
            }
            return false;
        }

        private static bool ProcessInteractionCommand(InteractionCommand interactionCommand, GameState state)
        {
            var interactiveObject = state.CurrentMap.GetActualObject(interactionCommand.Target);
            if (interactiveObject.Interaction is null)
            {
                return false;
            }

            return interactiveObject.Interaction(interactionCommand.Originator, interactionCommand.Target, state);
        }
    }
}
