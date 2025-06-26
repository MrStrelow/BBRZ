using System;
using System.IO;
using System.Text;
using System.Globalization;
using Hamster.Strategies;
using Hamster.Visuals.Representations;
namespace Hamster;

public sealed class HtmlRenderer : IRenderer
{
    private readonly Plane _plane;
    private readonly string _filePath;
    private string[,] _planeVisualRepresentations;

    public int TimeToSleepMs { get; set; } = 1000;
    private readonly int _maxWidth = new int[] { Plane.Visual.HtmlRepresentation.SizeToDisplay, Seedling.Visual.HtmlRepresentation.SizeToDisplay }.Max();

    public HtmlRenderer(Plane plane, string outputFilePath = "../../../simulation.html")
    {
        _plane = plane;
        _filePath = outputFilePath;
        // Achtung! verwirrend... IRepresentation = new HtmlRepresentation vs. (IRepresentation, string) = new (HtmlRepresentation, string) -> last is wrong
        _planeVisualRepresentations = new string[_plane.Size, _plane.Size];
    }

    public void Render()
    {
        StringBuilder htmlBuilder = new StringBuilder();

        // Start HTML document
        htmlBuilder.AppendLine("<!DOCTYPE html>");
        htmlBuilder.AppendLine("<html lang='en'>");
        htmlBuilder.AppendLine("<head>");
        htmlBuilder.AppendLine("    <meta charset='UTF-8'>");
        htmlBuilder.AppendLine("    <meta name='viewport' content='width=device-width, initial-scale=1.0'>");
        htmlBuilder.AppendLine($"    <meta http-equiv='refresh' content='{TimeToSleepMs/1000}'>");

        htmlBuilder.AppendLine("    <title>Hamster Simulation</title>");
        htmlBuilder.AppendLine("    <style>");
        htmlBuilder.AppendLine("        body { font-family: Arial, sans-serif; display: flex; flex-direction: column; align-items: center; margin-top: 20px; background-color: #f0f0f0; }");
        htmlBuilder.AppendLine("        table { border-collapse: collapse; margin: 20px; box-shadow: 0 4px 8px rgba(0,0,0,0.1); }");
        htmlBuilder.AppendLine("        td { width: 35px; height: 35px; text-align: center; vertical-align: middle; border: 1px solid #ccc; font-size: 24px; background-color: #fff; }");
        
        htmlBuilder.AppendLine("    </style>");
        htmlBuilder.AppendLine("</head>");
        htmlBuilder.AppendLine("<body>");
        htmlBuilder.AppendLine("    <h1>Hamster Simulation</h1>");
        htmlBuilder.AppendLine("    <table>");

        // Create a temporary display grid for easier HTML generation
        

        // Initialize with earth representation
        for (int i = 0; i < _plane.Size; i++)
        {
            for (int j = 0; j < _plane.Size; j++)
            {
                // is moving the background style to its own IRepresentation overkill?
                // At the moment perhaps. But if things get more complicated, it could result in this.
                // See Blazor and other single page applications like React and Next.js.
                // After that we can combin a backgorund and foregraund representation.
                _planeVisualRepresentations[i, j] = 
                    $"<td " +
                        $"style='" +
                            $"background-color:#8B4513; " +
                            $"max-width: {_maxWidth}px; " +
                            $"max-height: {_maxWidth}px; " +
                            $"overflow: auto;" +
                        $"'" +
                    $"> " +
                        Plane.Visual.HtmlRepresentation +
                    $"</td>";
            }
        }

        // Place Seedlings onto the display grid
        foreach (var Seedling in _plane.Seedlings.Values)
        {
            if (IsValidPosition(Seedling.Position)) // remove to Trust plane as a server.
            {
                _planeVisualRepresentations[Seedling.Position.y, Seedling.Position.x] = 
                    $"<td " +
                        $"style='" +
                            $"background-color:#90EE90; " +
                            $"max-width: {_maxWidth}px; " +
                            $"max-height: {_maxWidth}px; " +
                            $"overflow: auto;" +
                        $"'" +
                    $"> " +
                        Seedling.Visual.HtmlRepresentation +
                    $"</td>";
            }
        }

        // Place hamsters onto the display grid
        foreach (var hamster in _plane.Hamsters)
        {
            if (IsValidPosition(hamster.Position))
            {
                string backgroundStyle = hamster.IsHungry ? "background-color:#FFCCCB" : "background-color:#ADD8E6";

                _planeVisualRepresentations[hamster.Position.y, hamster.Position.x] = 
                    $"<td " +
                        $"style='" +
                            $"{backgroundStyle}; " +
                            $"max-width: {_maxWidth}px; " +
                            $"max-height: {_maxWidth}px; " +
                            $"overflow: auto;" +
                        $"'" +
                    $"> " +
                        hamster.CurrentVisual.HtmlRepresentation +
                    $"</td>";
            }
        }

        // Build table rows from the display grid
        for (int i = 0; i < _plane.Size; i++)
        {
            htmlBuilder.AppendLine("        <tr>");
            for (int j = 0; j < _plane.Size; j++)
            {
                htmlBuilder.Append(_planeVisualRepresentations[i, j]);
            }
            htmlBuilder.AppendLine("        </tr>");
        }

        htmlBuilder.AppendLine("    </table>");
        htmlBuilder.AppendLine("</body>");
        htmlBuilder.AppendLine("</html>");

        // Write the generated HTML to the file
        try
        {
            File.WriteAllText(_filePath, htmlBuilder.ToString());
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error writing HTML file: {ex.Message}");
            Console.ResetColor();
        }

        Thread.Sleep(TimeToSleepMs);
    }

    private bool IsValidPosition((int x, int y) position)
    {
        return position.y < _plane.Size && position.x < _plane.Size && position.y >= 0 && position.x >= 0;
    }
}