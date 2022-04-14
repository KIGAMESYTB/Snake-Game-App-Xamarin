using Android.Media;
using Plugin.SimpleAudioPlayer;
using Snake_Game.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Snake_Game
{
    public partial class MainPage : ContentPage
    {
        #region Variable

        int valueSwipe = -2;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            Initialize();
        }

        /// <summary>
        /// Initialize element page
        /// </summary>
        private async void Initialize()
        {
            imageFood.Source = App.DisplayDatabase.ImageChoose;
            imageTouch.Source = App.DisplayDatabase.TouchChoose;
            App.Snake.Create(AbsoluteLayoutAreaGame);
            App.Snake.LblScore = lblScore;
            App.Snake.LblBetterScore = lblBetterScore;
            TouchInitialize();
            SoundInitialize();
            App.DisplayDatabase = await App.Database.GetDisplayAsync(1);
            App.MusicDatabase = await App.Database.GetMusicAsync(1);
            lblBetterScore.Text = App.DisplayDatabase.HighScore.ToString();
        }

        /// <summary>
        /// Initialize sound
        /// </summary>
        private void SoundInitialize()
        {
            App.SoundsMusic.Load(App.MusicDatabase.FileNameMusic_Game);
            App.SoundsMusic.Loop = App.MusicDatabase.MusicLoop;
            if (App.MusicDatabase.ValueMusic)
                App.SoundsMusic.Play();
        }

        /// <summary>
        /// touch initialize
        /// </summary>
        private void TouchInitialize()
        {
            if (App.DisplayDatabase.TouchChoose == "touchButton.PNG")
                btnButtons.IsVisible = true;
        }

        /// <summary>
        /// Vibrate button
        /// </summary>
        private void Vibrate()
        {
            var duration = TimeSpan.FromMilliseconds(50);
            Vibration.Vibrate(duration);
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.ShowPopup(new PausePage());
            return true;

        }

        /// <summary>
        /// Buttons enabled
        /// </summary>
        private void BtnEnabled()
        {
            btnDown.IsEnabled = true;
            btnLeft.IsEnabled = true;
            btnRight.IsEnabled = true;
            btnUp.IsEnabled = true;
        }

        #region Button Touch Movements

        private void BtnUp_Clicked(object sender, EventArgs e)
        {
            BtnEnabled();
            Vibrate();
            App.Snake.Movement("up");
            btnDown.IsEnabled = false;
        }

        private void BtnLeft_Clicked(object sender, EventArgs e)
        {
            BtnEnabled();
            Vibrate();
            App.Snake.Movement("left");
            btnRight.IsEnabled = false;
        }

        private void BtnDown_Clicked(object sender, EventArgs e)
        {
            BtnEnabled();
            Vibrate();
            App.Snake.Movement("down");
            btnUp.IsEnabled = false;
        }

        private void BtnRight_Clicked(object sender, EventArgs e)
        {
            BtnEnabled();
            Vibrate();
            App.Snake.Movement("right");
            btnLeft.IsEnabled = false;
        }

        #endregion


        #region Slide Touch Movements 

        private void OnSwiped(object sender, SwipedEventArgs e)
        {
            if(App.DisplayDatabase.TouchChoose == "touchSlide.png" && valueSwipe >= -1)
            {
                Vibrate();
                switch (e.Direction)
                {
                    case SwipeDirection.Left:
                        if(valueSwipe != 0)
                        {
                            App.Snake.Movement("left");
                            valueSwipe = 1;
                        }
                        break;
                    case SwipeDirection.Right:
                        if(valueSwipe != 1)
                        {
                            App.Snake.Movement("right");
                            valueSwipe = 0;
                        }
                        break;
                    case SwipeDirection.Up:
                        if(valueSwipe != 2)
                        {
                            App.Snake.Movement("up");
                            valueSwipe = 3;
                        }
                        break;
                    case SwipeDirection.Down:
                        if(valueSwipe != 3)
                        {
                            App.Snake.Movement("down");
                            valueSwipe = 2;
                        }
                        break;
                }
            }
        }

        #endregion

        /// <summary>
        /// Button Pause
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPause_Clicked(object sender, EventArgs e)
        {
            if (App.MusicDatabase.ValueSfx)
            {
                var tappedSounds = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                tappedSounds.Load("ButtonOver.wav");
                tappedSounds.Play();
            }
            App.Snake.Stop();
            Navigation.ShowPopup(new PausePage());
        }

        /// <summary>
        /// Button Start gameplay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnStart_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            App.DisplayDatabase.WidthArea = AbsoluteLayoutAreaGame.Width;
            App.DisplayDatabase.HeightArea = AbsoluteLayoutAreaGame.Height;
            await App.Database.SaveDisplayAsync(App.DisplayDatabase);

            App.DisplayDatabase = await App.Database.GetDisplayAsync(1);
            App.Snake.HeightOnWidth = App.DisplayDatabase.WidthArea / App.DisplayDatabase.HeightArea;

            imageTouch.IsVisible = false;
            btnPause.IsEnabled = true;
            btn.IsVisible = false;
            valueSwipe = -1;
            App.Snake.Start();
            BtnEnabled();
            btnRight.IsEnabled = false;
            btn.IsVisible = false;
        }
    }
}
