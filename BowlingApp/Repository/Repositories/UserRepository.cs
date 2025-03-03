using BowlingApp.Interfaces;
using BowlingApp.Repository.Entities;
using BowlingApp.Services;

namespace BowlingApp.Repository.Repositories;

public class UserRepository(SingletonLogger logger, AppDbContext context) : IObserver
{
    public (bool, User?) CheckUserLogin(string username, string password)
    {
        User returnUser = context.Users.FirstOrDefault(u => u.Name == username && u.Password == password);

        return returnUser is null ? (false, returnUser) : (true, returnUser);
    }
    
    public bool SaveUser(User newUser)
    {
        bool doesUserExist = context.Users.Any(u => u.Name == newUser.Name);

        if (doesUserExist)
        {
            //Insert logging here
            return false;
        }
        context.Users.Add(newUser);
        context.SaveChanges();
        return true;
    }

    public bool DeleteUser(User user)
    {
        context.Users.Remove(user);
        context.SaveChanges();
        
        bool isUserRemoved = context.Users.Any(u => u.Name == user.Name);
        
        return isUserRemoved;
    }

    public void OnEvent(string eventType)
    {
        logger.Log(eventType);
    }
}