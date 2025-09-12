using System;

namespace Ticketverkauf.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Kunde Kaeufer { get; set; }

        public ITransportmittel GekauftesVerkehrsmittel { get; set; }

        public decimal Preis { get; set; }
        public DateTime Kaufdatum { get; set; } = DateTime.UtcNow;
    }
}