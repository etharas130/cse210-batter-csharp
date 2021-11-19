using System.Collections.Generic;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Services;

namespace cse210_batter_csharp
{
    /// <summary>
    /// The base class of all other actions.
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        PhysicsService _physicsService = new PhysicsService();
        AudioService _audioService = new AudioService();
        public HandleCollisionsAction(PhysicsService physicsService)
        {
            _physicsService = physicsService;
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Actor paddle = cast["paddle"][0];
            Actor balls = cast["balls"][0];
            List<Actor> bricks = cast["bricks"];
            List<Actor> toRemove = new List<Actor>();   

            foreach (Actor ball in cast["balls"])
            {
                if(_physicsService.IsCollision(paddle, ball))
                {
                    Ball b = (Ball)ball;
                    b.BounceVertical();
                    _audioService.PlaySound(Constants.SOUND_BOUNCE);
                }
            }

            foreach (Actor brick in bricks)
            {
                if(_physicsService.IsCollision(balls, brick))
                {
                    Ball b = (Ball)balls;
                    b.BounceVertical();
                    _audioService.PlaySound(Constants.SOUND_BOUNCE);
                    toRemove.Add(brick);
                }
            }
            foreach (Actor brick in toRemove)
            {
                cast["bricks"].Remove(brick);
            }
        }
    }
}