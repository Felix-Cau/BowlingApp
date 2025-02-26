using BowlingApp.Interfaces;

namespace BowlingApp.Core;

public class BowlingGame : IGame
{
    public void Run(List<IPlayer> players)
    {
        Console.Clear();
        string playerOneName = players[0].Name;
        int playerOneScore = RandomScore();
        string playerTwoName = players[1].Name;
        int playerTwoScore = RandomScore();

        var (winner, winnerScore, loser, loserScore) = playerOneScore > playerTwoScore 
            ? (playerOneName, playerOneScore, playerTwoName, playerTwoScore) 
            : (playerTwoName, playerTwoScore, playerOneName, playerOneScore);
        
        Console.WriteLine($"The winner is {winner} with {winnerScore}!");
        Console.WriteLine($"{loser} lost with {loserScore}..");
        Console.WriteLine("Press any key to continue...");
    }

    private static int RandomScore()
    {
        Random random = new Random();
        int randomScore = random.Next(0, 300);
        return randomScore;
    }
}