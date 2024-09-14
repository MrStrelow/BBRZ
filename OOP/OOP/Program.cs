using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var buchhaltung = new Buchhaltung();

            // Bestandskonten (Bilanz)
            // aktiv
            var maschinen = new Aktivkonto("machinen-0210");
            var kasse = new Aktivkonto("kasse-1000");
            var bank = new Aktivkonto("bank-F1200");

            // passiv
            var verbindlichkeiten = new Passivkonto("verbindlichkeiten-S1600");


            // der Buchhaltung hinzufügen
            buchhaltung.KontenHinzufügen(new List<Konto>() 
            {
                maschinen, kasse, bank,
                verbindlichkeiten
            });

            // Beispielbuchungen
            // die Buchung ist immer "Soll an Haben"
            // deshalb ist das erste Argument das "Soll"-Konto und das 2. das "Haben"-Konten

            // Kauf mit Geld was ich habe
            // Aktivtausch
            var kaufEinerDrehmaschine = new Buchungssatz(maschinen, kasse, 1000);
            var verkaufEinerDrehmaschine = new Buchungssatz(kasse, maschinen, 2000);

            // Kauf mit Geld was ich nicht habe (Verbindlichkeit)
            // Bilanzverlängerung (= Aktiv - Passivmehrung)
            var kaufAufSchuldenEinerDrehmaschine = new Buchungssatz(maschinen, verbindlichkeiten, 100);
            var kaufAufSchuldenEinerFraesmaschine = new Buchungssatz(maschinen, verbindlichkeiten, 200);


            // Tilgung von Schulden
            // Aktiv - Passivminderung(= Bilanzverkürzung)
            var tilgungDerSchulden = new Buchungssatz(verbindlichkeiten, bank, 300);


            // Liste aller zu verbuchender Buchungen
            List<Buchungssatz> buchungen = new List<Buchungssatz>() 
            {
                kaufEinerDrehmaschine,
                verkaufEinerDrehmaschine,
                kaufAufSchuldenEinerDrehmaschine,
                kaufAufSchuldenEinerFraesmaschine,
                tilgungDerSchulden
            };

            buchungen.ForEach(buchung => buchung.Buchen());

            // Kontenübersicht anzeigen
            buchhaltung.ZeigeKonten();

            // Buchungshistorie für jedes Konto anzeigen
            buchhaltung.ZeigeHistorie();


            // TODO: Beispiel falsches beispiel aufbauen und dann korrekter darstellen.
            // TODO: Bausteine besprechen
            //      - interfaces, classes, abstract classes
            //      - virtual, static, override
            // TODO: Kapselung, Koppelung und Zusammenhalt
            // TODO: Vererbung vs. Untertyp Beziehung
            // TODO: überschreiben vs. überladen
        }
    }
}
