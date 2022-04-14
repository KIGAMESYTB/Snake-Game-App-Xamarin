using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Snake_Game.Services
{
    public class Snake
    {
        #region Variable

        private CreateSnake CreateSnake { get; set; }
        private MovementSnake MovementSnake { get; set; }
        public CollisionSnake WallCollisionSnake { get; set; }
        public double SpeedX { get; set; }
        public double SpeedY { get; set; }
        public double HeightOnWidth { get; set; }
        private bool ValueStop { get; set; }

        public Image PositionFood;
        public int NbEatFood { get; set; }
        public AbsoluteLayout Absolute { get; set; }

        public Label LblScore { get; set; }

        public Label LblBetterScore { get; set; }
        #endregion


        /// <summary>
        /// Constructor
        /// </summary>
        public Snake()
        {
            CreateSnake = new CreateSnake();
            MovementSnake = new MovementSnake();
            WallCollisionSnake = new CollisionSnake();
            SpeedX = -0.05;
            SpeedY = 0;
            NbEatFood = 0;
            ValueStop = false;
            PositionFood = new Image();
        }


        /// <summary>
        /// Create Snake
        /// </summary>
        /// <param name="absoluteLayout"></param>
        public void Create(AbsoluteLayout absoluteLayout)
        {
            //Snake
            var rectangle = new Rectangle(0.5, 0.5, 0.05, 0.05);
            absoluteLayout.Children.Add(CreateSnake.HeadSnake(rectangle));
            rectangle.X += rectangle.Width;
            absoluteLayout.Children.Add(CreateSnake.BodySnake(rectangle));
            rectangle.X += rectangle.Width;
            absoluteLayout.Children.Add(CreateSnake.BodySnake(rectangle));
            rectangle.X += rectangle.Width;
            absoluteLayout.Children.Add(CreateSnake.BodySnake(rectangle));
            rectangle.X += rectangle.Width;
            absoluteLayout.Children.Add(CreateSnake.BodySnake(rectangle));
            rectangle.X += rectangle.Width;

            //FruitToEat
            absoluteLayout.Children.Add(CreateSnake.EatFood());
            Absolute = absoluteLayout;

        }

        /// <summary>
        /// Delete Snake
        /// </summary>
        public void Delete()
        {
            foreach (var snake in App.ListSnake)
                Absolute.Children.Remove(snake);
            App.ListSnake.Clear();
            SpeedX = -0.05;
            SpeedY = 0;
            NbEatFood = 0;
        }

        /// <summary>
        /// Movement Snake
        /// </summary>
        /// <param name="move"></param>
        public void Movement(string move)
        {
            switch (move)
            {
                case "up":
                    MovementSnake.MovementUp();
                    break;
                case "down":
                    MovementSnake.MovementDown();
                    break;
                case "left":
                    MovementSnake.MovementLeft();
                    break;
                case "right":
                    MovementSnake.MovementRight();
                    break;
                default:
                    Console.WriteLine("Error Command");
                    break;
            }
        }

        /// <summary>
        /// Start game
        /// </summary>
        public void Start()
        {
            ValueStop = false;
            MoveTempo();
        }

        /// <summary>
        /// Stop game
        /// </summary>
        public void Stop()
        {
            ValueStop = true;
        }

        /// <summary>
        /// Time move snake
        /// </summary>
        private void MoveTempo()
        {
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 50), () => {
                var rectangleHead = AbsoluteLayout.GetLayoutBounds(App.ListSnake[0]);
                var ancien = rectangleHead;
                for (int i = 0; i < App.ListSnake.Count; i++)
                {
                    if (i == 0)
                    {
                        rectangleHead.X += + SpeedX;
                        rectangleHead.Y += SpeedY;
                        AbsoluteLayout.SetLayoutBounds(App.ListSnake[i], rectangleHead);
                        AbsoluteLayout.SetLayoutFlags(App.ListSnake[i], AbsoluteLayoutFlags.All);
                    }
                    else
                    {
                        var yes = ancien;
                        ancien = AbsoluteLayout.GetLayoutBounds(App.ListSnake[i]);
                        App.ListSnake[i].Source = "body.png";
                        AbsoluteLayout.SetLayoutBounds(App.ListSnake[i], yes);
                        AbsoluteLayout.SetLayoutFlags(App.ListSnake[i], AbsoluteLayoutFlags.All);
                    }
                }
                WallCollisionSnake.CollisionBody();
                WallCollisionSnake.CollisionFood();
                WallCollisionSnake.CollisionWall();
                return !ValueStop;
            });
        }
    }
}
