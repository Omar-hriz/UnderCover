using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnderCover
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Pour les tests
            for (int i = 0; i < 2; i++)
            {
                PlayerDisplay player_d = new PlayerDisplay { Name = "John"+i.ToString(), Order = i.ToString() };
                App.PlayerList.Add(player_d);
                stackBox.Children.Add(player_d);
            }

            // Vrai version
            /*foreach (var player_d in App.PlayerList)
            {
                stackBox.Children.Add(player_d);
            }*/
        }

        void StartDelete(object sender, EventArgs e)
        {
            int i = 0;
            stackBox.Children.Clear();
            foreach (var player in App.PlayerList)
            {
                PlayerIlimination player_e = new PlayerIlimination
                {
                    Name = player.Name,
                };
                player_e.Button.CommandParameter = i.ToString();
                player_e.Button.Clicked += EliminatePlayer;
                stackBox.Children.Add(player_e);
                i++;
            }
        }

        public void EliminatePlayer(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            App.PlayerList.RemoveAt(int.Parse(button.CommandParameter.ToString()));

            stackBox.Children.Clear();
            foreach (var player_d in App.PlayerList)
            {
                stackBox.Children.Add(player_d);
            }
        }
    }
}