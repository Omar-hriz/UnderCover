using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnderCover
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TextOverImage : ContentView
    {
        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create("Source", typeof(string), typeof(TextOverImage), string.Empty);

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(TextOverImage), string.Empty);

        public static readonly BindableProperty FontProperty =
            BindableProperty.Create("FontSize", typeof(string), typeof(TextOverImage), string.Empty);

        public string Source
        {
            get => (string) GetValue(TextOverImage.SourceProperty);
            set => SetValue(TextOverImage.SourceProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextOverImage.TextProperty);
            set => SetValue(TextOverImage.TextProperty, value);
        }
        public string FontSize
        {
            get => (string)GetValue(TextOverImage.FontProperty);
            set => SetValue(TextOverImage.FontProperty, value);
        }

        public TextOverImage() 
        {
            InitializeComponent();

        }
    }
}
