namespace BowlingApp.Interfaces;

public interface IGame
{
    void Run(params IPlayer[] players);
}