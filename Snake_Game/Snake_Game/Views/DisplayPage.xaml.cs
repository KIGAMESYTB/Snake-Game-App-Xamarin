using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Snake_Game.Models;
using Snake_Game.Services;

namespace Snake_Game.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayPage : Popup
    {
        /// <summary>
        /// constructor
        /// </summary>
        public DisplayPage()
        {
            InitializeComponent();
            Initialize();
        }

        /// <summary>
        /// initialize element page
        /// </summary>
        private void Initialize()
        {
            SelectFood();
            SelectTouch();
        }

        /// <summary>
        /// Select food
        /// </summary>
        private void SelectFood()
        {
            boxThreeFood.BackgroundColor = Color.WhiteSmoke;
            boxFirstFood.BackgroundColor = Color.WhiteSmoke;
            boxSecondFood.BackgroundColor = Color.WhiteSmoke;

            if (App.DisplayDatabase.ImageChoose == btnFirstFood.Source.ToString().Replace("File: ", ""))
                boxFirstFood.BackgroundColor = Color.Black;
            else if (App.DisplayDatabase.ImageChoose == btnSecondFood.Source.ToString().Replace("File: ", ""))
                boxSecondFood.BackgroundColor = Color.Black;
            else if (App.DisplayDatabase.ImageChoose == btnThreeFood.Source.ToString().Replace("File: ", ""))
                boxThreeFood.BackgroundColor = Color.Black;
        }

        /// <summary>
        /// select touch
        /// </summary>
        private void SelectTouch()
        {
            boxTouchButton.BackgroundColor = Color.WhiteSmoke;
            boxTouchSlide.BackgroundColor = Color.WhiteSmoke;

            if (App.DisplayDatabase.TouchChoose == btnTouchButton.Source.ToString().Replace("File: ", ""))
                boxTouchButton.BackgroundColor = Color.Black;
            else if (App.DisplayDatabase.TouchChoose == btnTouchSlide.Source.ToString().Replace("File: ", ""))
                boxTouchSlide.BackgroundColor = Color.Black;
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
        /// Button Select Food
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectFood_Clicked(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            App.DisplayDatabase.ImageChoose = btn.Source.ToString().Replace("File: ","");
            App.Database.SaveDisplayAsync(App.DisplayDatabase);
            Initialize();

        }

        /// <summary>
        /// Button Select Touch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectTouch_Clicked(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            App.DisplayDatabase.TouchChoose = btn.Source.ToString().Replace("File: ", "");
            App.Database.SaveDisplayAsync(App.DisplayDatabase);
            Initialize();
        }
    }
}