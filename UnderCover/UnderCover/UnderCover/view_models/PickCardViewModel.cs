using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using UnderCover.models;
using Xamarin.Forms;

namespace UnderCover.view_models
{
    public class PickCardViewModel:INotifyPropertyChanged
    { 
        public event PropertyChangedEventHandler PropertyChanged;
        public List<Player> players { get; set; }
        public Dictionary<String, int> numOfRoles
        {
            get => numOfRoles;
            set 
            {
                numOfRoles = value;
                var args = new PropertyChangedEventArgs(nameof(numOfRoles));
                PropertyChanged?.Invoke(this, args);
            }
        } 
        public String texte
        {
            get => texte;
            set
            {
                texte = value;
                var args = new PropertyChangedEventArgs(nameof(numOfRoles));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public ObservableCollection<String> names { get; set; }
 
        public PickCardViewModel() {

        }
        public void setUpPlayers()
        {
            int totalPlayers = 0;
            foreach (var role in numOfRoles)
            {
                for (int i = 0; i < role.Value; i++)
                {
                    totalPlayers++;
                    if (names != null)
                    {
                        this.players.Add(new Player(false, "", role.Key));
                    }
                    else
                    {
                        this.players.Add(new Player(false, names[totalPlayers - 1], role.Key));
                    }

                }
            }
        }

       
    }
}
