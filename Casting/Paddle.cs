using System;

namespace cse210_batter_csharp.Casting
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class Paddle : Actor
    {
        public Paddle()
        {
            SetHeight(Constants.PADDLE_HEIGHT);
            SetWidth(Constants.PADDLE_WIDTH);
            SetImage(Constants.IMAGE_PADDLE);
        }
    }
}