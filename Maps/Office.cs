using System.Collections.Generic;
using BurglarOfBabylon.AI;
using BurglarOfBabylon.Items;
using RogueSheep;
using RogueSheep.Display;

namespace BurglarOfBabylon.Maps
{
    public static partial class MapData
    {
        public static MapDefinition Office = new MapDefinition
        (
            "Office",
            (58, 58),
            new Actor[]
            {
                new Actor("Third random guard", (31, 50), new GameTile(CP437Glyph.CapitalG, RogueColor.Magenta), Direction.North, new PatrolBrain((31, 50), (51, 30)), ActorRole.Guard, new List<string>()),
                new Actor("Fourth random guard", (22, 10), new GameTile(CP437Glyph.CapitalG, RogueColor.Magenta), Direction.North, new PatrolBrain((22, 10), (51, 30)), ActorRole.Guard, new List<string>()),
                new Actor("Random guard", (5, 23), new GameTile(CP437Glyph.CapitalG, RogueColor.DarkMagenta), Direction.North, new PatrolBrain((5, 23), (5, 38)), ActorRole.Guard, new List<string>()),
                new Actor("Another random guard", (1, 42), new GameTile(CP437Glyph.CapitalG, RogueColor.Magenta), Direction.North, new PatrolBrain((1, 42), (19, 58)), ActorRole.Guard, new List<string>()),
            },
            new Dictionary<Point2i, Item>
            {
                [(40, 40)] = new LimitedUseItem((LimitedUseItem)ItemDefinitions.SignalJammer),
                [(57, 19)] = new LimitedUseItem((LimitedUseItem)ItemDefinitions.SignalJammer),
                [(58, 2)] = new LimitedUseItem((LimitedUseItem)ItemDefinitions.SignalJammer),
                [(19, 58)] = new LimitedUseItem((LimitedUseItem)ItemDefinitions.SignalJammer),
            },
            "############################################################" +
            "#M.#................#.....C#CCCCC#.....#csscccccccccc#CCCCC#" +
            "#..#................#..h..C#C...C#...h.#............c#.....#" +
            "##±#................#.DDD.C#C...C#..DDD#............c#..CCC#" +
            "#...................#.DDD..#C...C#.....#..44..4TT4..c#.....#" +
            "#...................#.....C#C...C#C..h.#..TT..4TT4..c#..CCC#" +
            "#...................#.....C#C...C#C..PP#..TT..4TT4..C#.....#" +
            "#...................#hTh..C#C...C#C..PP#..44..4TT4..C#..CCC#" +
            "#...................####+#####+#####+###++########++##+#####" +
            "#...................#..................#..4T4..P#........hD#" +
            "#...................±..................+.......P#.........D#" +
            "#...................±..................+.......P#..hDD...hD#" +
            "#...................#..................#CCCCC..P#...DDh...D#" +
            "#...................##+##############+#######++##++#########" +
            "#...................#s.#t#t#.S#t#t#t#.s#CCC....C#........hD#" +
            "#...................#s.#+#+#+##+#+#+#.s#.......C#....h....D#" +
            "#...................#s........#.......s#.DDD...C#....DD..hD#" +
            "#...................#s........#.......s#.DDD....#....DD...D#" +
            "#...................#s.#+#+#+##+#+#+#.s#..h...PP#.....h..hD#" +
            "#...................#s.#t#t#.S#t#t#t#.s#......PP#..P......D#" +
            "##########±±#####################################++#########" +
            "#..D..PP#....#ssssss#                  #>>>>.#........#ssss#" +
            "#.hD.hPP#....+......#                  #    .+........+....#" +
            "#..D....+....###..###                  #<<<<.#........#....#" +
            "#.......#....#t+..+t#                  #######........#+##+#" +
            "#....CCC#....#++..###                  #_____+........#t#t.#" +
            "#########....#t+..+t#                  #_____+........######" +
            "#CCCCCCC#....###..###                  #_____+........#CCCC#" +
            "#C......#....#t+..+t#                  #_____+........#...C#" +
            "#C......+....########                  #######........+...C#" +
            "#C......#....#S#..#S#                  #_____+........+...C#" +
            "#CCCCCCC#....#.+..+##                  #_____+........#...C#" +
            "#########....###..###                  #_____+........#CCCC#" +
            "#CCC.CCC#....#t+..+t#                  #_____+........######" +
            "#.......#....###..###                  #######........#t#t.#" +
            "#..DD...+....#t+..+t#                  #_____+........#+##+#" +
            "#.hDD..h#....###..###                  #_____+........#....#" +
            "#..DD..T#....+......#                  #_____+........+....#" +
            "#......h#....#ssssss#                  #_____+........#ssss#" +
            "##########++#####################################++#########" +
            "#DD#DD#DD#..#DD#DDDD#____#____#____#> <#...................#" +
            "#.h#.h#.h#..#h.#h.h.#____#____#____#> <#...................#" +
            "#...................#____#____#____#> <#.DD.DD...DD.DD...DD#" +
            "#h.#h.#h......h#.h.h#____#____#____#> <#..h..h....h..h....h#" +
            "#DD#DD#DD#..#DD#DDDD#____#____#____#...#.DD.DD...DD.DD...DD#" +
            "##########++#########++++#++++#++++##+##..h..h....h..h....h#" +
            "#.hDD....+..........+..................+...................#" +
            "#..DDh...+..........+..................+...................#" +
            "#........#cccc......#..................#.DD.DD...DD.DD...DD#" +
            "#........#...c......##................##..h..h....h..h....h#" +
            "#..DD....#..hc......##................##.DD.DD...DD.DD...DD#" +
            "#.hDDh...#..hc......#..................#..h..h....h..h....h#" +
            "#######..#...c......+..................+...................#" +
            "#.hDDh...#...,......+..................+...................#" +
            "#..DD....#############+######++######+##.DD.DD...DD.DD...DD#" +
            "#.................PP#s..+t#C....C#t+..s#..h..h....h..h....h#" +
            "#...................#s..###C....C###..s#.DD.DD...DD.DD...DD#" +
            "#..DDh...DDh...DD...#s..#t#C....C#t#..s#..h..h....h..h....h#" +
            "#.hDD...hDD...hDDh..#s..+.#CCCCCC#.+..s#...................#" +
            "############################################################");
    }
}
