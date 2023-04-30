 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderCover.models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnderCover
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EndGame : ContentPage
    {
        public Dictionary<Player,int> playersScore { get; set; }
        public EndGame()
        {
            InitializeComponent();
            this.playersScore = new Dictionary<Player, int>();
            foreach (var player in (Application.Current as App).playerList)
            {
                this.playersScore.Add(player, 0);
            }
            updateScore();
            var text = "Civilans Won";
            foreach (var player in (Application.Current as App).playerList)
            {
                if(!player.isVoted && (player.role == "Under Cover" || player.role == "Mr White")){
                    text = "Under Cover Won";
                }
                var hStack = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                };
                hStack.Children.Add(new TextOverImage
                {
                    Source = "round_box.pngS",
                    Text = player.name,
                    WidthRequest = 120,
                    Margin = new Thickness(0, 0, 0, 0),
                });
                hStack.Children.Add(new TextOverImage
                {
                    Source = "small_box.png",
                    Text = playersScore[player].ToString(),
                    WidthRequest = 40,
                    Margin = new Thickness(0, 0, 0, 0),
                });
                stackBox.Children.Add(hStack);
            }
            whoWon.Text = text;
            civilanWord.Text = (Application.Current as App).words[0]["Civilian"];
            underCoverWord.Text = (Application.Current as App).words[0]["Unde Cover"];
        }
        void updateScore()
        {
            foreach (var player in (Application.Current as App).playerList)
            {
                if (player.isVoted)
                {
                    switch (player.role)
                    {
                        case "Unde Cover":
                            playersScore[player] += 5;
                            break;
                        case "Mr Whie":
                            playersScore[player] += 10;
                            break;
                        case "Civilian":
                            playersScore[player] += 5;
                            break;
                    }
                }
            }
        }
    } 
}
    