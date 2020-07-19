using System;
using RogueSheep.Display;

namespace BurglarOfBabylon.Items
{
    public class Item : IPresentable
    {
        public string Name { get; }
        public GameTile Presentation { get; }
        protected virtual Action<Actor, GameState>? Usage { get; set; }

        public Item(string name, GameTile presentation, Action<Actor, GameState>? use = null)
        {
            Name = name;
            Presentation = presentation;
            Usage = use;
        }

        public Item(Item itemToClone)
        {
            Name = itemToClone.Name;
            Presentation = new GameTile(itemToClone.Presentation);
            Usage = itemToClone.Usage;
        }

        public virtual void Use(Actor user, GameState state)
        {
            if (CanBeUsed())
            {
                Usage!(user, state);
            }
        }

        public bool CanBeUsed() => Usage != null;
    }
}
