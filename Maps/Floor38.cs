using System;
using System.Collections.Generic;
using BurglarOfBabylon.AI;
using BurglarOfBabylon.Items;
using RogueSheep;

namespace BurglarOfBabylon.Maps
{
    public static partial class MapData
    {
        public static MapDefinition Floor38 = new MapDefinition
        (
            "Floor 38",
            (2, 18),
            new Actor[]
            {
                new Actor(
                    "Ivan",
                    (6, 18),
                    new RogueSheep.Display.GameTile(CP437Glyph.CapitalI, RogueColor.DarkRed),
                    Direction.South,
                    new PatrolBrain((6, 18), (6, 18)),
                    ActorRole.Friend,
                    new List<string> { "Go down the stairs when you are ready to start your mission." })
            },
            new Dictionary<Point2i, Item>(),
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "############################################################" +
            "#=.tS#=.tS#=.tS#=.tS#=.tS#=.tS#=.tS#=.tS#=.tS#=.tS#=.tS#>>>#" +
            "#=.ww#=.ww#=.ww#=.ww#=.ww#=.ww#=.ww#=.ww#=.ww#=.ww#=.ww#>>>#" +
            "#=...#=...#=...#=...#=...#=...#=...#=...#=...#=...#=...#>>>#" +
            "#T4s.#T4s.#T4s.#T4s.#T4s.#T4s.#T4s.#T4s.#T4s.#T4s.#T4s.#>>>#" +
            "####/####+####+####+####+####+####+####+####+####+####+#>>>#" +
            "#..........................................................#" +
            "#..........................................................#" +
            "#+####+####+####+####+####+####+####+####+####+####+####...#" +
            "#.s4T#.s4T#.s4T#.s4T#.s4T#.s4T#.s4T#.s4T#.s4T#.s4T#.s4T#...#" +
            "#...=#...=#...=#...=#...=#...=#...=#...=#...=#...=#...=#...#" +
            "#ww.=#ww.=#ww.=#ww.=#ww.=#ww.=#ww.=#ww.=#ww.=#ww.=#ww.=#...#" +
            "#St.=#St.=#St.=#St.=#St.=#St.=#St.=#St.=#St.=#St.=#St.=#...#" +
            "########################################################...#" +
            "#..........................................................#" +
            "#..........................................................#" +
            "########################################################...#" +
            "#=.tS#=.tS#=.tS#=.tS#=.tS#=.tS#=.tS#=.tS#=.tS#=.tS#=.tS#...#" +
            "#=.ww#=.ww#=.ww#=.ww#=.ww#=.ww#=.ww#=.ww#=.ww#=.ww#=.ww#...#" +
            "#=...#=...#=...#=...#=...#=...#=...#=...#=...#=...#=...#...#" +
            "#T4s.#T4s.#T4s.#T4s.#T4s.#T4s.#T4s.#T4s.#T4s.#T4s.#T4s.#...#" +
            "####+####+####+####+####+####+####+####+####+####+####+#...#" +
            "#..........................................................#" +
            "#..........................................................#" +
            "#+####+####+####+####+####+####+####+####+####+####+####<<<#" +
            "#.s4T#.s4T#.s4T#.s4T#.s4T#.s4T#.s4T#.s4T#.s4T#.s4T#.s4T#<<<#" +
            "#...=#...=#...=#...=#...=#...=#...=#...=#...=#...=#...=#<<<#" +
            "#ww.=#ww.=#ww.=#ww.=#ww.=#ww.=#ww.=#ww.=#ww.=#ww.=#ww.=#<<<#" +
            "#St.=#St.=#St.=#St.=#St.=#St.=#St.=#St.=#St.=#St.=#St.=#<<<#" +
            "############################################################" +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            " +
            "                                                            ");
    }
}
