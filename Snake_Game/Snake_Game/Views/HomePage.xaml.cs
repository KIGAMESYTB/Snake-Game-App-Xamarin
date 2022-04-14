using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Snake_Game.Models;
using Plugin.SimpleAudioPlayer;
using Xamarin.CommunityToolkit.Extensions;
using Snake_Game.Views;
using Snake_Game.Services.Database;

namespace Snake_Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public HomePage()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Initialize element page
        /// </summary>
        private async void Initialize()
        {
            App.MusicDatabase = await App.Database.GetMusicAsync(1);
            App.DisplayDatabase = await App.Database.GetDisplayAsync(1);
            App.SoundsMusic.Load(App.MusicDatabase.FileNameMusic_Menu);
            App.SoundsMusic.Loop = App.MusicDatabase.MusicLoop;
            App.Snake.WallCollisionSnake.ValueGameOver = false;
            if (App.MusicDatabase.ValueMusic)
            {
                App.SoundsMusic.Play();
            }
        }

        /// <summary>
        /// Reload page
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            InitializeColorBackLabel();
            lblPlay.BackgroundColor = Color.Red;
            Initialize();
        }

        /// <summary>
        /// Button menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnTapped(object sender, EventArgs e)
        {
            InitializeColorBackLabel();
            Label lbl = (Label)sender;
            lbl.BackgroundColor = Color.Red;
            MusicTapped();
            switch (lbl.Text.ToLower())
            {
                case "play":
                    App.SoundsMusic.Stop();
                    await Navigation.PushAsync(new MainPage());
                    break;
                case "display":
                    Navigation.ShowPopup(new DisplayPage());
                    break;
                case "high score":
                    Navigation.ShowPopup(new HighScorePage());
                    break;
                case "settings":
                    Navigation.ShowPopup(new Settings());
                    break;
                case "exit":
                    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                    break;
            }
        }

        /// <summary>
        /// button Sfx
        /// </summary>
        private void MusicTapped()
        {
            if (App.MusicDatabase.ValueSfx)
            {
                var tappedSounds = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                tappedSounds.Load("ButtonOver.wav");
                tappedSounds.Play();
            }
        }

        /// <summary>
        /// Initialize color back button
        /// </summary>
        private void InitializeColorBackLabel()
        {
            List<Label> labelOption = new List<Label>() {lblPlay, lblSettings, lblDisplay, lblHighScore, lblExit };
            foreach (var lbl in labelOption)
                lbl.BackgroundColor = Color.Transparent;
        }
    }
}