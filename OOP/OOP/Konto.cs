using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public abstract class Konto
    {
        public string Bezeichnung { get; }
        protected List<Fluss> Soll { get; }
        protected List<Fluss> Haben { get; }

        protected Konto(string bezeichnung)
        {
            Bezeichnung = bezeichnung;
            Soll = new List<Fluss>();
            Haben = new List<Fluss>();
        }

        public abstract void Buchen(Zugang zugang);
        public abstract void Buchen(Abgang abgang);

        public decimal BerechneSaldo()
        {
            decimal sollSumme = 0;
            foreach (var fluss in Soll)
            {
                sollSumme += fluss.Betrag;
            }

            decimal habenSumme = 0;
            foreach (var fluss in Haben)
            {
                habenSumme += fluss.Betrag;
            }

            return sollSumme - habenSumme;
        }

        // Zeigt die Historie der Buchungen an
        public void ZeigeHistorie()
        {
            Console.WriteLine($"Buchungshistorie für {Bezeichnung}:");

            Console.WriteLine("Soll-Buchungen:");
            foreach (var zugang in Soll)
            {
                Console.WriteLine(zugang);
            }

            Console.WriteLine("Haben-Buchungen:");
            foreach (var abgang in Haben)
            {
                Console.WriteLine(abgang);
            }

            Console.WriteLine($"Aktueller Saldo: {BerechneSaldo():C}");
        }

        public override string ToString()
        {
            return $"{Bezeichnung} - Saldo: {BerechneSaldo():C}";
        }
    }
}
