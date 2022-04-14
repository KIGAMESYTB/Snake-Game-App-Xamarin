using Snake_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Snake_Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : Popup
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Settings()
        {
            InitializeComponent();
            Initialize();
        }

        /// <summary>
        /// Initialize element page
        /// </summary>
        private void Initialize()
        {
            if (App.MusicDatabase.ValueMusic)
                btnMusic.Source = App.MusicDatabase.FileNameImage_Audio;
            else
                btnMusic.Source = App.MusicDatabase.FileNameImage_NoAudio;

            if (App.MusicDatabase.ValueSfx)
                btnSfx.Source = App.MusicDatabase.FileNameImage_Audio;
            else
                btnSfx.Source = App.MusicDatabase.FileNameImage_NoAudio;

        }

        /// <summary>
        /// Button Music
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMusic_Clicked(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            App.MusicDatabase.ValueMusic = !App.MusicDatabase.ValueMusic;
            App.Database.SaveMusicAsync(App.MusicDatabase);
            if (App.MusicDatabase.ValueMusic)
            {
                btn.Source = App.MusicDatabase.FileNameImage_Audio;
                App.SoundsMusic.Play();
            }
            else
            {
                btn.Source = App.MusicDatabase.FileNameImage_NoAudio;
                App.SoundsMusic.Stop();
            }
        }

        /// <summary>
        /// Button Sfx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSfx_Clicked(object sender, EventArgs e)
        {
            App.MusicDatabase.ValueSfx = !App.MusicDatabase.ValueSfx;
            App.Database.SaveMusicAsync(App.MusicDatabase);
            Initialize();
        }

        /// <summary>
        /// Close popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Clicked(object sender, EventArgs e)
        {
            Dismiss(null);
        }


        /// <summary>
        /// My Youtube Channel [Contact]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [Obsolete]
        private void BtnYtb_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://www.youtube.com/channel/UCj4n4EOMt4DxHtqM2P5B-hw"));
        }
    }
}