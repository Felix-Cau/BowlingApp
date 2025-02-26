using BowlingApp.Interfaces;

namespace BowlingApp.Factories;

public class PlayersFactory
{
    public List<IPlayer> Participants(IPlayer playerOne, IPlayer playerTwo)
    {
        var players = new List<IPlayer>();
        players.Add(playerOne);
        players.Add(playerTwo);
        return players;
    }
}