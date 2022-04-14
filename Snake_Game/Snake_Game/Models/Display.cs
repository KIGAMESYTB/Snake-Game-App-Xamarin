using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace Snake_Game.Models
{
    public class Display
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        public bool FirstOpen { get; set; } = true;

        public double WidthArea { get; set; }

        public double HeightArea { get; set; }

        public int HighScore { get; set; } = 0;

        public string ImageChoose { get; set; }

        public string TouchChoose { get; set; }

        /* 0 => Touch Button
         * 1 => Touch Slide */
        public int Touch { get; set; } = 0;

        public bool FirstTouchButton { get; set; } = true;

        public bool FirstTouchSlide { get; set; } = true;
    }
}
