using RogueSheep;

namespace BurglarOfBabylon
{
    public static class DisplayConsts
    {
        public const string GameTitle = "Burglar of Babylon";
        public const int MainFontWidth = 16;
        public const int TextFontWidth = 10;
        public const int MainFontHeight = 16;
        public const int MainDisplayWidthInTiles = 60;
        public const int TextDisplayWidthInTiles = 80;
        public const int BorderDisplayWidthInTiles = 1;
        public const int MainDisplayHeightInTiles = 60;
        public static uint WindowWidth => MainFontWidth * MainDisplayWidthInTiles + MainFontWidth * BorderDisplayWidthInTiles + TextFontWidth * TextDisplayWidthInTiles;
        public static uint WindowHeight => MainFontHeight * MainDisplayHeightInTiles;

        public const int FontColumns = 16;
        public const int FontRows = 16;

        public readonly static Point2i MainDisplaySize = (MainDisplayWidthInTiles, MainDisplayHeightInTiles);
        public readonly static Point2i MainDisplayOffset = (0, 0);

        public readonly static Point2i BorderDisplaySize = (BorderDisplayWidthInTiles, MainDisplayHeightInTiles);
        public readonly static Point2i BorderDisplayOffset = (MainDisplayWidthInTiles * MainFontWidth, 0);

        public readonly static Point2i MessageDisplaySize = (TextDisplayWidthInTiles, MainDisplayHeightInTiles);
        public readonly static Point2i MessageDisplayOffset = ((MainDisplayWidthInTiles + BorderDisplayWidthInTiles) * MainFontWidth, 0);
    }
}
