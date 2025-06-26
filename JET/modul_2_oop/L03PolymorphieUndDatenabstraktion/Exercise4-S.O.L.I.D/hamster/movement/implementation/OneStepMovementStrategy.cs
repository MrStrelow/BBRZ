namespace Hamster.Strategies;

// SRP (Single Responsibility Principle): This class is solely responsible for the random walk movement logic.
// LSP (Liskov Substitution Principle): Instances of RandomWalkMovement can be used wherever an IMovementStrategy is expected.
internal sealed class OneStepMovementStrategy : IRandomMovementStrategy
{
    public Random _random { get; set; } = new Random();

    // SRP: The PlanMove method encapsulates the specific algorithm for random single-step movement.
    public void Execute(Hamster hamster, Plane plane)
    {
        // Guard Clauses
        if (hamster is null) throw new ArgumentNullException(nameof(hamster));
        if (plane is null) throw new ArgumentNullException(nameof(plane));

        int directionIndex = _random.Next(Enum.GetValues<Direction>().Length);
        var direction = Enum.GetValues<Direction>()[directionIndex];

        // Delegates to Plane's Position method to actually move the hamster.
        // This keeps the Plane responsible for managing positions on the grid.
        plane.Position(hamster, direction);
    }
}
