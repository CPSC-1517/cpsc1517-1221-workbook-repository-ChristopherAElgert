using NhlSystem;
using System.IO;
using System.Text.Json;
/* Test Plan for Person
 * 
 * Test Case                    Test Data                   Expected Result
 * ---------                    ---------                   ---------------
 * Valid Fullname               FullName: Connor McDavid    FullName = Connor McDavid
 *  
 * Null Fullname                Fullname: null              ArgumentNullException
 * 
 * Empty Fullname               FullName: ""                ArgumentNullException
 * 
 * Whitespace Fullname          FullName: "  "              ArgumentNullException
 * 
 * Full Less than 3 characters  FullName: AB                ArgumentException
 * 
 */

//Test Case 1: Valid FullName
var validPerson = new Person("Connor McDavid");

Console.WriteLine(validPerson.FullName); //the value should be Connor McDavid

//Test Case 2: Null FullName
try
{
	var nullPerson = new Person(null);
	Console.WriteLine(nullPerson.FullName);
}
catch (ArgumentNullException ex)
{
	Console.WriteLine(ex.ParamName); //output should be "Full Name cannot be left empty"
}

//Test Case 3: Empty FullName
try
{
    var emptyPerson = new Person("");
    Console.WriteLine(emptyPerson.FullName);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.ParamName); //output should be "Full Name cannot be left empty"
}

//Test Case 4: Whitespace Name
try
{
    var whiteSpacePerson = new Person("     ");
    Console.WriteLine(whiteSpacePerson.FullName);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.ParamName); //output should be "Full Name cannot be left empty"
}

//Test Case 5: Short name
try
{
    var shortPerson = new Person("AB");
    Console.WriteLine(shortPerson.FullName);
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}

Console.WriteLine("______________________________________________________________________\n");

//Test creating a new Team
//Create a new Coach for the team
DateTime startDate = DateTime.Parse("2021-09-02");
Coach oilersCoach = new Coach("Jay Woodcroft", startDate);

//create a new team
Team oilersTeam = new Team("Edmonton Oilers", oilersCoach);

//create 3 players for the team
Player player1 = new Player("Connor McDavid", Position.C, 97);
Player player2 = new Player("Evander Kane", Position.LW, 91);
Player player3 = new Player("Leon Draisaitl", Position.C, 29);

//add them to the team
oilersTeam.AddPlayer(player1);
oilersTeam.AddPlayer(player2);
oilersTeam.AddPlayer(player3);



//assign goals and assists to each player
player1.Goals = 44;
player1.Assists = 79;

player2.Goals = 22;
player2.Assists = 17;

player3.Goals = 55;
player3.Assists = 55;

//Check that the team has 3 players
Console.WriteLine($"Players in team is {oilersTeam.Player.Count}");

foreach(Player currentPlayer in oilersTeam.Player)
{
    Console.WriteLine(currentPlayer);
}

//check the TotalPlayerPoints. Should be 272
Console.WriteLine($"Total player points is {oilersTeam.TotalPlayerPoints}");

static void CreatePlayersCsvFile()
{
    //Create a new Coach for the team
    DateTime startDate = DateTime.Parse("2021-09-02");
    Coach oilersCoach = new Coach("Jay Woodcroft", startDate);

    //create a new team
    Team oilersTeam = new Team("Edmonton Oilers", oilersCoach);

    //create 3 players for the team
    Player player1 = new Player("Connor McDavid", Position.C, 97);
    Player player2 = new Player("Evander Kane", Position.LW, 91);
    Player player3 = new Player("Leon Draisaitl", Position.C, 29);

    //add them to the team
    oilersTeam.AddPlayer(player1);
    oilersTeam.AddPlayer(player2);
    oilersTeam.AddPlayer(player3);

    const string PlayersCsvFile = "../../../Players.csv";
    File.WriteAllLines(PlayersCsvFile, oilersTeam.Player.Select(currentPlayer => currentPlayer.ToString()).ToList());
}

//CreatePlayersCsvFile();

static void CreateTeamJsonFile()
{
    //Create a new Coach for the team
    DateTime startDate = DateTime.Parse("2021-09-02");
    Coach oilersCoach = new Coach("Jay Woodcroft", startDate);

    //create a new team
    Team oilersTeam = new Team("Edmonton Oilers", oilersCoach);

    //create 3 players for the team
    Player player1 = new Player("Connor McDavid", Position.C, 97);
    Player player2 = new Player("Evander Kane", Position.LW, 91);
    Player player3 = new Player("Leon Draisaitl", Position.C, 29);

    //add them to the team
    oilersTeam.AddPlayer(player1);
    oilersTeam.AddPlayer(player2);
    oilersTeam.AddPlayer(player3);

    const string TeamJsonFile = "../../../Team.Json";
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true,
        IncludeFields = true
    };
    string jsonString = JsonSerializer.Serialize<Team>(oilersTeam, options);
    File.WriteAllText(TeamJsonFile, jsonString);
}

CreateTeamJsonFile();