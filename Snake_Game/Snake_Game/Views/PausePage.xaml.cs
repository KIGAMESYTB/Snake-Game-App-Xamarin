using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Snake_Game.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PausePage : Popup
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PausePage()
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
        /// Close popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Clicked(object sender, EventArgs e)
        {
            App.Snake.Start();
            Dismiss(null);
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
        /// Button => Home page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnHome_Clicked(object sender, EventArgs e)
        {
            App.Snake.Delete();
            await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            Dismiss(null);
        }

        /// <summary>
        /// Button Main Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnRestart_Clicked(object sender, EventArgs e)
        {
            App.Snake.Delete();
            await App.Current.MainPage.Navigation.PushAsync(new MainPage());
            Dismiss(null);

        }

    }
}