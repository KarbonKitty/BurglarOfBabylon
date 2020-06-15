namespace BurglarOfBabylon
{
    public static class DisplayConsts
    {
        public const string GameTitle = "Burglar of Babylon";
        public const int MainFontWidth = 16;
        public const int MainFontHeight = 16;
        public const int MainDisplayWidthInTiles = 60;
        public const int MainDisplayHeightInTiles = 60;
        public static uint WindowWidth => MainFontWidth * MainDisplayWidthInTiles;
        public static uint WindowHeight => MainFontHeight * MainDisplayHeightInTiles;

        public const int FontColumns = 16;
        public const int FontRows = 16;
    }
}
