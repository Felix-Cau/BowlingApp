using BowlingApp.Core;
using BowlingApp.Factories;
using BowlingApp.Repository.Entities;
using BowlingApp.Repository.Repositories;

namespace BowlingApp.Utilities;

public static class MenuHandler
{
    public static (bool, User?) LoginMenuOption()
    {
        Console.Clear();
        Console.WriteLine(DisplayMenuMessages.EnterUsernameMessage);
        var username = UserInputHandler.UserInputString();
        Console.WriteLine(DisplayMenuMessages.EnterPasswordMessage);
        var password = UserInputHandler.UserInputString();
        
        (bool successfullLogin, User? user) = UserRepository.CheckUserLogin(username, password);
        
        return (successfullLogin, user);
    }

    public static void PlayGameOption(User loggedInUser)
    {
        Console.WriteLine(DisplayMenuMessages.EnterOpponentMessage);
        var guestName = UserInputHandler.UserInputString();
        Guest newGuest = new Guest(guestName);
        var players = PlayersFactory.Participants(loggedInUser, newGuest);

        Game.Run(players);
        Console.ReadKey();
    }
}