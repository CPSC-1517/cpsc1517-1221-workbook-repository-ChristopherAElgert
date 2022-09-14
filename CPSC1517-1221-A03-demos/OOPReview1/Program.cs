// See https://aka.ms/new-console-template for more information
using OOPReview1;

//test creating a new roster with valid values
var validPlayer1 = new NhlRoster(97, "Connor McDavid", PlayerPosition.C);
//Print the validPlayer1 object to the screen
//the no should be 97, name should be Connor McDavid, and position should be C
Console.WriteLine(validPlayer1); //it works

try
{
    //test creating a new roster with invalid number
    var invalidPlayer1 = new NhlRoster(100, "Leon Draisatil", PlayerPosition.C);
    //an ArgumentOutOfRangeException should be thrown with a message identifying what the error is
}
catch (ArgumentOutOfRangeException ex)
{
    //the parameter name of the exception should be "Player number must be between 1 and 98"
    Console.WriteLine(ex.ParamName);
    //do not use ex.Message because it creates a longer message with useless information
}

try
{
    //test creating a new roster with invalid white space name
    var invalidPlayer2 = new NhlRoster(66, " ", PlayerPosition.LW);
}
catch (ArgumentNullException ex)
{
    //the parameter name of the exception should be "Name must contain text."
    Console.WriteLine(ex.ParamName);
}

try
{
    //test creating a new roster with invalid null name
    var invalidPlayer3 = new NhlRoster(66, null, PlayerPosition.LW);
}
catch (ArgumentNullException ex)
{ 
    //the parameter name of the exception should be "Name must contain text."
    Console.WriteLine(ex.ParamName);
}









var Senators = new NhlTeams( NhlConference.Eastern, NhlDivision.Atlantic, "Senators", "Ottowa");
Senators.GamesPlayed = 82;
Senators.Wins = 32;
Senators.Losses = 42;
Senators.OvertimeLosses = 7;

Console.WriteLine(Senators);
Console.WriteLine($"Points = {Senators.Points}");



