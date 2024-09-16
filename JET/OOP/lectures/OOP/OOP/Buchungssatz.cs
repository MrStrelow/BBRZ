using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Buchungssatz
    {
        private readonly Konto soll;
        private readonly Konto haben;
        private readonly decimal betrag;

        public Buchungssatz(Konto soll, Konto haben, decimal betrag)
        {
            this.soll = soll;
            this.haben = haben;
            this.betrag = betrag;
        }

        public void Buchen()
        {
            if (betrag > 0)
            {
                ZugangBuchen();
            }
            else
            {
                AbgangBuchen();
            }
        }

        private void AbgangBuchen()
        {
            soll.Buchen(new Abgang(betrag));
            haben.Buchen(new Zugang(betrag));

            Console.WriteLine($"Buchungssatz: {betrag:C} von {soll.Bezeichnung} nach {haben.Bezeichnung}");
        }

        private void ZugangBuchen()
        {
            soll.Buchen(new Zugang(betrag));
            haben.Buchen(new Abgang(betrag));

            Console.WriteLine($"Buchungssatz: {betrag:C} von {haben.Bezeichnung} nach {soll.Bezeichnung}");
        }

    }

}
