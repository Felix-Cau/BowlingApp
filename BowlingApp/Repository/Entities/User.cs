using System.ComponentModel.DataAnnotations;
using BowlingApp.Interfaces;

namespace BowlingApp.Repository.Entities;

public class User : IPlayer
{
    [Required]
    public string Name { get; set; }
    [Required]
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