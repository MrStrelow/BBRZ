namespace Hamster.Strategies;

public interface IRandomMovementStrategy : IMovementStrategy
{
    public Random _random { get; protected set; }
}
