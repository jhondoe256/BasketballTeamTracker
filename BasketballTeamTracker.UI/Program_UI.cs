using BasketBallTeamTracker.POCOs;
using BasketBallTeamTracker.POCOs.ENUMs;
using BasketBallTeamTracker.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballTeamTracker.UI
{
    public class Program_UI
    {
        //referenc the reps: (2) PlayerRepo and TeamRepo
        private readonly PlayerRepo _playerRepo = new PlayerRepo();

        public void Run()
        {
            Seed();
            RunApplication();
        }

      

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to the BasketBall Team Tracker\n" +
                                  "1. Create Player\n" +
                                  "2. View All Players\n" +
                                  "3. View Single Player\n" +
                                  "4. Update an Existing Player\n" +
                                  "5. Delete an Existing Player\n" +
                                  "30. Close Application\n");

                //get the userInput ...
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreatePlayer();
                        break;
                    case "2":
                        ViewAllPlayers();
                        break;
                    case "3":
                        ViewSinglePlayer();
                        break;
                    case "4":
                        UpdateExistingPlayer();
                        break;
                    case "5":
                        DeleteExistingPlayer();
                        break;
                    case "30":
                        Console.Clear();
                        isRunning = false;
                        Console.WriteLine("Thank you , press any key to continue....");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Invalid user input!");
                        break;
                }

                Console.Clear();
            }
        }

        private void CreatePlayer()
        {
            Console.Clear();
            
            Console.WriteLine("Please input a player name:");
            string userInputPlayerName = Console.ReadLine();

            Console.WriteLine("Please input a player position:\n" +
                              "1.Center\n" +
                              "2.Power Forward\n" +
                              "3.Small Forward\n" +
                              "4.Point Guard\n" +
                              "5.Shooting Guard\n");

            int userInputPlayerPosition = int.Parse(Console.ReadLine());

            //now, I have to make a conversion from int to playerPositionType
            PlayerPositionType playerPosition = (PlayerPositionType)userInputPlayerPosition;

            //construct the player:
            Player player = new Player(userInputPlayerName, playerPosition);

            //add the player to the repository:
           bool isSuccessful= _playerRepo.CreatePlayer(player);

            if (isSuccessful)
            {
                Console.WriteLine($"{player.PlaryerName} was successfully created!");
            }
            else
            {
                Console.WriteLine($"{player.PlaryerName} was NOT successfully created!");
            }

        }

        private void ViewAllPlayers()
        {
            Console.Clear();

            //need to make a list that we can use to assing the list of players that are in the repository
            List<Player> players = _playerRepo.GetPlayers();

            //we need a way to get details for every player... using a helper method...
            Console.Clear();
            foreach (Player player in players)
            {
                DisplayPlayerInfo(player);
            }

            Console.ReadKey();
        }

        //helper method to display players
        private void DisplayPlayerInfo(Player player)
        {
            Console.WriteLine($"{player.ID}\n" +
                              $"{player.PlaryerName}\n" +
                              $"{player.PlayerPosition}\n");

            Console.WriteLine("*************************************************");
        }

        private void ViewSinglePlayer()
        {
            Console.Clear();

            Console.WriteLine("Please input an Existing Player Id");
            int userInputPlayerId = int.Parse(Console.ReadLine());
            Player player = _playerRepo.GetPlayerById(userInputPlayerId);
            if (player!=null)
            {
                DisplayPlayerInfo(player);
            }
            else
            {
                Console.WriteLine("The player Doesn't EXIST!");
            }

            Console.ReadKey();
        }

        private void UpdateExistingPlayer()
        {
            Console.Clear();
            Console.WriteLine("Please input an Existing Player Id");
            int userInputPlayerId = int.Parse(Console.ReadLine());


            Console.WriteLine("Please input a player name:");
            string userInputPlayerName = Console.ReadLine();

            Console.WriteLine("Please input a player position:\n" +
                              "1.Center\n" +
                              "2.Power Forward\n" +
                              "3.Small Forward\n" +
                              "4.Point Guard\n" +
                              "5.Shooting Guard\n");

            int userInputPlayerPosition = int.Parse(Console.ReadLine());

            //now, I have to make a conversion from int to playerPositionType
            PlayerPositionType playerPosition = (PlayerPositionType)userInputPlayerPosition;

            //construct the player:
            Player newPlayer = new Player(userInputPlayerName, playerPosition);


            //we will implement the updatePlayer(int,Player)
            bool isSuccessful = _playerRepo.UpdatePlayer(userInputPlayerId, newPlayer);

            if (isSuccessful)
            {
                Console.WriteLine($"{newPlayer.PlaryerName} was UPDATED!");
            }
            else
            {
                Console.WriteLine("Player  was NOT UPDATED!");
            }

        }

        private void DeleteExistingPlayer()
        {
            Console.Clear();
            Console.WriteLine("Please input an Existing Player Id");
            int userInputPlayerId = int.Parse(Console.ReadLine());

            bool isSuccessful = _playerRepo.DeletePlayer(userInputPlayerId);
            if (isSuccessful)
            {
                Console.WriteLine("Player was Deleted.");
            }
            else
            {
                Console.WriteLine("Player was NOT DELETED!");
            }
        }

        private void Seed()
        {
            //Create Players -> created every time the app runs HARD CODED VALUES!
            Player playerA = new Player("Justin",PlayerPositionType.Center);
            Player playerB = new Player("Bill",PlayerPositionType.Point_Guard);
            Player playerC = new Player("Sean",PlayerPositionType.Power_Forward);
            Player playerD = new Player("Candice",PlayerPositionType.Shooting_Guard);
            Player playerE = new Player("Dante",PlayerPositionType.Small_Forward);

            //adding players to the repo...
            _playerRepo.CreatePlayer(playerA);
            _playerRepo.CreatePlayer(playerB);
            _playerRepo.CreatePlayer(playerC);
            _playerRepo.CreatePlayer(playerD);
            _playerRepo.CreatePlayer(playerE);
        }
    }
}
