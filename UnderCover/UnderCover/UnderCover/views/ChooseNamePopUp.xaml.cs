using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;
using Application = Xamarin.Forms.Application;

namespace UnderCover.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]    
    public partial class ChooseNamePopUp : ContentView
    {
        Entry entry { get; set; }

        public ChooseNamePopUp()
        {
            InitializeComponent();
            drawChooseNamePage();
        }
        void showWordToPlayer(object sender, EventArgs e)
        {
            int i = 0;
            var text = "";
            while(i< (Application.Current as App).playerList.Count)
            {
                if((Application.Current as App).playerList[i].name == "")
                {
                    (Application.Current as App).playerList[i].name = this.entry.Text;
                    if((Application.Current as App).playerList[i].role == "Mr White")
                    {
                        text = "You are Mr White";
                    }
                    else
                    {
                        (Application.Current as App).wordsOfPlayers.Add((Application.Current as App).playerList[i], (Application.Current as App).words[0][(Application.Current as App).playerList[i].role]);
                        text = (Application.Current as App).playerList[i].name + " you'r word is " + (Application.Current as App).words[0][(Application.Current as App).playerList[i].role];
                    }                   
                    break;
                }
                i++;
            }
            stackContent.Children.Clear();
            stackContent.Children.Add(new TextOverImage
            {
                WidthRequest = 180,
                Text = text,
                FontSize = "20",
                Source = "small_box.png",
                HorizontalOptions = LayoutOptions.Center,
            });
            var button = new Button
            {
                Margin = new Thickness(20, 0, 20, 0),
                Text = "OK"
            };
            button.Clicked += makeInvisible;
            stackContent.Children.Add(button);
        }
        async void makeInvisible(object sender, EventArgs e)
        {
            this.IsVisible = false;
            int i = 0;
            while (i < (Application.Current as App).playerList.Count)
            {
                if ((Application.Current as App).playerList[i].name == "")
                {
                    break;
                }
                i++;
            }
            if(i == (Application.Current as App).playerList.Count )
            {
                await Navigation.PushAsync(new MainPage());
            }
            stackContent.Children.Clear();
            drawChooseNamePage();
        }
        void drawChooseNamePage()
        {
            this.entry = new Entry
            {
                Margin = new Thickness(20, 20, 20, 10),
                Placeholder = "Enter Name",
            };
            stackContent.Children.Add(new TextOverImage
            {
                WidthRequest = 360,
                Text = "What is your Name ?",
                FontSize = "24",
                Source = "large_box.png",
                HorizontalOptions = LayoutOptions.Center,
            });
            stackContent.Children.Add(this.entry);
            var button = new Button
            {
                Margin = new Thickness(20, 0, 20, 0),
                Text = "OK"
            };
            button.Clicked += showWordToPlayer;
            stackContent.Children.Add(button);
        }
    }
}