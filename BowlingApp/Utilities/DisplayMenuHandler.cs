namespace BowlingApp.Utilities;

public static class DisplayMenuHandler
{
    //Is this really a MenuFacade or some kind of "service"?
    
    //Things connected to MainMenu
    private static List<string> mainMenuItems =
    [
        "Welcome to the Bowling app!",
        "Navigate in the menu by simply writing the number of the option you wish to do.",
        "1. Login",
        "2. Create User",
        "3. Continue as Guest",
        "4. Exit Game"
    ];

    public static void DisplayMainMenu()
    {
        Console.Clear();
        foreach (string str in mainMenuItems)
        {
            Console.WriteLine(str);
        }
    }
    
    //Things connected to log in
    public const string EnterUsernameMessage = "Enter your Username (It's case sensitive):";
    public const string EnterPasswordMessage = "Enter your password (It's case sensitive):";

    //Things connected to when user is logged in
    private static List<string> userMenu =
    [
        "1. Start Game",
        "2. Logout"
    ];

    public static void DisplayUserMenu()
    {
        Console.Clear();
        foreach (string str in userMenu)
        {
            Console.WriteLine(str);
        }
    }
    
    //Create User Menu
    public const string CreateUsernameMessage = "Enter your Username:";
    public const string CreatePasswordMessage = "Enter your Password:";
    
    //Guest connected messages
    public const string EnterFirstGuestName = "Enter the name of the first player:";
    public const string EnterSecondGuestName = "Enter the name of the second player:";
}