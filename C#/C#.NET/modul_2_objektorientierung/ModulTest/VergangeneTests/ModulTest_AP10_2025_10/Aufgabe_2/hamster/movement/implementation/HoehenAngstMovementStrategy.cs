namespace Hamster.Strategies;

internal sealed class HoehenAngstMovementStrategy : IRandomMovementStrategy
{
    public Random _random { get; set; } = new Random();

    public void Execute(Hamster hamster, Plane plane)
    {
        // Guard Clauses
        if (hamster is null) throw new ArgumentNullException(nameof(hamster));
        if (plane is null) throw new ArgumentNullException(nameof(plane));

        plane.Position(hamster, Direction.DOWN);
    }
}
