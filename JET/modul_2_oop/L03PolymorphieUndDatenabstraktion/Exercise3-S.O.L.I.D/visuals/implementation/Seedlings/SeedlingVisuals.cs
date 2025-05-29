using Hamster.Visuals.Representations;

namespace Hamster.Visuals;

// TODO: schlechter weil interface eher nicht schlank ist.
// -> Ist jedoch gewünscht, denn wenn eine neue Representation eingeführt wird, muss diese für alle Implementiert werden.
public class SeedlingVisuals : IVisuals
{
    // TODO: wir machen das in zukunft lazy - bedeutet erst wenn wir z.B. eine image representation brauchen, dann wird diese erzeugt.
    public ImageRepresentation ImageRepresentation { get; init; } = new("../../../resources/Seedling.png");
    public UnicodeRepresentation UnicoeRepresentation { get; init; } = new("🌱");
}