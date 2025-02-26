using BowlingApp.Core;
using BowlingApp.Factories;
using BowlingApp.Interfaces;
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

    public static (bool, User?) CreateUser()
    {
        Console.Clear();
        Console.WriteLine(DisplayMenuMessages.EnterUsernameMessage);
        var username = UserInputHandler.UserInputString();
        Console.WriteLine(DisplayMenuMessages.EnterPasswordMessage);
        var password = UserInputHandler.UserInputString();
        User newUser = new(username, password);
        
        bool couldUserBeSavedWithThatUserName = UserRepository.SaveUser(newUser);

        if (couldUserBeSavedWithThatUserName)
        {
            return (true, newUser);
        }
        User nullUser = null;
        return (false, nullUser);
    }

    public static void PlayGameOptionAsLoggedIn(User loggedInUser)
    {
        Console.WriteLine(DisplayMenuMessages.EnterOpponentMessage);
        var guestName = UserInputHandler.UserInputString();
        Guest newGuest = new Guest(guestName);
        
        List<IPlayer> players = PlayersFactory.Participants(loggedInUser, newGuest);

        Game.Run(players);
        Console.ReadKey();
    }

    public static void PlayGameOptionAsGuest()
    {
        Console.WriteLine(DisplayMenuMessages.EnterFirstGuestName);
        var guestNameOne = UserInputHandler.UserInputString();
        Guest guestOne = new Guest(guestNameOne);
        Console.WriteLine(DisplayMenuMessages.EnterSecondGuestName);
        var guestNameTwo = UserInputHandler.UserInputString();
        Guest guestTwo = new Guest(guestNameTwo);
        
        List<IPlayer> players = PlayersFactory.Participants(guestOne, guestTwo);
        
        Game.Run(players);
        Console.ReadKey();
    }
}