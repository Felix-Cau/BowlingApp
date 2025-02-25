namespace BowlingApp.Interfaces;

public interface IGame
{
    public IPlayer playerOne { get; }
    public IPlayer playerTwo { get; }
}