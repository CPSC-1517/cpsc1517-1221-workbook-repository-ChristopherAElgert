using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OOPReview1.HockeyTeams;

namespace OOPReview1
{
    public class HockeyTeams
    {
        public enum HockeyConference { Eastern, Western};
        public enum HockeyDivision { Metropolitan, Atlantic, Central, Pacific};

        //define data fields for storing data
        private HockeyConference _conference;

        private HockeyDivision _division;

        //define fully-implemented properties for data fields
        public HockeyConference Conference
        {
            get { return _conference; }
        }
        public HockeyDivision Division
        {
            get { return _division; }
            set { _division = value; }
        }


    }
}
