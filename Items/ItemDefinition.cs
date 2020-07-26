using System;
using RogueSheep.Display;

namespace BurglarOfBabylon.Items
{
    public class ItemDefinition : IPresentable
    {
        public string Name { get; }
        public GameTile Presentation { get; }
        public Action<Actor, GameState>? Usage { get; protected set; }
        public int? MaxUses { get; }

        public ItemDefinition(string name, GameTile presentation, Action<Actor, GameState>? use = null, int? maxUses = null)
        {
            Name = name;
            Presentation = presentation;
            Usage = use;
            MaxUses = maxUses;
        }

        public ItemDefinition(ItemDefinition itemToClone)
        {
            Name = itemToClone.Name;
            Presentation = new GameTile(itemToClone.Presentation);
            Usage = itemToClone.Usage;
            MaxUses = itemToClone.MaxUses;
        }
    }
}
