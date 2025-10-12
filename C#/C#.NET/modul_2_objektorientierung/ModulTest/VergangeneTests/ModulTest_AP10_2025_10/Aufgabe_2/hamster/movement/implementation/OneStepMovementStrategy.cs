namespace Hamster.Strategies;

internal sealed class OneStepMovementStrategy : IRandomMovementStrategy
{
    public Random _random { get; set; } = new Random();

    public void Execute(Hamster hamster, Plane plane)
    {
        // Guard Clauses
        if (hamster is null) throw new ArgumentNullException(nameof(hamster));
        if (plane is null) throw new ArgumentNullException(nameof(plane));

        int directionIndex = _random.Next(Enum.GetValues<Direction>().Length);
        var direction = Enum.GetValues<Direction>()[directionIndex];

        plane.Position(hamster, direction);
    }
}
