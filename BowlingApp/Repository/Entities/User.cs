using BowlingApp.Interfaces;

namespace BowlingApp.Repository.Entities;

public class User : IPlayer
{
    public string Name { get; set; }
    public string Password { get; set;  }

    public User()
    {
        
    }
    
    public User(string name, string password)
    {
        Name = name;
        Password = password;
    }
}