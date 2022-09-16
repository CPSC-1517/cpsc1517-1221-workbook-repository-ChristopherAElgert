using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystem
{
    //Define a class name Player that inherits from the base class Person
    public class Player : Person
    {
        //Define an auto-implemented property for PrimaryNo
        public int PrimaryNumber { get; set; }
        public Position Position { get; set; }
        public int Assists { get; set; }
        public int Goals { get; set; }

        public int Points
        {
            get
            {
                return Goals + Assists;
            }
        }

        //Defome a constructor that passes FullName to the Person base class
        public Player(string fullName, Position position, int primaryNumber) : base(fullName)
        {
            PrimaryNumber = primaryNumber;
            Position = position;
            Goals = 0;
            Assists = 0;
        }

        public Player(string fullName, Position position, int primaryNumber, int goals, int assists) : base(fullName)
        {
            PrimaryNumber = primaryNumber;
            Position = position;
            Goals = goals;
            Assists = assists;
        }
    }
}
