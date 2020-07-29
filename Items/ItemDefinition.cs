using System;
using RogueSheep;
using RogueSheep.Display;

namespace BurglarOfBabylon.Items
{
    public class ItemDefinition : IPresentable
    {
        public string Name { get; }
        public GameTile Presentation { get; }
        public Action<Actor, GameState>? Usage { get; }
        public int? MaxUses { get; }
        public Action<Actor, Direction, GameState>? DirectionalUsage { get; }

        public ItemDefinition(string name, GameTile presentation, Action<Actor, GameState>? use = null, int? maxUses = null, Action<Actor, Direction, GameState>? directionalUse = null)
        {
            Name = name;
            Presentation = presentation;
            Usage = use;
            MaxUses = maxUses;
            DirectionalUsage = directionalUse;
        }

        public ItemDefinition(ItemDefinition itemToClone)
        {
            Name = itemToClone.Name;
            Presentation = new GameTile(itemToClone.Presentation);
            Usage = itemToClone.Usage;
            MaxUses = itemToClone.MaxUses;
            DirectionalUsage = itemToClone.DirectionalUsage;
        }
    }
}
