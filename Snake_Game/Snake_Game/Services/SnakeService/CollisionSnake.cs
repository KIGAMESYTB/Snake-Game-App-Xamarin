using Plugin.SimpleAudioPlayer;
using Snake_Game.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace Snake_Game.Services
{
    public class CollisionSnake
    {
        #region Variable

        public bool ValueGameOver { get; set; } = false;
        private Random Random { get; set; }
        private CreateSnake CreateSnake { get; set; }
        #endregion


        /// <summary>
        /// Constructor
        /// </summary>
        public CollisionSnake()
        {
            Random = new Random();
            CreateSnake = new CreateSnake();
        }

        /// <summary>
        /// Collision snake with wall
        /// </summary>
        public void CollisionWall()
        {
            var head = AbsoluteLayout.GetLayoutBounds(App.ListSnake[0]);
            if (head.X <= 0 || head.X >= 1 || head.Y <= 0 || head.Y >= 1)
            {
                GameOver();
            }
        }


        /// <summary>
        /// Collision food with snake
        /// </summary>
        public void CollisionFood()
        {
            if(App.ListSnake[0].Bounds.IntersectsWith(App.Snake.PositionFood.Bounds))
            {
                if (App.MusicDatabase.ValueSfx)
                {
                    var tappedSounds = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                    tappedSounds.Load("SnakeEat.wav");
                    tappedSounds.Play();
                }
                NewPositionCollisionFood();
                App.Snake.Absolute.Children.Add(CreateSnake.BodySnake(new Rectangle(-1,-1,0.05,0.05)));
                CollisionFoodScore();
            }
        }

        /// <summary>
        /// Collision body snake with head snake
        /// </summary>
        public void CollisionBody()
        {
            for(int i=4; i<App.ListSnake.Count; i++)
            {
                if (App.ListSnake[0].Bounds.IntersectsWith(App.ListSnake[i].Bounds))
                {
                    GameOver();
                }
            }
        }

        /// <summary>
        /// Collision food score
        /// </summary>
        private async void CollisionFoodScore()
        {
            App.Snake.NbEatFood++;
            App.Snake.LblScore.Text = App.Snake.NbEatFood.ToString();
            if (App.Snake.NbEatFood > App.DisplayDatabase.HighScore)
            {
                App.Snake.LblBetterScore.Text = App.Snake.NbEatFood.ToString();
                App.DisplayDatabase.HighScore = App.Snake.NbEatFood;
                await App.Database.SaveDisplayAsync(App.DisplayDatabase);
            }
        }

        /// <summary>
        /// new position food
        /// </summary>
        private void NewPositionCollisionFood()
        {
            double x = Random.Next(100);
            double y = Random.Next(100);
            AbsoluteLayout.SetLayoutBounds(App.Snake.PositionFood, new Rectangle(x / 100, y / 100, 0.08, 0.08));
            AbsoluteLayout.SetLayoutFlags(App.Snake.PositionFood, AbsoluteLayoutFlags.All);
        }

        /// <summary>
        /// game over collision
        /// </summary>
        private void GameOver()
        {
            if (!ValueGameOver)
            {
                App.Snake.Stop();
                App.SoundsMusic.Stop();
                if (App.MusicDatabase.ValueSfx)
                {
                    var tappedSounds = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                    tappedSounds.Load("Game_over.wav");
                    tappedSounds.Play();
                }
                App.Current.MainPage.Navigation.ShowPopup(new GameOverPage());
                ValueGameOver = true;
            }
        }


    }
}
