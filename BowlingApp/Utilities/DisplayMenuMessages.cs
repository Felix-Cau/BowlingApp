namespace BowlingApp.Utilities;

public class DisplayMenuMessages
{
    //Things connected to MainMenu
    private List<string> mainMenuItems =
    [
        "Welcome to the Bowling app!",
        "Navigate in the menu by simply writing the number of the option you wish to do.",
        "1. Login",
        "2. Create User",
        "3. Continue as Guest",
        "4. Exit Game"
    ];

    public void DisplayMainMenu()
    {
        foreach (string str in mainMenuItems)
        {
            Console.WriteLine(str);
        }
    }
    
    //Things connected to log in
    public const string EnterUsernameMessage = "Enter your Username (It's case sensitive):";
    public const string EnterPasswordMessage = "Enter your password (It's case sensitive):";
    public const string InvalidLoginCredentials =
        "Username or password is incorrect. Please try again and remember that they are case sensitive. Press any key to continue.";

    //Things connected to when user is logged in
    private List<string> userMenu =
    [
        "1. Start Game",
        "2. Logout",
        "3. Delete Account"
    ];

    public void DisplayUserMenu()
    {
        foreach (string str in userMenu)
        {
            Console.WriteLine(str);
        }
    }
    
    public const string EnterOpponentMessage = "Enter your opponents name:";
    
    //Create User Menu
    public const string CreateUsernameMessage = "Enter your Username:";
    public const string CreatePasswordMessage = "Enter your Password:";
    public const string CouldNotCreateUserWithThatUsername = "The Username is already taken. Press any key to continue and try again.";
    
    //Guest connected messages
    public const string EnterFirstGuestName = "Enter the name of the first player:";
    public const string EnterSecondGuestName = "Enter the name of the second player:";
    
    //Invalid option message
    public const string InvalidOptionMessage = "Please enter a valid option! Press any key to continue.";
}