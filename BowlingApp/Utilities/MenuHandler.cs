using BowlingApp.Factories;
using BowlingApp.Interfaces;
using BowlingApp.Repository.Entities;
using BowlingApp.Repository.Repositories;
using BowlingApp.Services;

namespace BowlingApp.Utilities;

public class MenuHandler : IObserver
{
    //Creates an instance of the userRepository as a part of the Repository pattern to separate the business logic from the database.
    private readonly UserRepository _userRepository = new();
    private readonly SingletonLogger _logger = SingletonLogger.Instance;
    private readonly EventSystem _eventSystem = new();
    readonly UserInputHandler _userInputHandler = new();

    public (bool, User?) LoginMenuOption()
    {
        Console.WriteLine(DisplayMenuMessages.EnterUsernameMessage);
        var username = _userInputHandler.UserInputString();
        Console.WriteLine(DisplayMenuMessages.EnterPasswordMessage);
        var password = _userInputHandler.UserInputString();
        
        (bool successfullLogin, User? user) = _userRepository.CheckUserLogin(username, password);
        
        return (successfullLogin, user);
    }

    public (bool, User?) CreateUser()
    {
        Console.WriteLine(DisplayMenuMessages.CreateUsernameMessage);
        var username = _userInputHandler.UserInputString();
        Console.WriteLine(DisplayMenuMessages.CreatePasswordMessage);
        var password = _userInputHandler.UserInputString();
        User newUser = new(username, password);
        
        bool couldUserBeSavedWithThatUserName = _userRepository.SaveUser(newUser);

        if (couldUserBeSavedWithThatUserName)
        {
            return (true, newUser);
        }
        User nullUser = null;
        return (false, nullUser);
    }

    public bool DeleteUser(User user)
    {
        bool IsTheUserStillInDb = _userRepository.DeleteUser(user);

        return IsTheUserStillInDb;
    }

    public void PlayGameOptionAsLoggedIn(User loggedInUser)
    {
        Console.WriteLine(DisplayMenuMessages.EnterOpponentMessage);
        var guestName = _userInputHandler.UserInputString();
        Guest newGuest = new Guest(guestName);

        PlayGame(loggedInUser, newGuest);
    }

    public void PlayGameOptionAsNonUser()
    {
        Console.WriteLine(DisplayMenuMessages.EnterFirstGuestName);
        var guestNameOne = _userInputHandler.UserInputString();
        Guest guestOne = new Guest(guestNameOne);
        Console.WriteLine(DisplayMenuMessages.EnterSecondGuestName);
        var guestNameTwo = _userInputHandler.UserInputString();
        Guest guestTwo = new Guest(guestNameTwo);

        PlayGame(guestOne, guestTwo);
    }

    private void PlayGame(params IPlayer[] players)
    {
        //Create a game of specified type depending on the input string.
        var game = GameFactory.CreateGame("bowling");
        IObserver gameObserver = (IObserver)game;
        _eventSystem.Subscribe("A game of Bowling has been played!", gameObserver);

        game.Run(players);

        _eventSystem.Notify("A game of Bowling has been played!");
        _eventSystem.Unsubscribe("A game of Bowling has been played!", gameObserver);

        Console.ReadKey();
    }

    public void OnEvent(string eventType)
    {
        _logger.Log(eventType);
    }
}