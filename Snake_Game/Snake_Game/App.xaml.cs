using Plugin.SimpleAudioPlayer;
using Snake_Game.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Snake_Game.Services;
using System.IO;
using Snake_Game.Models;
using Snake_Game.Services.Database;

namespace Snake_Game
{
    public partial class App : Application
    {
        #region Variable        
        public static Snake Snake { get; set; }
        public static List<Image> ListSnake { get; set; }

        public static ISimpleAudioPlayer SoundsMusic { get; set; }

        public static SnakeDatabase Database { get; set; }

        public static Music MusicDatabase { get; set; }

        public static Display DisplayDatabase { get; set; }
        #endregion


        public App()
        {
            InitializeComponent();
            InitializeDatabase();
            Snake = new Snake();
            ListSnake = new List<Image>();
            SoundsMusic = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            MainPage = new NavigationPage(new HomePage());
        }

        /// <summary>
        /// Initialize Database
        /// </summary>
        private async void InitializeDatabase()
        {
            if (Database == null)
            {
                Database = new SnakeDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "snake.db3"));
                List<Music> ListMusic = await Database.GetMusicAsync();
                List<Display> ListDisplay = await Database.GetDisplayAsync();
                if (ListMusic.Count == 0)
                    await Database.SaveMusicAsync(new Music());
                if (ListDisplay.Count == 0)
                    await Database.SaveDisplayAsync(new Display());

            }

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            SoundsMusic.Stop();
        }

        protected override void OnResume()
        {
            SoundsMusic.Stop();
        }
    }
}
