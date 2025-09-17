namespace Hamster.Strategies;

// SRP (Single Responsibility Principle): This class is solely responsible for the double-step movement logic.
// LSP (Liskov Substitution Principle): Instances of DoubleStepMovement can be used wherever an IMovementStrategy is expected.
internal sealed class NervousMovementStrategy : IRandomMovementStrategy
{
    public Random _random { get; set; } = new Random();

    public void Execute(Hamster hamster, Plane plane)
    {
        // Guard Clauses
        if (hamster is null) throw new ArgumentNullException(nameof(hamster));
        if (plane is null) throw new ArgumentNullException(nameof(plane));

        int directionIndex = _random.Next(Enum.GetValues<Direction>().Length);
        var direction = Enum.GetValues<Direction>()[directionIndex];

        var directions = new List<Direction>() { direction, direction };

        // Delegates to Plane's Position method to actually move the hamster.
        plane.Position(hamster, directions);
    }
}
