using System;
using cse210_batter_csharp.Services;
using cse210_batter_csharp.Casting;
using cse210_batter_csharp.Scripting;
using cse210_batter_csharp.Review;
using System.Collections.Generic;

namespace cse210_batter_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            static void BeginningLadderSteps()
            {
                Student person1 = new Student();
                person1.SetFirstName("Bob");
                person1.SetLastName("Par");
                person1.SetGPA(1.5);
                

                Student person2 = new Student();
                person2.SetFirstName("Sam");
                person2.SetLastName("Sparks");
                person2.SetGPA(4.0);

                Student person3 = new Student();
                person3.SetFirstName("Carl");
                person3.SetLastName("Gibbons");
                person3.SetGPA(3.5);

                List<Student> _students = new List<Student>();

                _students.Add(person1);
                _students.Add(person2);
                _students.Add(person3);

                static void DisplayPeople(List<Student> theStudents)
                {
                    foreach (Student s in theStudents)
                    {
                        Console.WriteLine($"This person's name is {s.GetFirstName()} {s.GetLastName()}.");
                        Console.WriteLine($"Their GPA is {s.GetGPA()}");
                    }
                }

                DisplayPeople(_students);
            }
            BeginningLadderSteps();

            // Create the cast
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();

            // Bricks
            cast["bricks"] = new List<Actor>();
            List<Brick> _bricks = new List<Brick>();

            for(int y = 0; y < 120; y+=30)
            {
                for (int x = 50; x < 760; x+=55)
                {
                    Brick _brick = new Brick();
                    Point _point = new Point(x, y);
                    _brick.SetPosition(_point);

                    cast["bricks"].Add(_brick);
                }
            }
            
            foreach (Brick b in _bricks)
            {
                Console.WriteLine($"({b.GetX()}, {b.GetY()})");
            }

            // The Ball (or balls if desired)
            cast["balls"] = new List<Actor>();

            Ball _ball = new Ball();
            Point _ballPoint = new Point(Constants.MAX_X / 2, Constants.MAX_Y / 2);
            _ball.SetPosition(_ballPoint);


            cast["balls"].Add(_ball);

            // The paddle
            cast["paddle"] = new List<Actor>();

            // TODO: Add your paddle here

            // Create the script
            Dictionary<string, List<Action>> script = new Dictionary<string, List<Action>>();

            OutputService outputService = new OutputService();
            InputService inputService = new InputService();
            PhysicsService physicsService = new PhysicsService();
            AudioService audioService = new AudioService();

            script["output"] = new List<Action>();
            script["input"] = new List<Action>();
            script["update"] = new List<Action>();

            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            script["output"].Add(drawActorsAction);

            // TODO: Add additional actions here to handle the input, move the actors, handle collisions, etc.

            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "Batter", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            audioService.StopAudio();

        }
    }
}
