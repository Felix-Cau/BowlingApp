using BowlingApp.Factories;
using BowlingApp.Interfaces;
using BowlingApp.Repository.Entities;
using BowlingApp.Repository.Repositories;
using BowlingApp.Services;
using System.Xml.Linq;

namespace BowlingApp.Utilities;

public class MenuHandler : IObserver
{
    private UserRepository _userRepository = new();
    private readonly SingletonLogger _logger = SingletonLogger.Instance;
    private readonly EventSystem _eventSystem = new();

    public (bool, User?) LoginMenuOption()
    {
        Console.WriteLine(DisplayMenuMessages.EnterUsernameMessage);
        var username = UserInputHandler.UserInputString();
        Console.WriteLine(DisplayMenuMessages.EnterPasswordMessage);
        var password = UserInputHandler.UserInputString();
        
        (bool successfullLogin, User? user) = _userRepository.CheckUserLogin(username, password);
        
        return (successfullLogin, user);
    }

    public (bool, User?) CreateUser()
    {
        Console.WriteLine(DisplayMenuMessages.CreateUsernameMessage);
        var username = UserInputHandler.UserInputString();
        Console.WriteLine(DisplayMenuMessages.CreatePasswordMessage);
        var password = UserInputHandler.UserInputString();
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
        var guestName = UserInputHandler.UserInputString();
        Guest newGuest = new Guest(guestName);
        Console.Clear();
        
        List<IPlayer> players = PlayersFactory.ParticipantsList(loggedInUser, newGuest);

        PlayGame(players);
    }

    public void PlayGameOptionAsNonUser()
    {
        Console.WriteLine(DisplayMenuMessages.EnterFirstGuestName);
        var guestNameOne = UserInputHandler.UserInputString();
        Guest guestOne = new Guest(guestNameOne);
        Console.WriteLine(DisplayMenuMessages.EnterSecondGuestName);
        var guestNameTwo = UserInputHandler.UserInputString();
        Guest guestTwo = new Guest(guestNameTwo);
        
        List<IPlayer> players = PlayersFactory.ParticipantsList(guestOne, guestTwo);

        PlayGame(players);
    }

    private void PlayGame(List<IPlayer> players)
    {
        var game = GameFactory.CreateGame("bowling");
        IObserver gameObserver = (IObserver)game;
        _eventSystem.Subscribe("A game of Bowling has been played!", gameObserver);

        game.Run(players);
        _eventSystem.Notify("A game of Bowling has been played!");

        Console.ReadKey();
    }

    public void OnEvent(string eventType)
    {
        _logger.Log(eventType);
    }
}