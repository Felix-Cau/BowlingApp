using BowlingApp.Interfaces;
using BowlingApp.Repository.Entities;
using BowlingApp.Services;

namespace BowlingApp.Repository.Repositories;

public class UserRepository : IObserver
{
    //Part of the repository pattern to separate the database from the business logic.

    private static AppDbContext _context = new();
    private readonly SingletonLogger _logger = SingletonLogger.Instance;

    public (bool, User?) CheckUserLogin(string username, string password)
    {
        User returnUser = _context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);

        return returnUser is null ? (false, returnUser) : (true, returnUser);
    }
    
    public bool SaveUser(User newUser)
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

    public bool DeleteUser(User user)
    {
        _context.Users.Remove(user);
        _context.SaveChanges();
        
        bool isUserRemoved = _context.Users.Any(u => u.Name == user.Name);
        
        return isUserRemoved;
    }

    public void OnEvent(string eventType)
    {
        _logger.Log(eventType);
    }
}