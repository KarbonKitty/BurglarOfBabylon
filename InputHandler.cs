using SFML.Window;

namespace BurglarOfBabylon
{
    public class InputHandler
    {
        private readonly GameState gameState;

        public InputHandler(GameState gameState)
        {
            this.gameState = gameState;
        }

        public void Window_KeyPressed(object? sender, KeyEventArgs e)
        {
            switch (e.Code)
            {
                case Keyboard.Key.Up:
                    gameState.Player.Move((0, -1));
                    break;
                case Keyboard.Key.Down:
                    gameState.Player.Move((0, 1));
                    break;
                case Keyboard.Key.Left:
                    gameState.Player.Move((-1, 0));
                    break;
                case Keyboard.Key.Right:
                    gameState.Player.Move((1, 0));
                    break;
            }
        }
    }
}
