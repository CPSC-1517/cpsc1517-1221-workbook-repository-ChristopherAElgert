using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystem
{
    public class Team
    {
        //define a fully implemented property with a backing field for TeamName
        private string _teamName = string.Empty;
        public string TeamName
        {

            get
            {
                return _teamName;
            }
            set
            {
                //Validate the new value is not null, or empty
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("TeamName is required");
                }
                //validate the new value contains at least 5 or mroe characters
                if(value.Trim().Length < 5)
                {
                    throw new ArgumentException("TeamName must contain 5 or more characters");
                }

                _teamName = value;
            }
        }

        //define a read only property for coach
        //the coach property is know as aggregation/composition, when the field is an object
        public Coach Coach { get; private set; } = null!;

        //define a read only property for players, as a list
        public List<Player> Player { get; } = new List<Player>();

        //define a method to add a new player to the team
        public void AddPlayer(Player newPlayer)
        {
            //validate that the new player is not null
            if (newPlayer == null)
            {
                throw new ArgumentNullException("Player is required");
            }
            //validate that the team size (23) is not full, left as 3 for testing purposes
            if (Player.Count >= 3)
            {
                throw new ArgumentException("Team is full. Cannot add any more players");
            }
            //validate that the newPlayer PrimaryNo is not already in use
            //using a sequential search
            bool primaryNoFound = false;
            foreach (Player currentPlayer in Player)
            {
                if (currentPlayer.PrimaryNumber == newPlayer.PrimaryNumber)
                {
                    primaryNoFound = true;
                    break; // exit the foreach statement
                }
            }
            if (primaryNoFound)
            {
                throw new ArgumentException("OrimaryNumber is already in use by another player");
            }

            //add new player to the team
            Player.Add(newPlayer);
        }

        //define a computed property to return the total points of all players
        public int TotalPlayerPoints
        {
           get
           {
                //    int totalPoints = 0;
                //    foreach(Player currentPlayer in Player)
                //    {
                //        totalPoints += currentPlayer.Points;
                //    }
                //    return totalPoints;

                //same as above but using LinQ
                return Player.Sum(currentPlayer => currentPlayer.Points);
           }

        }

        public Team(string teamName, Coach coach)
        {
            if (coach == null)
            {
                throw new ArgumentNullException("A team requires a Coach");
            }

            Coach = coach;
            TeamName = teamName;

        }

        public override string ToString()
        {
            return $"{TeamName}, {Coach}";
        }
    }
}
