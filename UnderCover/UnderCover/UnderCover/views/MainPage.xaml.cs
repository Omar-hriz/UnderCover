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
        public bool entryPresent = false;

        Entry newEntry = new Entry
        {
            Placeholder = "Player to be eliminated",
            PlaceholderColor = Color.White,
            Margin = new Thickness(32,8,32,8),
        };
        public MainPage()
        {
            InitializeComponent();
            // Pour les tests
            /*for (int i = 0; i < 2; i++)
            {
                PlayerDisplay player_d = new PlayerDisplay { Name = "John"+i.ToString(), Order = i.ToString() };
                App.PlayerList.Add(player_d);
                stackBox.Children.Add(player_d);
            }*/

            // Vrai version
            int i = 0;
            foreach (var player in (Application.Current as App).playerList)
            {
                PlayerDisplay player_d = new PlayerDisplay { Name = player.name, Order = i.ToString() };
                App.PlayerList.Add(player_d);
                stackBox.Children.Add(player_d);
                i++;
            }
        }

        void StartDelete(object sender, EventArgs e)
        {
            /*int i = 0;
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
            }*/
            if (entryPresent == false)
            {
                // Creating a binding
                newEntry.SetBinding(Entry.TextProperty, new Binding("ViewModelProperty"));

                Button newButton = new Button 
                { 
                    Text = "Eliminate Player",
                    Margin = new Thickness(32, 8, 32, 8),
                };
                newButton.Clicked += EliminatePlayer;

                newButton.SetBinding(Button.CommandProperty, new Binding("ViewModelProperty2"));

                // Add the new entry control to the StackLayout
                layout.Children.Add(newEntry);
                layout.Children.Add(newButton);

                entryPresent = true;
            }
        }

        public void EliminatePlayer(object sender, EventArgs e)
        {
            /*ImageButton button = (ImageButton)sender;
            Console.WriteLine(Int32.Parse(button.CommandParameter.ToString()));
            Console.WriteLine(App.PlayerList[Int32.Parse(button.CommandParameter.ToString())]);
            Console.WriteLine(App.PlayerList.Count());
            App.PlayerList.RemoveAt(Int32.Parse(button.CommandParameter.ToString()));*/

            
            string valueEntry = newEntry.Text;


            foreach (var player_d in  App.PlayerList.ToList())
            {
                if (player_d.Name == valueEntry)
                {
                    App.PlayerList.Remove(player_d);
                    foreach (var player in (Application.Current as App).playerList)
                    {
                        if(player.name == valueEntry)
                        {
                            player.isVoted = true;
                        }
                    }
                        
                }
            }

            stackBox.Children.Clear();
            foreach (var player_d in App.PlayerList)
            {
                stackBox.Children.Add(player_d);
            }

            layout.Children.RemoveAt(layout.Children.Count - 1);
            layout.Children.RemoveAt(layout.Children.Count - 1);
            entryPresent = false;
        }
    }
}