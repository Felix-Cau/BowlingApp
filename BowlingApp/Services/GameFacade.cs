using BowlingApp.Core;
using BowlingApp.Factories;
using BowlingApp.Repository.Entities;
using BowlingApp.Repository.Repositories;
using BowlingApp.Utilities;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BowlingApp.Services;

public class GameFacade
{
    MenuHandler _menuHandler = new();
    private readonly EventSystem _eventSystem = new();
    private readonly SingletonLogger _logger = SingletonLogger.Instance;

    public void StartGame()
    {
        _eventSystem.Subscribe("Created User and saved to Database!", _menuHandler);
        _eventSystem.Subscribe("Deleted User from Database!", _menuHandler);
        _eventSystem.Subscribe("Login was successful!", _menuHandler);

        var keepGoing = true;

        do
        {
            DisplayMenuMessages.DisplayMainMenu();
            int userMainMenuInput = UserInputHandler.UserInputNumber();

            switch (userMainMenuInput)
            {
                //Login
                case 1:
                    (bool SuccessfullLogin, User? loggedInUser) = _menuHandler.LoginMenuOption();

                    if (SuccessfullLogin)
                    {
                        _eventSystem.Notify("Login was successful!");
                        var keepLoggedInGoing = true;
                        
                        do
                        {
                            DisplayMenuMessages.DisplayUserMenu();
                            int userMenuInput = UserInputHandler.UserInputNumber();

                            switch (userMenuInput)
                            {
                                case 1:
                                    _menuHandler.PlayGameOptionAsLoggedIn(loggedInUser!);
                                    break;
                                case 2:
                                    keepLoggedInGoing = false;
                                    break;
                                case 3:
                                    bool isTheUserStillInDb = _menuHandler.DeleteUser(loggedInUser!);
                                    if (!isTheUserStillInDb)
                                    {
                                        keepLoggedInGoing = false;
                                    }
                                    break;
                                default:
                                    Console.WriteLine(DisplayMenuMessages.InvalidOptionMessage);
                                    Console.ReadKey();
                                    break;
                            }
                        } while (keepLoggedInGoing);
                    }
                    else
                    {
                        Console.WriteLine(DisplayMenuMessages.InvalidLoginCredentials);
                        Console.ReadKey();
                    }
                    break;
                //Create user
                case 2:
                    (bool createdUser, User? newUser) = _menuHandler.CreateUser();

                    if (createdUser)
                    {
                        _eventSystem.Notify("Created User and saved to Database!");

                        var keepLoggedInAfterCreateGoing = true;
                        
                        do
                        {
                            DisplayMenuMessages.DisplayUserMenu();
                            int userMenuInput = UserInputHandler.UserInputNumber();

                            switch (userMenuInput)
                            {
                                case 1:
                                    _menuHandler.PlayGameOptionAsLoggedIn(newUser!);
                                    break;
                                case 2:
                                    keepLoggedInAfterCreateGoing = false;
                                    break;
                                case 3:
                                    bool isTheUserStillInDb = _menuHandler.DeleteUser(newUser!);
                                    if (!isTheUserStillInDb)
                                    {
                                        _eventSystem.Notify("Deleted User from Database!");

                                        keepLoggedInAfterCreateGoing = false;
                                    }
                                    break;
                                default:
                                    Console.WriteLine(DisplayMenuMessages.InvalidOptionMessage);
                                    Console.ReadKey();
                                    break;
                            }
                        } while (keepLoggedInAfterCreateGoing);
                    }
                    else
                    {
                        Console.WriteLine(DisplayMenuMessages.CouldNotCreateUserWithThatUsername);
                        Console.ReadKey();
                    }
                    break;
                //Continue as Guest
                case 3:
                    _menuHandler.PlayGameOptionAsNonUser();
                    break;
                //Exit game
                case 4:
                    keepGoing = false;
                    Console.Clear();
                    break;
                case 5:
                    Console.WriteLine(DisplayMenuMessages.InvalidOptionMessage);
                    Console.ReadKey();
                    break;
            }
        } while (keepGoing);
        
    }
}