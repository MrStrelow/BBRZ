namespace Hamster.Strategies;

public interface IMovementStrategy
{
    void Execute(Hamster hamster, Plane plane);
}
