using System.Collections.Generic;
using System.Linq;
using BurglarOfBabylon.Items;
using BurglarOfBabylon.Maps;
using RogueSheep;
using RogueSheep.Display;
using RogueSheep.Maps;

namespace BurglarOfBabylon
{
    public class Map : GameMapBase<MapObject, Actor>
    {
        public Dictionary<Point2i, Item> Items { get; }

        public Map(MapObject[] tiles, IEnumerable<Actor> actors, IReadOnlyDictionary<Point2i, Item> items)
            : base(tiles,
                GameConsts.MapWidth,
                actors,
                new MapObject("hidden", "this is hidden from view",
                    new GameTile(CP437Glyph.AlmostEquals,
                        Colors.InvisibleLightGrey,
                        Colors.InvisibleDarkGrey)))
        {
            Items = new Dictionary<Point2i, Item>(items);
        }

        public string GetDescription(Point2i position) => MapMemory[position].Description;

        public void ReplaceObject(Point2i position, MapObject newObject)
        {
            Tiles[PositionToIndex(position)] = newObject;
            TransparencyGrid[position] = newObject.Transparent;
        }

        public bool IsInteractive(Point2i position) => Tiles[PositionToIndex(position)].Interaction != null;

        public GameTile[] GetMaskedViewportWithViewcones(Point2i size, Point2i position, GameGrid<bool> visibilityGrid, GameGrid<bool> guardVisibilityGrid)
        {
            var maskedViewport = GetMaskedViewport(size, position, visibilityGrid);

            foreach (var kvp in Items)
            {
                if (visibilityGrid[kvp.Key] && !Actors.Any(a => a.Position == kvp.Key))
                {
                    maskedViewport[PositionToIndex(kvp.Key)] = kvp.Value.Presentation;
                }
            }

            for (var i = 0; i < maskedViewport.Length; i++)
            {
                if (guardVisibilityGrid[i] && visibilityGrid[i])
                {
                    maskedViewport[i] = new GameTile(maskedViewport[i].Glyph, maskedViewport[i].Foreground, Colors.GuardVisibility);
                }
            }

            return maskedViewport;
        }

        public GameGrid<bool> GetPassabilityGrid()
        {
            var grid = new GameGrid<bool>(Size);
            for (var i = 0; i < Tiles.Length; i++)
            {
                // TODO: is there a better way?
                grid[i] = IsAvailableForMove(IndexToPosition(i)) || GetActualObject(IndexToPosition(i)) == TileDefinitions.Door;
            }
            return grid;
        }
    }
}
