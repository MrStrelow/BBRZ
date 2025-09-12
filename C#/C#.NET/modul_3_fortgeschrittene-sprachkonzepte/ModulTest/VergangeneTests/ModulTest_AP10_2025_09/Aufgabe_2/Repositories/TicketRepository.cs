using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Ticketverkauf.Entities;

namespace Ticketverkauf.Repositories;

public interface ITicketRepository
{
    Task<IEnumerable<Ticket>> GetAllAsync();
    Task AddAsync(Ticket ticket);
}

public class TicketRepository : ITicketRepository
{
    private readonly string _filePath;
    private static readonly SemaphoreSlim _fileLock = new(1, 1);
    private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

    public TicketRepository()
    {
        var dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        Directory.CreateDirectory(dataDirectory);
        _filePath = Path.Combine(dataDirectory, "tickets.json");
    }

    public async Task<IEnumerable<Ticket>> GetAllAsync()
    {
        await _fileLock.WaitAsync();
        try { return await ReadFromFileAsync(); }
        finally { _fileLock.Release(); }
    }

    public async Task AddAsync(Ticket ticket)
    {
        await _fileLock.WaitAsync();
        try
        {
            var tickets = (await ReadFromFileAsync()).ToList();
            tickets.Add(ticket);
            await WriteToFileAsync(tickets);
        }
        finally { _fileLock.Release(); }
    }

    private async Task<List<Ticket>> ReadFromFileAsync()
    {
        if (!File.Exists(_filePath)) return new List<Ticket>();
        var json = await File.ReadAllTextAsync(_filePath);
        return string.IsNullOrWhiteSpace(json) ? new List<Ticket>() : JsonSerializer.Deserialize<List<Ticket>>(json, _options) ?? new List<Ticket>();
    }

    private async Task WriteToFileAsync(IEnumerable<Ticket> tickets)
    {
        var json = JsonSerializer.Serialize(tickets, _options);
        await File.WriteAllTextAsync(_filePath, json);
    }
}