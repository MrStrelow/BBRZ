using Fahrradverleih.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Fahrradverleih.Repositories
{
    public interface IReservierungsRepository
    {
        Task<IEnumerable<Reservierung>> GetAllAsync();
        Task AddAsync(Reservierung reservierung);
    }

    public class ReservierungsRepository : IReservierungsRepository
    {
        // TODO: Erstelle die benötigten Felder und Eigenschaften.
        private readonly string _filePath;
        private static readonly SemaphoreSlim _fileLock = new(1, 1);
        private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

        // TODO: Implementiere den Konstruktor.
        public ReservierungsRepository()
        {
            var dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(dataDirectory);
            _filePath = Path.Combine(dataDirectory, "reservierungen.json");
        }

        public async Task<IEnumerable<Reservierung>> GetAllAsync()
        {
            // TODO: Implementiere:
            // * ein Lock für File während dem Lesen, welches gleichzeige Zugriffe verhindert.
            // * Versuche (Try) die Methode ReadFromFileAsync aufzurufen und gib anschließen, egal was passiert (finally), den Lock wieder frei.
            await _fileLock.WaitAsync();
            try
            {
                return await ReadFromFileAsync();
            }
            finally
            {
                _fileLock.Release();
            }
        }

        public async Task AddAsync(Reservierung reservierung)
        {
            // TODO: Implementiere:
            // * ein Lock für File während dem Schreiben, welches gleichzeige Zugriffe verhindert.
            // * Versuche (Try) die Methode
            //      * ReadFromFileAsync aufzurufen, speicher das Ergebnis und fürge den Parameter reservierung hinzu,
            //      * danach rufe WriteToFileAsync auf.
            // * anschließend gib, egal was passiert (finally), den Lock wieder frei.
            await _fileLock.WaitAsync();
            try
            {
                var items = (await ReadFromFileAsync()).ToList();
                items.Add(reservierung);
                await WriteToFileAsync(items);
            }
            finally
            {
                _fileLock.Release();
            }
        }

        private async Task<List<Reservierung>> ReadFromFileAsync()
        {
            // TODO: Implementiere:
            // * Die Deserialisierung der Liste von Reservierungen, welche aus einem JSON stammt.
            // * Verwende dazu File.ReadAllTextAsync und JsonSerializer.Deserialize.
            if (!File.Exists(_filePath)) return new List<Reservierung>();
            var json = await File.ReadAllTextAsync(_filePath);
            if (string.IsNullOrWhiteSpace(json)) return new List<Reservierung>();
            return JsonSerializer.Deserialize<List<Reservierung>>(json, _options) ?? new List<Reservierung>();
        }

        private async Task WriteToFileAsync(IEnumerable<Reservierung> reservierungen)
        {
            // TODO: Implementiere:
            // * Die Serialisierung der Liste von Reservierungen als JSON, welche als Parameter übergeben wird.
            // * Verwende dazu JsonSerializer.Serialize und File.WriteAllTextAsync.
            var json = JsonSerializer.Serialize(reservierungen, _options);
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}