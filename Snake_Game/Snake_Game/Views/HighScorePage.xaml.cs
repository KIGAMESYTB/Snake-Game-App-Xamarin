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
    public partial class HighScorePage : Popup
    {
        /// <summary>
        /// constructor
        /// </summary>
        public HighScorePage()
        {
            InitializeComponent();
            Initialize();
        }

        /// <summary>
        /// initialize element page
        /// </summary>
        private void Initialize()
        {
            lblHighScore.Text = App.DisplayDatabase.HighScore.ToString();
        }

        /// <summary>
        /// Button close popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Clicked(object sender, EventArgs e)
        {
            Dismiss(null);
        }
    }
}