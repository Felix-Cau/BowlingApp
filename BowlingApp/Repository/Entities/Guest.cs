using BowlingApp.Interfaces;

namespace BowlingApp.Repository.Entities;

public class Guest : IPlayer
{
    public string Name { get; }
    
    public Guest(string name)
    {
        Name = name;
    }

}