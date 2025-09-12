using Fahrradverleih.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Fahrradverleih.Repositories
{
    public interface IFahrradRepository
    {
        Task<IEnumerable<Fahrrad>> GetAllAsync();
        Task<Fahrrad?> GetByIdAsync(int id);
        Task SaveAllAsync(IEnumerable<Fahrrad> fahrraeder);
    }

    public class FahrradRepository : IFahrradRepository
    {
        private readonly string _filePath;
        private static readonly SemaphoreSlim _fileLock = new(1, 1);
        private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

        public FahrradRepository()
        {
            var dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(dataDirectory);
            _filePath = Path.Combine(dataDirectory, "fahrraeder.json");
        }

        public async Task<IEnumerable<Fahrrad>> GetAllAsync()
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

        public async Task<Fahrrad?> GetByIdAsync(int id)
        {
            var fahrraeder = await GetAllAsync();
            return fahrraeder.FirstOrDefault(f => f.Id == id);
        }

        public async Task SaveAllAsync(IEnumerable<Fahrrad> fahrraeder)
        {
            await _fileLock.WaitAsync();
            try
            {
                await WriteToFileAsync(fahrraeder);
            }
            finally
            {
                _fileLock.Release();
            }
        }

        private async Task<List<Fahrrad>> ReadFromFileAsync()
        {
            if (!File.Exists(_filePath)) return new List<Fahrrad>();
            var json = await File.ReadAllTextAsync(_filePath);
            if (string.IsNullOrWhiteSpace(json)) return new List<Fahrrad>();
            return JsonSerializer.Deserialize<List<Fahrrad>>(json, _options) ?? new List<Fahrrad>();
        }

        private async Task WriteToFileAsync(IEnumerable<Fahrrad> fahrraeder)
        {
            var json = JsonSerializer.Serialize(fahrraeder, _options);
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}