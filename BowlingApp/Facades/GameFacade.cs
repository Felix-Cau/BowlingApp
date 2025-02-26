using BowlingApp.Core;
using BowlingApp.Factories;
using BowlingApp.Repository.Entities;
using BowlingApp.Utilities;

namespace BowlingApp.Facades;

public class GameFacade
{
    public void StartGame()
    {
        var keepGoing = true;

        do
        {
            DisplayMenuMessages.DisplayMainMenu();
            int userMainMenuInput = UserInputHandler.UserInputNumber();

            switch (userMainMenuInput)
            {
                //Login
                case 1:
                    (bool SuccessfullLogin, User? loggedInUser) = MenuHandler.LoginMenuOption();

                    if (SuccessfullLogin)
                    {
                        var keepLoggedInGoing = true;
                        
                        do
                        {
                            DisplayMenuMessages.DisplayUserMenu();
                            int userMenuInput = UserInputHandler.UserInputNumber();

                            switch (userMenuInput)
                            {
                                case 1:
                                    MenuHandler.PlayGameOptionAsLoggedIn(loggedInUser!);
                                    break;
                                case 2:
                                    keepLoggedInGoing = false;
                                    break;
                                case 3:
                                    bool isTheUserStillInDb = MenuHandler.DeleteUser(loggedInUser!);
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
                    (bool createdUser, User? newUser) = MenuHandler.CreateUser();
                    
                    if (createdUser)
                    {
                        var keepLoggedInAfterCreateGoing = true;
                        
                        do
                        {
                            DisplayMenuMessages.DisplayUserMenu();
                            int userMenuInput = UserInputHandler.UserInputNumber();

                            switch (userMenuInput)
                            {
                                case 1:
                                    MenuHandler.PlayGameOptionAsLoggedIn(newUser!);
                                    break;
                                case 2:
                                    keepLoggedInAfterCreateGoing = false;
                                    break;
                                case 3:
                                    bool isTheUserStillInDb = MenuHandler.DeleteUser(newUser!);
                                    if (!isTheUserStillInDb)
                                    {
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
                    MenuHandler.PlayGameOptionAsGuest();
                    break;
                //Exit game
                case 4:
                    keepGoing = false;
                    break;
                case 5:
                    Console.WriteLine(DisplayMenuMessages.InvalidOptionMessage);
                    Console.ReadKey();
                    break;
            }
        } while (keepGoing);
        
    }
}