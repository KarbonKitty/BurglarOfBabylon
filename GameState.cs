using System.Collections.Generic;
using System.Linq;
using BurglarOfBabylon.AI;
using BurglarOfBabylon.Maps;
using RogueSheep;
using RogueSheep.Display;
using RogueSheep.Schedulers;

namespace BurglarOfBabylon
{
    public class GameState
    {
        public Map CurrentMap { get; set; }
        public Actor Player { get; set; }
        public IScheduler<Actor> Scheduler { get; }
        public int AlertLevel { get; set; }

        public GameState()
        {
            Player = new Actor("Bob", (58, 58), new GameTile(CP437Glyph.AtSign, RogueColor.Lime), Direction.North, new PlayerBrain(), ActorRole.Inflirtator);
            Player.Inventory.Add(ItemDefinitions.SignalJammer);

            var actors = new List<Actor>
            {
                Player,
                new Actor("Random guard", (11, 10), new GameTile(CP437Glyph.CapitalG, RogueColor.DarkMagenta), Direction.North, new WanderBrain(), ActorRole.Guard),
                new Actor("Another random guard", (52, 52), new GameTile(CP437Glyph.CapitalG, RogueColor.Magenta), Direction.North, new WanderBrain(), ActorRole.Guard)
            };

            Scheduler = new RoundRobinScheduler<Actor>();
            Scheduler.AddRange(actors);

            var mapObjects = Office.Tiles.Select(t => TileDefinitions.MapObjectMapping[t]).ToArray();

            CurrentMap = new Map(mapObjects, actors);
        }
    }
}
