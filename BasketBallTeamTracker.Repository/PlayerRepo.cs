using BasketBallTeamTracker.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketBallTeamTracker.Repository
{
    public class PlayerRepo
    {
        //This is our fake database....
        //list of players that we put in here...
        //make some fields -> private variables that can only be accessed by 'this' class
        private readonly List<Player> _playerRepository = new List<Player>();
        
        //This will help me auto-increment the ID of a player
        private int _count = 0;


        //C.R.U.D

        //C. create
        public bool CreatePlayer(Player player)
        {
            if (player is null)
            {
                return false;
            }
            _count++;
            player.ID = _count;
            _playerRepository.Add(player);
            return true;
        }

        //R. read ->Get all players
        public List<Player> GetPlayers() 
        {
            return _playerRepository;
        }

        //R. read-> Get player by Id (helper method)
        public Player GetPlayerById(int id)
        {
            //we need to look inside of _playerRepository and find a player w/ a spcific Id
            foreach (Player player in _playerRepository)
            {
                if (player.ID==id)
                {
                    return player;
                }
            }

            //if noone is found then...
            return null;
        }

        //U. update...This updates an existing player
        public bool UpdatePlayer(int id, Player newPlayer)
        {
            //we want to utilize the helper method GetPlayerById
            Player player = GetPlayerById(id);

            //make sure the player exist
            if (player != null)
            {
                player.ID = id;
                player.PlaryerName = newPlayer.PlaryerName;
                player.PlayerPosition = newPlayer.PlayerPosition;
                return true;
            }
            else
            {
                return false;
            }

        }

        //D. delete..this deletes the player
        public bool DeletePlayer(int id)
        {
            Player player = GetPlayerById(id);

            //check if the player exists..
            if (player==null)
            {
                return false;
            }
            else
            {
                _playerRepository.Remove(player);
                return true;
            }
        }

    }
}
