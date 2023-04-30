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
    public partial class PlayerDisplay : ContentView
    {
        public static readonly BindableProperty NameProperty =
            BindableProperty.Create("Name", typeof(string), typeof(PlayerDisplay), string.Empty);
        public static readonly BindableProperty OrderProperty =
            BindableProperty.Create("Order", typeof(string), typeof(PlayerDisplay), string.Empty);
        public string Name
        {
            get => (string)GetValue(PlayerDisplay.NameProperty);
            set => SetValue(PlayerDisplay.NameProperty, value);
        }
        public string Order
        {
            get => (string)GetValue(PlayerDisplay.OrderProperty);
            set => SetValue(PlayerDisplay.OrderProperty, value);
        }
        public PlayerDisplay()
        {
            InitializeComponent();
        }
    }
}