namespace Hamster;

public interface IHamsterMutator
{
    Hamster MutatedHamster { get; init; }
    void SetHungryState(bool isHungry);
}