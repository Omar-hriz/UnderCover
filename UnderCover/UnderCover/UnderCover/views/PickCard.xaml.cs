using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderCover.models;
using UnderCover.view_models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnderCover
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickCard : ContentPage
    {
        Dictionary<String, int> numOfRoles {  get; set; }
        int numOfPalyerWithoutWord { get; set; }
        public PickCard() {
            InitializeComponent();
        }
        public PickCard(Dictionary<String,int>numOfRoles = null)
        {
            InitializeComponent();   
            this.numOfRoles = numOfRoles;
            
            setUpPlayers();
            this.numOfPalyerWithoutWord = (Application.Current as App).playerList.Count;
            drawCards(this.numOfPalyerWithoutWord);
        }
        void AssignRole(object sender, EventArgs e)
        {
            
            int i = 0;
            while (i < (Application.Current as App).playerList.Count)
            {
                if ((Application.Current as App).playerList[i].name == "")
                {
                    chooseName.IsVisible = true;
                    break;
                }
                i++;
            }
            this.numOfPalyerWithoutWord--;
            stackBox.Children.Clear();
            drawCards(this.numOfPalyerWithoutWord);
        }

        public void drawCards(int numOfCards)
        {
            for(int i = 0; i< numOfCards;i++)
            {
                var card = new ImageButton
                {
                    Source = "randome_card.png",
                    Aspect = Aspect.AspectFit,
                    HorizontalOptions = LayoutOptions.Center,
                    HeightRequest = 76,
                    BackgroundColor = Color.Transparent,
                    Padding = new Thickness(4, 4, 4, 4),
                };
                card.Clicked += AssignRole;
                stackBox.Children.Add(card);
            }
        }

        public void setUpPlayers()
        {
            foreach (var role in this.numOfRoles)
            {
                for (int i = 0; i < role.Value; i++)
                {
                    (Application.Current as App).playerList.Add(new Player(false, "", role.Key));
                }
            }
        } 
    }
}