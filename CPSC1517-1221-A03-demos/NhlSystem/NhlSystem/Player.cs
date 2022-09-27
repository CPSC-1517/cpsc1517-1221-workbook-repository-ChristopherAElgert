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
        //public int PrimaryNumber { get; set; }
        public Position Position { get; set; }
        public int Assists { get; set; }
        public int Goals { get; set; }

        //Define a fully implemented property with a backing field for Primary Number

        private int _primaryNumber;
        public int PrimaryNumber
        {
            get
            {
                return _primaryNumber;
            }
            set
            {
                if(value < 0 || value > 98)
                {
                    throw new ArgumentOutOfRangeException("PrimaryNo must be between 0 and 98");
                }

                _primaryNumber = value;
            }
        }

        public int Points
        {
            get
            {
                return Goals + Assists;
            }
        }

        //Define a constructor that passes FullName to the Person base class
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

        public override string ToString()
        {
            return $"{FullName}, {PrimaryNumber}, {Position}, {Goals}, {Assists}, {Points}";
        }

        //
        public static Player ParseCsv(string line)
        {
            //define a constant for the delimiter character
            const char Delimiter = ',';

            //split the line into an array where each value is separated by a Delimiter
            string[] tokens = line.Split(Delimiter);

            //verify that there are 6 elements in the array
            if(tokens.Length != 6)
            {
                throw new FormatException($"CSV line must contain exavtly 6 values. {line}");
            }
            //column order is fillName, primaryNumber, position, goals, assists, points
            string fullName = tokens[0];
            int primaryNumber = int.Parse(tokens[1]);
            Position position = (Position) Enum.Parse(typeof(Position), tokens[2]);
            int goals = int.Parse(tokens[3]);
            int assists = int.Parse(tokens[4]);
            int points = int.Parse(tokens[5]);

            // colon lets you manually assign values 
            return new Player(
                fullName : fullName, 
                position : position, 
                primaryNumber: primaryNumber, 
                goals: goals, 
                assists: assists);

        }

        public static bool TryParse(string line, out Player player)
        {
            bool success = false;

            try
            {
                player = ParseCsv(line);
                success = true;
            }
            catch(FormatException ex)
            {
                throw new FormatException(ex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception($"Player TryParse exception {ex.Message}");
            }
            return success;
        }
    }
}
