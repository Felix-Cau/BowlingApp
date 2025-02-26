using BowlingApp.Repository.Entities;

namespace BowlingApp.Repository.Repositories;

public class UserRepository
{
    private AppDbContext _context = new();

    public User GetUser(User user)
    {
        return _context.Users.Find(user.Name);
    }
    
    public void SaveUser(User newUser)
    {
        bool doesUserExist = _context.Users.Any(u => u.Name == newUser.Name);

        if (doesUserExist)
        {
            //Insert logging here
            return;
        }
        _context.Users.Add(newUser);
        _context.SaveChanges();
    }
}