using System;
using System.Linq;
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
            PickUpCommand p => ProcessPickUpCommand(p, state),
            ItemUsedUpCommand iuu => ProcessItemUsedUpCommand(iuu),
            LookCommand l => ProcessLookCommand(l, state),
            TalkCommand t => ProcessTalkCommand(t, state),
            WaitCommand _ => true,
            NullCommand _ => false,
            _ => throw new InvalidOperationException("This type of command is not yet handled")
        };

        private static bool ProcessTalkCommand(TalkCommand talkCommand, GameState state)
        {
            var talkTarget = state.CurrentMap.Actors.SingleOrDefault(a => a.Position == talkCommand.TargetPosition);
            if (talkTarget is null)
            {
                return false;
            }

            state.Messages.Push($"{talkTarget.Name} says: {talkTarget.Talk()}");
            return true;
        }

        private static bool ProcessPickUpCommand(PickUpCommand pickUpCommand, GameState state)
        {
            if (pickUpCommand.Originator is null)
            {
                return false;
            }
            var actorPosition = pickUpCommand.Originator.Position;
            if (state.CurrentMap.Items.TryGetValue(actorPosition, out var item))
            {
                pickUpCommand.Originator.Inventory.Add(item);
                state.CurrentMap.Items.Remove(actorPosition);
                return true;
            }
            return false;
        }

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

        private static bool ProcessItemUsedUpCommand(ItemUsedUpCommand itemUsedUpCommand)
        {
            if (itemUsedUpCommand.Originator is null)
            {
                throw new ArgumentNullException(nameof(itemUsedUpCommand.Originator));
            }

            itemUsedUpCommand.Originator.Inventory.Remove(itemUsedUpCommand.ItemUsedUp);

            return false;
        }

        private static bool ProcessLookCommand(LookCommand lookCommand, GameState state)
        {
            if (lookCommand.Originator != state.Player)
            {
                return false;
            }

            if (state.PlayerVisibilityGrid[lookCommand.Position])
            {
                var actor = state.CurrentMap.Actors.FirstOrDefault(a => a.Position == lookCommand.Position);
                if (actor != null)
                {
                    state.Messages.Push($"{actor.Name} is standing here.");
                }

                if (state.CurrentMap.Items.TryGetValue(lookCommand.Position, out var item))
                {
                    state.Messages.Push($"There is a {item.Name} lying here.");
                }
            }

            state.Messages.Push(state.CurrentMap.GetDescription(lookCommand.Position));

            return false;
        }
    }
}
