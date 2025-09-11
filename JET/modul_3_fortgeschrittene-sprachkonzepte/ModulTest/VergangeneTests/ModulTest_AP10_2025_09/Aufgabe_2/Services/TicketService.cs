using System;
using System.Threading.Tasks;
using Ticketverkauf.DTOs;
using Ticketverkauf.Entities;
using Ticketverkauf.Services;

namespace Ticketverkauf.Services
{
    public interface ITicketService
    {
        Task<Ticket> KaufeTicketAsync(TicketKaufWunschDto wunsch);
    }

    public class TicketService : ITicketService
    {
        private readonly IBusService _busService;
        private readonly IZugService _zugService;

        public TicketService(IBusService busService, IZugService zugService)
        {
            _busService = busService;
            _zugService = zugService;
        }

        public async Task<Ticket> KaufeTicketAsync(TicketKaufWunschDto wunsch)
        {
            switch (wunsch.Typ)
            {
                case VerkehrsmittelTyp.Bus:
                    return await _busService.KaufeBusTicketAsync(wunsch);
                case VerkehrsmittelTyp.Zug:
                    return await _zugService.KaufeZugTicketAsync(wunsch);
                default:
                    throw new NotSupportedException("Dieser Verkehrsmitteltyp wird nicht unterstützt.");
            }
        }
    }
}