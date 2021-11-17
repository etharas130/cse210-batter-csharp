using System;

namespace cse210_batter_csharp.Casting
{
    /// <summary>
    /// Base class for all actors in the game.
    /// </summary>
    public class Ball : Actor 
    {
        public Ball()
        {
            SetWidth(Constants.BALL_WIDTH);
            SetHeight(Constants.BALL_HEIGHT);
            SetImage(Constants.IMAGE_BALL);

            Point newVelocity = new Point(5,5);
            SetVelocity(newVelocity);
        }
        public void BounceHorizontal()
        {
            int dx = _velocity.GetX();
            int dy = _velocity.GetY();

            _velocity = new Point (-dx, dy);
        }
        public void BounceVertical()
        {
            int dx = _velocity.GetX();
            int dy = _velocity.GetY();

            _velocity = new Point (dx, -dy);
        }
    }
}