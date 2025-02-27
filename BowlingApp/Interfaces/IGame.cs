namespace BowlingApp.Interfaces;

public interface IGame
{
    void Run(params IPlayer[] players);
    //void Run(List<IPlayer> players);
}