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
        public string CurrentMapName { get; private set; }
        public Map CurrentMap { get; private set; }
        public Actor Player { get; set; }
        public IScheduler<Actor> Scheduler { get; }
        public int AlertLevel { get; set; }
        public MessageBuffer Messages { get; }
        public DateTime CurrentTime { get; set; }

        // TODO: should each actor have this? or list of visibile tiles?
        public GameGrid<bool> PlayerVisibilityGrid { get; set; }

        public GameState()
        {
            var dto = DateTimeOffset.FromUnixTimeSeconds(int.MaxValue);
            CurrentTime = dto.DateTime;
            Messages = new MessageBuffer(DisplayConsts.MessageDisplaySize.Y - 2);
            Player = new Actor("Bob", (58, 58), new GameTile(CP437Glyph.AtSign, RogueColor.Lime), Direction.North, new PlayerBrain(), ActorRole.Inflirtator);
            Player.Inventory.Add(new Item(ItemDefinitions.Watch));

            Scheduler = new RoundRobinScheduler<Actor>();

            ChangeMap(MapData.Floor38);

            PlayerVisibilityGrid = new GameGrid<bool>(CurrentMap.Size);
        }

        public void ChangeMap(MapDefinition mapDefinition)
        {
            Scheduler.Clear();

            CurrentMapName = mapDefinition.Name;
            var mapObjects = mapDefinition.Tiles.Select(t => TileDefinitions.MapObjectMapping[t]).ToArray();
            var allActors = new List<Actor>(mapDefinition.NPCs) { Player };
            CurrentMap = new Map(mapObjects, allActors, mapDefinition.Items);
            Player.Place(mapDefinition.PlayerStartingPosition);

            Scheduler.AddRange(allActors);
        }
    }
}
