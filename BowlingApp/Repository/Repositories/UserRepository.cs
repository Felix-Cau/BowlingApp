using BowlingApp.Repository.Entities;

namespace BowlingApp.Repository.Repositories;

public class UserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

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