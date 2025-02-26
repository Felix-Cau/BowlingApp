namespace BowlingApp.Utilities;

public class UserInputHandler
{
    public static int UserInputNumber()
    {
        var userInput = int.Parse(Console.ReadLine().Trim());
        return userInput;
    }

    public static string UserInputString()
    {
        var userInput = Console.ReadLine().Trim();
        return userInput;
    }
}