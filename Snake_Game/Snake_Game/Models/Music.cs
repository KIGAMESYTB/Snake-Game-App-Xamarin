using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace Snake_Game.Models
{
    public class Music
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        public bool ValueMusic { get; set; } = true;

        public bool ValueSfx { get; set; } = true;

        public string FileNameMusic_Menu { get; set; } = "Music_Menu.wav";

        public string FileNameMusic_Game { get; set; } = "Music_Game.mp3";

        public bool MusicLoop { get; private set; } = true;

        public string FileNameImage_Audio { get; private set; } = "audio.png";
        public string FileNameImage_NoAudio { get; private set; } = "NoAudio.png";
    }
}
