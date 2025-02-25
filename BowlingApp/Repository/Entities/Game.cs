using BowlingApp.Interfaces;

namespace BowlingApp.Repository.Entities;

public class Game : IGame
{
    public IPlayer playerOne { get; }
    public IPlayer playerTwo { get; }

    public Game(IPlayer playerOne, IPlayer playerTwo)
    {
        this.playerOne = playerOne;
        this.playerTwo = playerTwo;
    }
}