using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Snake_Game.Services
{
    public class MovementSnake
    {
        /// <summary>
        /// Movement snake right
        /// </summary>
        public void MovementRight()
        {
            ImageElementSnake("head_right.png");
            App.Snake.SpeedX = 0.05;
            App.Snake.SpeedY  = 0;
        }

        /// <summary>
        /// Movement snake left
        /// </summary>
        public void MovementLeft()
        {
            ImageElementSnake("head_left.png");
            App.Snake.SpeedX = -0.05;
            App.Snake.SpeedY = 0;
        }

        /// <summary>
        /// Movement snake down
        /// </summary>
        public void MovementDown()
        {
            ImageElementSnake("head_down.png");
            App.Snake.SpeedX = 0;
            App.Snake.SpeedY = App.Snake.HeightOnWidth * 0.05;
        }

        /// <summary>
        /// Movement snake up
        /// </summary>
        public void MovementUp()
        {
            ImageElementSnake("head_up.png");
            App.Snake.SpeedX = 0;
            App.Snake.SpeedY = -App.Snake.HeightOnWidth * 0.05;
        }

        /// <summary>
        /// image head snake 
        /// </summary>
        /// <param name="sourceHead">filename image</param>
        private void ImageElementSnake(String sourceHead)
        {
            App.ListSnake[0].Source = sourceHead;
        }
    }
}
