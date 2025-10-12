using Hamster.Visuals;
using Hamster.Visuals.Representations;

namespace Hamster;

public interface IHamsterMutator
{
    Hamster MutatedHamster { get; init; }
    void SetHungryState();
    void SetFedState();
    void SetHungryVisual();
    void SetFedVisual();
}