using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnderCover
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlayerIlimination : ContentView
	{
        public static readonly BindableProperty NameProperty =
            BindableProperty.Create("Name", typeof(string), typeof(PlayerIlimination), string.Empty);
        public static readonly BindableProperty ButtonProperty =
            BindableProperty.Create("Button", typeof(ImageButton), typeof(PlayerIlimination), new ImageButton
            {
                Source = "minus_button.png",
                Aspect = Aspect.AspectFit,
                WidthRequest = 24,
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.End,
                Margin =new Thickness(15,0,0,-15),
            });
        public string Name
        {
            get => (string)GetValue(PlayerIlimination.NameProperty);
            set => SetValue(PlayerIlimination.NameProperty, value);
        }
        public ImageButton Button
        {
            get => (ImageButton)GetValue(PlayerIlimination.ButtonProperty);
            set => SetValue(PlayerIlimination.ButtonProperty, value);
        }
        public PlayerIlimination ()
		{
			InitializeComponent ();
            Grid.SetRow(Button, 0);
            Grid.SetColumn(Button, 1);
            myGrid.Children.Add(Button);
		}
	}
}