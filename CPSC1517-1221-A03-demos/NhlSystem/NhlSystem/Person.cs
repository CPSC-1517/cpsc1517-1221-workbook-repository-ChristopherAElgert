using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystem
{
    public class Person
    {
        // Define a fully implemented property for FullName with a private set

        private string _fullName = string.Empty; //Define a backing field for the FullName property 

        public string FullName
        {
            //get { return _fullName; }
            get => _fullName; // short-form, use only if get is a single line statement

            private set 
            {
                //Validate new value is not null or whitespace
                
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Full Name cannot be left empty");
                }
                //Validate new value contains a minimum of 3 or more characters
                if (value.Trim().Length < 3)//trims whitespace and then checks if value is less than 3 characters
                {
                    throw new ArgumentException("Full Name must contain 3 or more characters");
                }

                _fullName = value.Trim(); 
            }
        }

        //create a greedy constructor with a parameter for the fullname 
        public Person(string fullName)
        {
            FullName = fullName;
        }

        
    }
}
