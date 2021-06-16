using BasketBallTeamTracker.POCOs.ENUMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketBallTeamTracker.POCOs
{
    public class Player
    {
        public int ID { get; set; }
        public string PlaryerName { get; set; }

        public PlayerPositionType PlayerPosition { get; set; }

        public Player()
        {
                
        }

        public Player(string playerName, PlayerPositionType playerPosition)
        {
            PlaryerName = playerName;
            PlayerPosition = playerPosition;
        }
    }
}
