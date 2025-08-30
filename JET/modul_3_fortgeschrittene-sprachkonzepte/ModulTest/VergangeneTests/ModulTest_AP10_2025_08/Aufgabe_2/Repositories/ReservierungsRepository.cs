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
        private readonly string _filePath;
        private static readonly SemaphoreSlim _fileLock = new(1, 1);
        private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

        public ReservierungsRepository()
        {
            var dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(dataDirectory);
            _filePath = Path.Combine(dataDirectory, "reservierungen.json");
        }

        public async Task<IEnumerable<Reservierung>> GetAllAsync()
        {
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
            if (!File.Exists(_filePath)) return new List<Reservierung>();
            var json = await File.ReadAllTextAsync(_filePath);
            if (string.IsNullOrWhiteSpace(json)) return new List<Reservierung>();
            return JsonSerializer.Deserialize<List<Reservierung>>(json, _options) ?? new List<Reservierung>();
        }

        private async Task WriteToFileAsync(IEnumerable<Reservierung> reservierungen)
        {
            var json = JsonSerializer.Serialize(reservierungen, _options);
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}