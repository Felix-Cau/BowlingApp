using BowlingApp.Core;
using BowlingApp.Interfaces;

namespace BowlingApp.Factories;

public class GameFactory
{
    //Receives an input string to decide what type of game will be created.
    public static IGame CreateGame(string type)
    {
        return type.ToLower() switch
        {
            "bowling" => new BowlingGame(),
            _ => throw new ArgumentException("Invalid game type")
        };
    }
}