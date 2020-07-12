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
            UseCommand u => ProcessUseCommand(u, state),
            WaitCommand _ => true,
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
                return ProcessInteractionCommand(new InteractionCommand(moveCommand.Originator, moveCommand.Direction), state);
            }
            return false;
        }

        private static bool ProcessInteractionCommand(InteractionCommand interactionCommand, GameState state)
        {
            if (interactionCommand.Originator is null)
            {
                return false;
            }

            var targetPosition = interactionCommand.Originator.Position.Transform(interactionCommand.TargetDirection);

            var interactiveObject = state.CurrentMap.GetActualObject(targetPosition);
            if (interactiveObject.Interaction is null)
            {
                return false;
            }

            interactionCommand.Originator?.Rotate(interactionCommand.TargetDirection);

            return interactiveObject.Interaction(interactionCommand.Originator, targetPosition, state);
        }

        private static bool ProcessUseCommand(UseCommand useCommand, GameState state)
        {
            if (useCommand.Originator is null)
            {
                return false;
            }

            useCommand.Item.Use(useCommand.Originator, state);
            return true;
        }
    }
}
