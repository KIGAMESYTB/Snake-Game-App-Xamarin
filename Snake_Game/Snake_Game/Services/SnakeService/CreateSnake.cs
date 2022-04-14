using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Snake_Game.Services
{
    public class CreateSnake
    {
        #region Variable
        private Random Random { get; set; }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public CreateSnake()
        {
            Random = new Random();
        }

        /// <summary>
        /// Head Snake 
        /// </summary>
        /// <param name="rectangle">Position and size rectangle</param>
        /// <returns>image head snake</returns>
        public Image HeadSnake(Rectangle rectangle)
        {
            Image Head = new Image { Source = "head_left.png" };
            AbsoluteLayout.SetLayoutBounds(Head, rectangle);
            AbsoluteLayout.SetLayoutFlags(Head, AbsoluteLayoutFlags.All);

            App.ListSnake.Add(Head);

            return Head;
        }

        /// <summary>
        /// Body Snake
        /// </summary>
        /// <param name="rectangle">Position and size rectangle</param>
        /// <returns>image body snake</returns>
        public Image BodySnake(Rectangle rectangle)
        {
            Image Body = new Image { Source = "body.png" };
            AbsoluteLayout.SetLayoutBounds(Body, rectangle);
            AbsoluteLayout.SetLayoutFlags(Body, AbsoluteLayoutFlags.All);

            App.ListSnake.Add(Body);

            return Body;
        }

        /// <summary>
        /// Food to snake
        /// </summary>
        /// <returns>image food</returns>
        public Image EatFood()
        {
            Image Food = new Image { Source = App.DisplayDatabase.ImageChoose };
            double x = Random.Next(100);
            double y = Random.Next(100);
            Console.WriteLine($"X : {x} // Y : {y}");
            AbsoluteLayout.SetLayoutBounds(Food, new Rectangle(x/100,y/100, 0.08, 0.08));
            AbsoluteLayout.SetLayoutFlags(Food, AbsoluteLayoutFlags.All);

            App.Snake.PositionFood = Food;
            return Food;
        }
    }
}
