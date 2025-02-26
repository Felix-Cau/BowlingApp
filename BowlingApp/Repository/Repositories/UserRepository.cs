using BowlingApp.Repository.Entities;

namespace BowlingApp.Repository.Repositories;

public class UserRepository
{
    private AppDbContext _context = new();

    public List<User> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    //Change this to return a bool if save was successfull or if the username already existed
    public void SaveUser(User newUser)
    {
        _context.Users.Add(newUser);
        _context.SaveChanges();
    }
}