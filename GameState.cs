using System;
using System.Collections.Generic;
using System.Linq;
using BurglarOfBabylon.AI;
using BurglarOfBabylon.Items;
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
        public MessageBuffer Messages { get; }
        public DateTime CurrentTime { get; set; }

        public GameState()
        {
            var dto = DateTimeOffset.FromUnixTimeSeconds(int.MaxValue);
            CurrentTime = dto.DateTime;
            Messages = new MessageBuffer(DisplayConsts.MessageDisplaySize.Y - 2);
            Player = new Actor("Bob", (58, 58), new GameTile(CP437Glyph.AtSign, RogueColor.Lime), Direction.North, new PlayerBrain(), ActorRole.Inflirtator);
            Player.Inventory.Add(ItemDefinitions.Watch);

            var actors = new List<Actor>
            {
                Player,
                new Actor("Third random guard", (31, 50), new GameTile(CP437Glyph.CapitalG, RogueColor.Magenta), Direction.North, new PatrolBrain((31, 50), (51, 30)), ActorRole.Guard),
                new Actor("Fourth random guard", (22, 10), new GameTile(CP437Glyph.CapitalG, RogueColor.Magenta), Direction.North, new PatrolBrain((22, 10), (51, 30)), ActorRole.Guard),
                new Actor("Random guard", (5, 23), new GameTile(CP437Glyph.CapitalG, RogueColor.DarkMagenta), Direction.North, new PatrolBrain((5, 23), (5, 38)), ActorRole.Guard),
                new Actor("Another random guard", (1, 42), new GameTile(CP437Glyph.CapitalG, RogueColor.Magenta), Direction.North, new PatrolBrain((1, 42), (19, 58)), ActorRole.Guard),
            };

            Scheduler = new RoundRobinScheduler<Actor>();
            Scheduler.AddRange(actors);

            var mapObjects = Office.Tiles.Select(t => TileDefinitions.MapObjectMapping[t]).ToArray();

            var onMapItems = new Dictionary<Point2i, Item> {
                [(40, 40)] = ItemDefinitions.SignalJammer
            };

            CurrentMap = new Map(mapObjects, actors, onMapItems);
        }
    }
}
