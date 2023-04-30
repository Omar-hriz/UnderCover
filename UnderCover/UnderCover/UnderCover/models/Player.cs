using System;
using System.Collections.Generic;
using System.Text;

namespace UnderCover.models
{
    public class Player
    {
        public Boolean isVoted { get; set; }
        public String name { get; set; }
        public String role { get; set; }
        public Player(Boolean isVoted, String name ,String role)
        {
            this.isVoted = isVoted;
            this.name = name;
            this.role = role;
        }
    }
}
