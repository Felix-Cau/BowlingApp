using BowlingApp.Core;
using BowlingApp.Interfaces;
using BowlingApp.Services;

namespace BowlingApp.Factories;

public class GameFactory(BowlingGame bowlingGame)
{
    //Receives an input string to decide what type of game will be created.
    public IGame CreateGame(string type)
    {
        return type.ToLower() switch
        {
            "bowling" => bowlingGame,
            _ => throw new ArgumentException("Invalid game type")
        };
    }
}