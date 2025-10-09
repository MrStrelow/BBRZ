namespace Hamster.Strategies;

internal sealed class DoubleStepMovementStrategy : IRandomMovementStrategy
{
    public Random _random { get; set; } = new Random();

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

        plane.Position(hamster, directions);
    }
}
