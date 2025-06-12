namespace Hamster.Strategies;

// SRP (Single Responsibility Principle): This class is solely responsible for the double-step movement logic.
// LSP (Liskov Substitution Principle): Instances of DoubleStepMovement can be used wherever an IMovementStrategy is expected.
internal sealed class DoubleStepMovementStrategy : IRandomMovementStrategy
{
    public Random _random { get; set; } = new Random();

    // SRP: The PlanMove method encapsulates the specific algorithm for random double-step movement.
    public void Execute(Hamster hamster, Plane plane)
    {
        // Guard Clauses
        if (hamster is null) throw new ArgumentNullException(nameof(hamster));
        if (plane is null) throw new ArgumentNullException(nameof(plane));

        int firstDirectionIndex = _random.Next(Enum.GetValues<Direction>().Length);
        int secondDirectionIndex = _random.Next(Enum.GetValues<Direction>().Length);

        var firstDirection = Enum.GetValues<Direction>()[firstDirectionIndex];
        var secondDirection = Enum.GetValues<Direction>()[secondDirectionIndex];

        var directions = new List<Direction>() { firstDirection, secondDirection };

        // Delegates to Plane's Position method to actually move the hamster.
        plane.Position(hamster, directions);
    }
}
