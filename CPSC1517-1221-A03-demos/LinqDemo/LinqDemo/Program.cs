using LinqDemo; // for VideoGame 
using static System.Console; //allows you use access all static methods in the Console class without the Console prefix 
                            //lets you just type WriteLine instead of Console.WriteLine

//Create a new list of VideoGame with sample data

var games = new List<VideoGame>
{
    //object initialize syntax
    new VideoGame("Diablo III", "Nintendo", 34.99, 1),
    new VideoGame("NBA 2K20", "Playstation", 79.99, 2),
    new VideoGame("NBA 2K20", "Nintendo", 79.99, 3),
    new VideoGame("NBA 2K20", "Xbox", 79.99, 4),
    new VideoGame("Forza Horizon 4", "Xbox", 49.99, 5),
    new VideoGame("Pokemon Scarlet", "Nintendo", 69.99, 6),
    new VideoGame("Final Fantasy XIV", "PC", 39.99, 7),
    new VideoGame("Outer Worlds", "PC", 59.99, 8),
    new VideoGame("Kingdom Hearts 3", "Playstation", 19.99, 9),
    new VideoGame("Halo Infinite", "Xbox", 79.99, 10),
    new VideoGame("Kingdom Hearts 3", "Xbox", 19.99, 11),
    new VideoGame("Dragon Quest XI", "Nintendo", 29.99, 12)
};

//print all game to screen using for loop
for (int index = 0; index < games.Count; index++)
{
    var currentGame = games[index];

    WriteLine(currentGame);
}
WriteLine("------------------------------------------------------------------------------------------------------------------------");

//print all games to the screen using foreach
foreach (VideoGame item in games)
{
    WriteLine(item);
}
WriteLine("------------------------------------------------------------------------------------------------------------------------");

//print all games to the screen using the LinQ ForEach extension function
games.ForEach(currentGame => WriteLine(currentGame));

WriteLine("------------------------------------------------------------------------------------------------------------------------");

//to do multiple you can use curly braces
games.ForEach(currentGame =>
{
    WriteLine(currentGame);
    WriteLine(currentGame);
}
);
WriteLine("------------------------------------------------------------------------------------------------------------------------");

//print all Ninetendo games using the LinQ Where extension function to filter the elements
games.Where(currentGame => currentGame.platform == "Nintendo").ToList().ForEach(currentGame => WriteLine(currentGame));

WriteLine("------------------------------------------------------------------------------------------------------------------------");

//print all Nintendo cames using LinQ Query syntax
var nintendoGameQuery = from currentGame in games where currentGame.platform == "Nintendo" select currentGame;

foreach (var currentGame in nintendoGameQuery)
{
    WriteLine(currentGame);
}

WriteLine("------------------------------------------------------------------------------------------------------------------------");

//Print Just the Title of each videogame
games.Select(currentGame => currentGame.title).ToList().ForEach(title => WriteLine(title));

Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

//print only distinct platforms
games.Select(currentGame => currentGame.platform).Distinct().ToList().ForEach(platform => WriteLine(platform));

Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

//sum up all the nintendo games
double sumOfNintendoGames = games.Where(item => item.platform == "Nintendo").Sum(item => item.price);

WriteLine(sumOfNintendoGames);

Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

//any games less than $20?
bool anyGamesLessThan20 = games.Any(item => item.price < 20);

//all games less than $50
bool anyGamesLessThan50 = games.All(item => item.price < 50);

//no PC games for sale?
bool noPCGamesOnSale = !games.Any(item => item.platform == "PC");