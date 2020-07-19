using System;
using RogueSheep.Display;

namespace BurglarOfBabylon.Items
{
    public class Item : IPresentable
    {
        public string Name { get; }
        public GameTile Presentation { get; }
        public Action<Actor, GameState> Use { get; }

        public Item(string name, GameTile presentation, Action<Actor, GameState> use)
        {
            Name = name;
            Presentation = presentation;
            Use = use;
        }
    }
}
