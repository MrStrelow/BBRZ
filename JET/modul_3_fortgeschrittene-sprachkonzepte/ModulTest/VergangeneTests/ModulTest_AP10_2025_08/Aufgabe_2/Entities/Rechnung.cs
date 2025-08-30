using System;
using System.Collections.Generic;

namespace Fahrradverleih.Entities
{
    public class Rechnung
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Kunde Kunde { get; set; }
        public List<Fahrrad> AusgelieheneFahrraeder { get; set; } = new();
        public decimal Gesamtbetrag { get; set; }
        public DateTime Ausleihdatum { get; set; } = DateTime.UtcNow;
    }
}