namespace Hamster.Strategies;

internal sealed class SmokingMovementStrategy : IRandomMovementStrategy
{
    public Random _random { get; set; } = new Random();

    public void Execute(Hamster hamster, Plane plane)
    {
        // Guard Clauses
        if (hamster is null) throw new ArgumentNullException(nameof(hamster));
        if (plane is null) throw new ArgumentNullException(nameof(plane));

        var allowedDirections = new[] { Direction.UP, Direction.RIGHT };

        int directionIndex = _random.Next(allowedDirections.Length);
        var direction = allowedDirections[directionIndex];

        plane.Position(hamster, direction);
    }
}
