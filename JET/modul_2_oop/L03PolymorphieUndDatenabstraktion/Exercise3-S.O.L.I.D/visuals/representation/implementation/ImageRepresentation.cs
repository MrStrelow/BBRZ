using SixLabors.ImageSharp;

namespace Hamster.Visuals.Representations;

// wir verwendne hier in der zukunft generics.
public sealed class ImageRepresentation : IRepresentation
{
    public object Representation { get; init; }
    public string Path { get; init; }

    public ImageRepresentation(string path)
    {
        Path = path;
        Representation = Image.Load(path);
    }

    public override string ToString()
    {
        return Path;
    }
}
