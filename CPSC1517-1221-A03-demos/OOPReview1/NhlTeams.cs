using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOPReview1
{
    public class NhlTeams
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name must contain text.");
                }
                _name = value.Trim();
            }
        }
        private string _city;
        public string City
        {
            get => _city;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name must contain text.");
                }
                _city = value.Trim();
            }
        }
        private int _gamesPlayed;
        public int GamesPlayed
        {
            get => _gamesPlayed;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Games played cannot be less than 0");
                }
                _gamesPlayed = value;
            }
        }
        private int _wins;
        public int Wins
        {
            get => _wins;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Wins cannot be less than 0");
                }
                _wins = value;
            }
        }
        private int _losses;
        public int Losses
        {
            get => _losses;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Losses cannot be less than 0");
                }
                _losses = value;
            }
        }
        private int _overtimeLosses;
        public int OvertimeLosses
        {
            get => _overtimeLosses;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Overtime losses cannot be less than 0");
                }
                _overtimeLosses = value;
            }
        }

        public int Points => (Wins * 2) + OvertimeLosses;

        public NhlConference Conference { get; set; }
        public NhlDivision Division { get; set; }

        //define an auto implemented property with a private set for players
        public List<NhlRoster> Players { get; private set; }

        private const int MaxPlayers = 23;

        //Method to add players to list
        public void AddPlayer(NhlRoster currentPlayer)
        {
            //throw an exception if the max number of players is reached
            if (Players.Count >= MaxPlayers)
            {
                throw new ArgumentException("The Roster is full. Remove a player first.");
            }
            Players.Add(currentPlayer);
        }
        //Method to remove players from list
        public void RemovePlayer(int playerNumber)
        {

        }
        
        public NhlTeams(
            NhlConference conference,
            NhlDivision division,
            string name,
            string city,
            List<NhlRoster> players)
        {  
            //create a new list of Roster if none is provided
            if(players == null)
            {
                players = new List<NhlRoster>();
            }
            else
            {
                Players = players;
            }

            Conference = conference;
            Division = division;
            Name = name;
            this.City = city;

            GamesPlayed = 0;
            Wins = 0;
            Losses = 0;
            OvertimeLosses = 0;
        }

        public NhlTeams(
            NhlConference conference,
            NhlDivision division,
            string name,
            string city)
        {
            Players = new List<NhlRoster>();

            Conference = conference;
            Division = division;
            Name = name;
            this.City = city;

            GamesPlayed = 0;
            Wins = 0;
            Losses = 0;
            OvertimeLosses = 0;
        }

        public override string ToString()
        {
            //return base.ToString();
            return $"{Conference}, {Division}, {Name}, {City}, {GamesPlayed}, {Wins}, {Losses}, {OvertimeLosses}";
        }
    }

}

