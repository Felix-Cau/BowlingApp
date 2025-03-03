using BowlingApp.Factories;
using BowlingApp.Interfaces;
using BowlingApp.Repository.Entities;
using BowlingApp.Repository.Repositories;
using BowlingApp.Services;

namespace BowlingApp.Utilities;

public class MenuHandler(UserRepository userRepository, UserInputHandler userInputHandler, EventSystem eventSystem, SingletonLogger logger, GameFactory gameFactory) : IObserver
{
    public (bool, User?) LoginMenuOption()
    {
        Console.WriteLine(DisplayMenuMessages.EnterUsernameMessage);
        var username = userInputHandler.UserInputString();
        Console.WriteLine(DisplayMenuMessages.EnterPasswordMessage);
        var password = userInputHandler.UserInputString();
        
        (bool successfulLogin, User? user) = userRepository.CheckUserLogin(username, password);
        
        return (successfulLogin, user);
    }

    public (bool, User?) CreateUser()
    {
        Console.WriteLine(DisplayMenuMessages.CreateUsernameMessage);
        var username = userInputHandler.UserInputString();
        Console.WriteLine(DisplayMenuMessages.CreatePasswordMessage);
        var password = userInputHandler.UserInputString();
        User newUser = new(username, password);
        
        bool couldUserBeSavedWithThatUserName = userRepository.SaveUser(newUser);

        if (couldUserBeSavedWithThatUserName)
        {
            return (true, newUser);
        }
        User nullUser = null;
        return (false, nullUser);
    }

    public bool DeleteUser(User user)
    {
        bool isTheUserStillInDb = userRepository.DeleteUser(user);

        return isTheUserStillInDb;
    }

    public void PlayGameOptionAsLoggedIn(User loggedInUser)
    {
        Console.WriteLine(DisplayMenuMessages.EnterOpponentMessage);
        var guestName = userInputHandler.UserInputString();
        Guest newGuest = new(guestName);

        PlayGame(loggedInUser, newGuest);
    }

    public void PlayGameOptionAsNonUser()
    {
        Console.WriteLine(DisplayMenuMessages.EnterFirstGuestName);
        var guestNameOne = userInputHandler.UserInputString();
        Guest guestOne = new(guestNameOne);
        Console.WriteLine(DisplayMenuMessages.EnterSecondGuestName);
        var guestNameTwo = userInputHandler.UserInputString();
        Guest guestTwo = new(guestNameTwo);

        PlayGame(guestOne, guestTwo);
    }

    private void PlayGame(params IPlayer[] players)
    {
        //Create a game of specified type depending on the input string.
        var game = gameFactory.CreateGame("bowling");
        IObserver gameObserver = (IObserver)game;
        eventSystem.Subscribe("A game of Bowling has been played!", gameObserver);

        game.Run(players);

        eventSystem.Notify("A game of Bowling has been played!");
        eventSystem.Unsubscribe("A game of Bowling has been played!", gameObserver);

        Console.ReadKey();
    }

    public void OnEvent(string eventType)
    {
        logger.Log(eventType);
    }
}