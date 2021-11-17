using System;

namespace cse210_batter_csharp.Casting
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class Brick : Actor
    {

        public Brick()
        {
            SetImage(Constants.IMAGE_BRICK);
            SetHeight(Constants.BRICK_HEIGHT);
            SetWidth(Constants.BRICK_WIDTH);
        }
    }
}