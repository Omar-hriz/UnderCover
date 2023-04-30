using System;
using System.Collections.Generic;
using UnderCover.models;
using UnderCover.views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UnderCover
{
    public partial class App : Application
    {
        public List<Player> playerList { get; set; }
        public Dictionary<Player, String> wordsOfPlayers { get; set; }
        public List<Dictionary<String, String>> words { get; set; }
        public static List<PlayerDisplay> PlayerList { get; set; } = new List<PlayerDisplay>();
        public static List<PlayerIlimination> PlayerEliminationList { get; set; } = new List<PlayerIlimination>();
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
            this.wordsOfPlayers = new Dictionary<Player, String>();
            this.playerList = new List<Player>();
            this.words = new List<Dictionary<String, String>>();
            var round = new Dictionary<String, String>();
            round.Add("Civilan", "hi");
            round.Add("Under Cover", "hello");
            this.words.Add(round);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
