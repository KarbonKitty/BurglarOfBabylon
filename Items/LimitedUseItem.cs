using System;
using BurglarOfBabylon.Commands;
using RogueSheep.Display;

namespace BurglarOfBabylon.Items
{
    public class LimitedUseItem : Item
    {
        public int MaxCharges { get; }
        public int ChargesLeft { get; private set; }

        public LimitedUseItem(string name, GameTile presentation, Action<Actor, GameState> use, int maxCharges, int? chargesLeft = null) : base(name, presentation, use)
        {
            MaxCharges = maxCharges;
            ChargesLeft = chargesLeft ?? maxCharges;
        }

        public LimitedUseItem(LimitedUseItem itemToClone) : base(itemToClone)
        {
            MaxCharges = itemToClone.MaxCharges;
            ChargesLeft = itemToClone.ChargesLeft;
        }

        public override void Use(Actor user, GameState state)
        {
            if (CanBeUsed())
            {
                Usage!(user, state);
                ChargesLeft--;
                if (ChargesLeft == 0)
                {
                    CommandProcessor.ProcessCommand(new ItemUsedUpCommand(user, this), state);
                }
            }
        }
    }
}
