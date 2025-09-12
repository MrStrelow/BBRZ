using System;

namespace Fahrradverleih.Entities
{
    public class Reservierung
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Kunde Kunde { get; set; }
        public Fahrrad Fahrrad { get; set; }
        public DateTime ReservierungsDatum { get; set; }
        public DateTime ErstelltAm { get; set; } = DateTime.UtcNow;
    }
}