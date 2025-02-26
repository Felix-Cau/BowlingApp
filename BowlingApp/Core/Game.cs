using BowlingApp.Interfaces;

namespace BowlingApp.Core;

public static class Game
{
    public static void Run(List<IPlayer> players)
    {
        string playerOneName = players[0].Name;
        int playerOneScore = RandomScore();
        string playerTwoName = players[1].Name;
        int playerTwoScore = RandomScore();
        
        var winner = playerOneScore > playerTwoScore ? playerOneName : playerTwoName;
        
        Console.WriteLine($"The winner is {winner}! Press any key to continue.");
    }

    private static int RandomScore()
    {
        Random random = new Random();
        int randomScore = random.Next(0, 300);
        return randomScore;
    }
}