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
    public partial class GameOverPage : Popup
    {
        /// <summary>
        /// constructor
        /// </summary>
        public GameOverPage()
        {
            InitializeComponent();
            Initialize();
        }

        /// <summary>
        /// Initialize element page
        /// </summary>
        private async void Initialize()
        {
            App.DisplayDatabase = await App.Database.GetDisplayAsync(1);
            lblBetterScore.Text = App.DisplayDatabase.HighScore.ToString();
            lblScore.Text = App.Snake.NbEatFood.ToString();
            App.Snake.WallCollisionSnake.ValueGameOver = false;
        }

        /// <summary>
        /// Button => home page
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
        /// Button => main page
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