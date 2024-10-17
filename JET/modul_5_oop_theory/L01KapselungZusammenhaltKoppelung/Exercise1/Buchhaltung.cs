using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    // Buchhaltung mit der Möglichkeit, Konten und Buchungssätze zu verwalten
    public class Buchhaltung
    {
        private List<Konto> konten;

        public Buchhaltung()
        {
            konten = new List<Konto>();
        }

        public void KontoHinzufügen(Konto konto)
        {
            konten.Add(konto);
        }

        public void KontenHinzufügen(List<Konto> konten)
        {
            this.konten.AddRange(konten);
        }

        public void ZeigeKonten()
        {
            Console.WriteLine("Kontenübersicht:");
            foreach (var konto in konten)
            {
                Console.WriteLine(konto);
            }
        }

        public void ZeigeHistorie()
        {
            foreach (var konto in konten)
            {
                konto.ZeigeHistorie();
            }
        }
    }
}
