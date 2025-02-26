using BowlingApp.Repository.Entities;

namespace BowlingApp.Repository.Repositories;

public static class UserRepository
{
    private static AppDbContext _context = new();

    public static (bool, User?) CheckUserLogin(string username, string password)
    {
        User returnUser = _context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);

        return returnUser is null ? (false, returnUser) : (true, returnUser);
    }
    
    public static bool SaveUser(User newUser)
    {
        bool doesUserExist = _context.Users.Any(u => u.Name == newUser.Name);

        if (doesUserExist)
        {
            //Insert logging here
            return false;
        }
        _context.Users.Add(newUser);
        _context.SaveChanges();
        return true;
    }
}