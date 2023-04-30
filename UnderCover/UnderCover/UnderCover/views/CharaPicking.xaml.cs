using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderCover.models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;
using Image = Xamarin.Forms.Image;

namespace UnderCover
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharaPicking : ContentPage
    {
        public Color golden = ColorConverters.FromHex("#FFB743");
        public Dictionary<String, int> numOfRoles;
        public List<string> names;
        public CharaPicking(List<string> names = null)
        {
            this.names = names;
            InitializeComponent();
            numOfRoles = new Dictionary<String, int>();
            numOfRoles.Add("Civilan",1);
            numOfRoles.Add("Under Cover", 1);
            numOfRoles.Add("Mr White", 1);
           
        }
        async void Play(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PickCard(numOfRoles));
        }
        
        void changeTitle()
        {
            int totalPlayers = 0;
            foreach (var role in numOfRoles)
            {
                for (int i = 0; i < role.Value; i++)
                {
                    totalPlayers++;
                }
            }
            title.Text = totalPlayers.ToString() + " Players";
        }
        void addUnderCover(object sender, EventArgs e)
       {
            numOfRoles["Under Cover"]++;
            underCoverLabel.Text = numOfRoles["Under Cover"].ToString();
            changeTitle();
       }       
        void subUnderCover(object sender, EventArgs e)
        {
            if(numOfRoles["Under Cover"]-1 > 0)
            {
                numOfRoles["Under Cover"]--;
                underCoverLabel.Text = numOfRoles["Under Cover"].ToString();
            }
            changeTitle();
        }       
        void addCivilan(object sender, EventArgs e)
       {
            numOfRoles["Civilan"]++;
            civilanLabel.Text = numOfRoles["Civilan"].ToString();
            changeTitle();
        }       
        void subCivilan(object sender, EventArgs e)
        {
            if(numOfRoles["Civilan"] -1 > 0)
            {
                numOfRoles["Civilan"]--;
                civilanLabel.Text = numOfRoles["Civilan"].ToString();
            }
            changeTitle();
        }       
        void addMrWhite(object sender, EventArgs e)
       {
            numOfRoles["Mr White"]++;
            mrWhiteLabel.Text = numOfRoles["Mr White"].ToString();
            changeTitle();
        }       
        void subMrWhite(object sender, EventArgs e)
        {
            if(numOfRoles["Mr White"] -1 > 0)
            {
                numOfRoles["Mr White"]--;
                mrWhiteLabel.Text = numOfRoles["Mr White"].ToString();
            }
            changeTitle(); 
        }

    }
}