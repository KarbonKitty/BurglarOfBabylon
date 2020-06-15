using RogueSheep;
using SFML.Window;

namespace BurglarOfBabylon
{
    public class GameState
    {
        public Point2i PlayerPosition { get; set; }

        public GameState()
        {
            PlayerPosition = (4, 4);
        }
    }
}
