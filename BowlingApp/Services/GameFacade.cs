using BowlingApp.Repository.Entities;
using BowlingApp.Utilities;

namespace BowlingApp.Services;

public class GameFacade(MenuHandler menuHandler, EventSystem eventSystem, UserInputHandler userInputHandler)
{
    public void StartGame()
    {
        eventSystem.Subscribe("Created User and saved to Database!", menuHandler);
        eventSystem.Subscribe("Deleted User from Database!", menuHandler);
        eventSystem.Subscribe("Login was successful!", menuHandler);

        var keepGoing = true;

        do
        {
            DisplayMenuMessages.DisplayMainMenu();
            int userMainMenuInput = userInputHandler.UserInputNumber();

            switch (userMainMenuInput)
            {
                //Login
                case 1:
                    (bool successfullLogin, User? loggedInUser) = menuHandler.LoginMenuOption();

                    if (successfullLogin)
                    {
                        eventSystem.Notify("Login was successful!");

                        bool keepLoggedInGoing = true;
                        
                        do
                        {
                            DisplayMenuMessages.DisplayUserMenu();
                            int userMenuInput = userInputHandler.UserInputNumber();

                            switch (userMenuInput)
                            {
                                case 1:
                                    menuHandler.PlayGameOptionAsLoggedIn(loggedInUser!);
                                    break;
                                case 2:
                                    keepLoggedInGoing = false;
                                    break;
                                case 3:
                                    bool isTheUserStillInDb = menuHandler.DeleteUser(loggedInUser!);
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
                    (bool createdUser, User? newUser) = menuHandler.CreateUser();

                    if (createdUser)
                    {
                        eventSystem.Notify("Created User and saved to Database!");

                        var keepLoggedInAfterCreateGoing = true;
                        
                        do
                        {
                            DisplayMenuMessages.DisplayUserMenu();
                            int userMenuInput = userInputHandler.UserInputNumber();

                            switch (userMenuInput)
                            {
                                case 1:
                                    menuHandler.PlayGameOptionAsLoggedIn(newUser!);
                                    break;
                                case 2:
                                    keepLoggedInAfterCreateGoing = false;
                                    break;
                                case 3:
                                    bool isTheUserStillInDb = menuHandler.DeleteUser(newUser!);
                                    if (!isTheUserStillInDb)
                                    {
                                        eventSystem.Notify("Deleted User from Database!");
                                        
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
                    menuHandler.PlayGameOptionAsNonUser();
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