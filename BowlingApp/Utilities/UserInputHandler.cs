namespace BowlingApp.Utilities;

public class UserInputHandler
{
    public int UserInputNumber()
    {
        var userInput = int.Parse(Console.ReadLine().Trim());
        return userInput;
    }

    public string UserInputString()
    {
        var userInput = Console.ReadLine().Trim();
        return userInput;
    }
}