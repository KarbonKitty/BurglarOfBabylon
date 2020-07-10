using System.Collections.Generic;
using BurglarOfBabylon.Maps;
using RogueSheep;
using RogueSheep.Display;
using RogueSheep.Maps;

namespace BurglarOfBabylon
{
    public class Map : GameMapBase<MapObject, Actor>
    {
        public Map(MapObject[] tiles, IEnumerable<Actor> actors)
            : base(tiles,
                GameConsts.MapWidth,
                actors,
                new MapObject("hidden", "this is hidden from view",
                    new GameTile(CP437Glyph.AlmostEquals,
                        Colors.InvisibleLightGrey,
                        Colors.InvisibleDarkGrey)))
        { }

        public string GetDescription(Point2i position) => MapMemory[position].Description;

        public void ReplaceObject(Point2i position, MapObject newObject)
        {
            Tiles[PositionToIndex(position)] = newObject;
            TransparencyGrid[position] = newObject.Transparent;
        }

        public bool IsInteractive(Point2i position) => Tiles[PositionToIndex(position)].Interaction != null;

        public GameTile[] GetMaskedViewportWithViewcones(Point2i size, Point2i position, GameGrid<bool> visibilityGrid, GameGrid<bool> guardVisibilityGrid)
        {
            var maskedViewport = base.GetMaskedViewport(size, position, visibilityGrid);

            for (var i = 0; i < maskedViewport.Length; i++)
            {
                if (guardVisibilityGrid[i] && visibilityGrid[i])
                {
                    maskedViewport[i] = new GameTile(maskedViewport[i].Glyph, maskedViewport[i].Foreground, Colors.GuardVisibility);
                }
            }

            return maskedViewport;
        }
    }
}
