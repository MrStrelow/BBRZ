using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hamster;

public class HtmlRenderer : IRenderer
{
    // Felder
    private readonly Plane _plane;
    private readonly string _filePath;
    public int DelayInMilliseconds { get; set; } = 1000;

    public HtmlRenderer(Plane plane, string outputFilePath = "../../../simulation.html")
    {
        _plane = plane ?? throw new ArgumentNullException(nameof(plane));
        _filePath = outputFilePath;
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
        htmlBuilder.AppendLine($"    <meta http-equiv='refresh' content='{DelayInMilliseconds / 1000}'>");

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
        string[,] displayPlane = new string[_plane.Size, _plane.Size];

        // Initialize with earth representation
        for (int i = 0; i < _plane.Size; i++)
        {
            for (int j = 0; j < _plane.Size; j++)
            {
                displayPlane[i, j] = $"<td style='background-color:#8B4513;'>{Plane.EarthRepresentation}</td>";
            }
        }

        // Place seeds onto the display grid
        foreach (var seed in _plane.Seeds.Values)
        {
            if (IsValidPosition(seed.Position))
            {
                displayPlane[seed.Position.y, seed.Position.x] = $"<td style='background-color:#90EE90;'>{Seed.Representation}</td>";
            }
        }

        // Place hamsters onto the display grid
        foreach (var hamster in _plane.Hamsters)
        {
            if (IsValidPosition(hamster.Position))
            {
                string hamsterStyle = hamster.IsHungry ? "background-color:#FFCCCB;" : "background-color:#ADD8E6;";
                displayPlane[hamster.Position.y, hamster.Position.x] = $"<td style='{hamsterStyle}'>{hamster.Representation}</td>";
            }
        }

        // Build table rows from the display grid
        for (int i = 0; i < _plane.Size; i++)
        {
            htmlBuilder.AppendLine("        <tr>");
            for (int j = 0; j < _plane.Size; j++)
            {
                htmlBuilder.Append(displayPlane[i, j]);
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

        Thread.Sleep(DelayInMilliseconds);

    }
    private bool IsValidPosition((int x, int y) position)
    {
        return position.y < _plane.Size && position.x < _plane.Size && position.y >= 0 && position.x >= 0;
    }
}
