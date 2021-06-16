using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketBallTeamTracker.POCOs
{
    public class Team
    {
        public int ID { get; set; }
        public string TeamName { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();

        public Team()
        {

        }

        public Team(string teamName,List<Player> players)
        {
            TeamName = teamName;
            Players = players;
        }
    }
}
