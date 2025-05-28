using SixLabors.ImageSharp;

namespace Hamster.Strategies;

// SRP (Single Responsibility Principle): Responsible for providing HTML-based visuals (could be text, emoji, or image tags).
// LSP (Liskov Substitution Principle): Can be used wherever an IVisualProvider is expected for HTML contexts.
public sealed class ImageRepresentation : IVisualRepresentation
{
    public object Representation { get; init; }
    public string Path { get; init; }

    public ImageRepresentation(string path)
    {
        Path = path;
        Representation = Image.Load(path);
    }
}
