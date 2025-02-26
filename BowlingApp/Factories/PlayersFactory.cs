using BowlingApp.Interfaces;
using BowlingApp.Repository.Entities;

namespace BowlingApp.Factories;

//Ska allt som berör skapande av spelare hamna här för en korrekt PlayersFactory?
//Jag använder constructorer för guest/user där det behövs i övriga koden. Ska all konstruktion av dessa object flyttas hit?
public static class PlayersFactory
{
    // public static IPlayer CreatePlayer(string type, string name)
    // {
    //     
    // }
    //
    // public static IPlayer CreatePlayer(string type, string name, string password)
    // {
    //     
    // }
    
    //This made it worse.
    public static List<IPlayer> ParticipantsList(IPlayer playerOne, IPlayer playerTwo)
    {
        List<IPlayer> players = new() {playerOne, playerTwo};
        return players;
    }
}