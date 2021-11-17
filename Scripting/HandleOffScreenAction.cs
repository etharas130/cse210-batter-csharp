using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;


namespace cse210_batter_csharp.Scripting
{
    /// <summary>
    /// An action to move all actors forward according to their current velocities.
    /// </summary>
    public class HandleOffScreenAction : Action
    {
        private int _xPosition;
        private int _yPosition;

        AudioService _audioService = new AudioService();
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            foreach (Actor ball in cast["balls"])
            {
                _xPosition = ball.GetX();
                _yPosition = ball.GetY();
                Ball b = (Ball)ball;

                if (_xPosition < 0 || _xPosition > Constants.MAX_X - Constants.BALL_WIDTH)
                {
                    b.BounceHorizontal();
                    _audioService.PlaySound(Constants.SOUND_BOUNCE);
                } 
                else if ( _yPosition < 0 || _yPosition > Constants.MAX_Y - Constants.BALL_HEIGHT)
                {
                    b.BounceVertical();
                    _audioService.PlaySound(Constants.SOUND_BOUNCE);
                }
            }
        }
    }
}