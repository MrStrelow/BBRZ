using SixLabors.ImageSharp;
using System.IO;
using System.Text.RegularExpressions;

namespace Hamster.Visuals.Representations;

// wir verwendne hier in der zukunft generics.
public sealed class ImageRepresentation : IRepresentation
{
    private string _path;
    public object Representation { get; init; }
    public string Path { 
        get 
        {
            return Regex.Replace(_path, @"^(\.\.\/)+", string.Empty);
        }
        init 
        {
            _path = value;
        }
    }
    public int SizeToDisplay { get; init; }

    public ImageRepresentation(string path, int sizeToDisplay)
    {
        _path = path;
        Representation = Image.Load(path);
        SizeToDisplay = sizeToDisplay;
    }

    public override string ToString()
    {
        return Regex.Replace(Path, @"^(\.\.\/)+", string.Empty);
    }
}
