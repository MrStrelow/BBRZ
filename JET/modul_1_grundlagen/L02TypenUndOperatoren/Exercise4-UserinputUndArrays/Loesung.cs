using System;
using System.Globalization;

// Definiere die erlaubten Trennzeichen als Array von Strings.
string[] delimiters = { " ", "-", ",", "/", "🧱", "🔺" };

// Startkoordinaten einlesen
Console.Write("Wähle die Spielfigur [x y]: ");
string input = Console.ReadLine();

// Eingabe anhand der Trennzeichen aufteilen und leere Einträge entfernen.
string[] teile = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
int xStart = int.Parse(teile[0]);
int yStart = int.Parse(teile[1]);

// Zielkoordinaten einlesen
Console.Write("Wähle das Ziel [x y]: ");
input = Console.ReadLine(); // Bestehende Variable 'input' wiederverwenden.

teile = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries); // Bestehende Variable 'teile' wiederverwenden.
int xEnd = int.Parse(teile[0]);
int yEnd = int.Parse(teile[1]);

// Distanz mit der Formel berechnen.
double distanz = Math.Sqrt(Math.Pow(xEnd - xStart, 2) + Math.Pow(yEnd - yStart, 2));

// Ein CultureInfo-Objekt für das deutsche Format erstellen.
CultureInfo deCulture = new CultureInfo("de-DE");

// Die Distanz in das gewünschte Format umwandeln (F2 = zwei feste Nachkommastellen).
string formattedDistanz = distanz.ToString("F2", deCulture);

Console.WriteLine("Die Distanz beträgt: " + formattedDistanz);
// Interpolated String ($"...") zur einfacheren Ausgabe verwenden.
Console.WriteLine($"Die Figur auf Position [x:{xStart} y:{yStart}] wurde auf Position [x:{xEnd} y:{yEnd}] geschoben. Distanz: {formattedDistanz}");
