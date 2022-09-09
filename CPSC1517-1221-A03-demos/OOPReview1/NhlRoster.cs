using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOPReview1
{
    public class NhlRoster
    {
        private const int MinNo = 0;
        private const int MaxNo = 98;

        //define a fully implemented property for player name
        private string _playerName;
        public string PlayerName
        {
            get => _playerName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name must contain text.");
                }
                _playerName = value.Trim();
            }
        }

        //define a fully implemented property for player number
        private int _playerNumber;
        public int PlayerNumber
        {
            get => _playerNumber;
            set
            {
                if (value > MaxNo || value < MinNo)
                {
                    throw new ArgumentOutOfRangeException($"Player Number must be between {MinNo} and {MaxNo}");
                }
                _playerNumber = value;
            }
        }

        //define an auto implemented property for position
        public PlayerPosition Position { get; set; }

        //define a greedy constructor with parameters for no, name, and position
        public NhlRoster(int playerNumber, string playerName, PlayerPosition playerPosition)
        {
            PlayerNumber = playerNumber;
            PlayerName = playerName;
            Position = playerPosition;
        }
        //override the ToString to return the Number, Name, and Position
        public override string ToString()
        {
            //return base.ToString();
            return $"{PlayerNumber}, {PlayerName}, {Position}";
        }
    }
}
