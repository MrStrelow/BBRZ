using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Ticketverkauf.Entities;

namespace Ticketverkauf.Repositories
{
    public interface IZugRepository
    {
        Task<IEnumerable<Zug>> GetAllAsync();
        Task<Zug?> GetByIdAsync(int id);
        Task SaveAllAsync(IEnumerable<Zug> zuege);
    }

    public class ZugRepository : IZugRepository
    {
        // TODO: Erstelle die benötigten Felder und Eigenschaften.
        private readonly string _filePath;
        private static readonly SemaphoreSlim _fileLock = new(1, 1);
        private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

        // TODO: Implementiere den Konstruktor.
        public ZugRepository()
        {
            var dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(dataDirectory);
            _filePath = Path.Combine(dataDirectory, "zuege.json");
        }

        public async Task<IEnumerable<Zug>> GetAllAsync()
        {
            // TODO: Implementiere:
            // * ein Lock für File während dem Lesen, welches gleichzeige Zugriffe verhindert.
            // * Versuche (Try) die Methode ReadFromFileAsync aufzurufen und gib anschließen, egal was passiert (finally), den Lock wieder frei.
            await _fileLock.WaitAsync();
            try { return await ReadFromFileAsync(); }
            finally { _fileLock.Release(); }
        }

        public async Task<Zug?> GetByIdAsync(int id)
        {
            // TODO: Implementiere:
            // * rufe die Methode GetAllAsync auf und filtere anshcließend nach der ID. 
            var zuege = await GetAllAsync();
            return zuege.FirstOrDefault(z => z.Id == id);
        }

        public async Task SaveAllAsync(IEnumerable<Zug> zuege)
        {
            // TODO: Implementiere:
            // * ein Lock für File während dem Schreiben, welches gleichzeige Zugriffe verhindert.
            // * Versuche (Try) die Methode WriteToFileAsync aufzurufen.
            // * anschließend gib, egal was passiert (finally), den Lock wieder frei.
            await _fileLock.WaitAsync();
            try { await WriteToFileAsync(zuege); }
            finally { _fileLock.Release(); }
        }

        private async Task<List<Zug>> ReadFromFileAsync()
        {
            // TODO: Implementiere:
            // * Die Deserialisierung der Liste von Zügen, welche aus einem JSON stammt.
            // * Verwende dazu File.ReadAllTextAsync und JsonSerializer.Deserialize.
            if (!File.Exists(_filePath)) return new List<Zug>();
            var json = await File.ReadAllTextAsync(_filePath);
            return string.IsNullOrWhiteSpace(json) ? new List<Zug>() : JsonSerializer.Deserialize<List<Zug>>(json, _options) ?? new List<Zug>();
        }

        private async Task WriteToFileAsync(IEnumerable<Zug> zuege)
        {
            // TODO: Implementiere:
            // * Die Serialisierung der Liste von Reservierungen als JSON, welche als Parameter übergeben wird.
            // * Verwende dazu JsonSerializer.Serialize und File.WriteAllTextAsync.
            var json = JsonSerializer.Serialize(zuege, _options);
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}