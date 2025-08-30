using Fahrradverleih.Entities;
using Fahrradverleih.Exceptions;
using Fahrradverleih.Repositories;
using Serilog;
using System.Threading.Tasks;

namespace Fahrradverleih.Services;

public interface IFahrradService
{
    Task<Fahrrad> BereitstellenAsync(int fahrradId);
}

public class FahrradService : IFahrradService
{
    private readonly IFahrradRepository _fahrradRepository;

    public FahrradService(IFahrradRepository fahrradRepository)
    {
        _fahrradRepository = fahrradRepository;
    }

    public async Task<Fahrrad> BereitstellenAsync(int fahrradId)
    {
        var fahrrad = await _fahrradRepository.GetByIdAsync(fahrradId)
            ?? throw new FahrradNichtVerfuegbarException($"Fahrrad mit ID {fahrradId} konnte nicht gefunden werden.");

        Log.ForContext<FahrradService>().Information("Fahrrad wird bereitgestellt: {FahrradModell}", fahrrad.Modell);

        await Task.Delay(50); // Simuliert die Bereitstellungszeit

        Log.Information("Fahrrad '{FahrradModell}' ist bereit.", fahrrad.Modell);
        return fahrrad;
    }
}