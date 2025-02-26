using BowlingApp.Interfaces;
using BowlingApp.Repository.Entities;

namespace BowlingApp.Factories;

public static class PlayersFactory
{
    //This made it worse.
    public static List<IPlayer> Participants(IPlayer playerOne, IPlayer playerTwo)
    {
        List<IPlayer> players = new() {playerOne, playerTwo};
        return players;
    }
}