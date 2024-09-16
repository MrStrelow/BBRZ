using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace L01KapselungZusammenhaltKoppelung
{
    internal class Program
    {
        // In der Objektorientierten Programmierung (OOP) kommen viele Konzepte und Begriffe vor,
        // welche eiem zuerst "überkompliziert" vorkommen können.
        // Jedoch um wirklich die Vorteile von OOP nutzen zu können, müssen wir uns mit
        // diesen Konzepten beschäftigen. Ansonsten bauen wir Software, welche
        // - den komplexen Aufbau von OOP mit sich bringt, jedoch
        // - die Vorteile von OOP nicht nutzen.
        // Das sollte natürich vermieden werden.

        // Vorab, OOP ist nicht der einzige Weg Software zu entwickeln.
        // Die Probleme welche wir damit lösen wollen müssen zu der Idee von OOP passen.
        // Mehr dazu in den Folien/Skrip.

        // Motivation der OOP:
        // Bevor wir uns mit Begriffen und Konzepten auseinandersetzen beschreiben kurz eine Frage welche oft entsteht.
        // "Wann schreibe ich eine neue Methode und wann erstelle ich eine neue Klasse?"
        // Oft sind wir verleitet wenn wir eine Klasse haben (z.B. Sportler) diese immer weiter und weiter mit METHODEN auszubauen.
        // Beispielsweise wollen wir eine Klasse Sportler:
        // - trainieren lassen, - einen Vertrag unterschreiben, - Krankenstand/Urlaub anmelden,
        // - Trainingseinheiten planen, - Klub wechseln, usw.
        // Wenn wir diese Erweiterungen ohne viel nachzudenken einbauen, laufen wir Gefahr all diese Zuständigkeiten
        // den Sportler als METHODEN zu geben. Oft werden wir dann z.B. für den Krankenstand ein FELD in der
        // Klasse Sportler mit Typ List<(DateTime Start, DateTime End)> anlegen um die Historie eines Krankenstandes aufzuzeichnen.
        // Das ist eine Liste von 2er-Tupeln. Ein 2er-Tupel ist eine Liste mit genau 2 Einträgen.
        // Wir bauen uns damit eine große Klasse mit gemischen Zuständigkeiten welche
        // eigentlich ein prozeduraler Programmierstil ist. Wir kombinieren also die langwierige
        // ausdrucksweise der OOP und missbrauchen es als unübersichtliches prozedurales Programm.
        // Das Schlechte aus beiden Welten.
        // Wenn unser Ziel ist ein langlebiges, gut wartbares Programm schreiben zu wollen, sehen wir folgende Problemen mit diesen Ansatz.
        // Hohe Wartbarkeit bedeuetet Änderungen im Programm vornehmen zu können,
        // ohne im gesamten Programm Fehler entstehen zu lassen und Anpassungen vollzogen werden müssen.
        // Eine Änderung hier ist beispielsweise, dass ein Sportler nun unterscheiden muss zwischen
        // leichtem Krankenstand und schweren Krankenstand.
        // Diese Änderung bedeutet, dass die Datenstruktur angepasst werden muss.
        // Diese kann nun ein 2er-Tuple sein ( List<(DateTime Start, DateTime End)>, List<(DateTime Start, DateTime End)> ),
        // oder einfach zwei getrennte listen.
        // Diese Änderungen haben zur folge, dass bereits geschriebener Code überall angepasst werden muss.
        // Verzweigungen müssen eingeführt werden, das hinzufügen der Tuple/Listen müssen geändert werden, usw.
        // Bei großen Programmen, mit Teams von hundert Programmier:innen ist ein solchers vorhergehen katastrophal,
        // denn diese Änderung führt zu Fehlern in Programmen, welche nicht von einem selbst geschrieben wurden.

        // Wir brauchen also Richtlinien welche uns beim Design von Klassen helfen sollen um z.B. gute Wartbarkeit sicherzustellen.
        // Diese Richtlinien sind:
        // - hoher KLASSEN-ZUSAMMENHALT, geringe OBJEKT-KOPPELUNG, DATENABSTRAKTION (KAPSELUNG und DATA-HIDING), um damit 
        // - eine gute FAKTORISIERUNG erreichen zu können.

        // Da diese Richtlinien sich manchmal wiedersprechen, führt uns dies zu so Entwicklungs Mustern (Software Patterns),
        // welche speziell in der OOP Anwendung finden. 
        // Diese sind ebenso Richtlinien um eine gute FAKTORISIERNG erreichen zu können. 
        // Leider ist die Anwendung solcher Muster abhängig vom
        // - zu lösendem Problem, - der Sprache, - und "Mode"
        // Mit "Mode" sind Trends gemeint, welche in Frameworks eingebaut werden, und somit die Entwicklung maßgeblich beeinflussen.
        // Mit der Zeit verändern sich Trends und somit die Frameworks einer Sprache, und damit auch die Verwendung der Sprache selbst.
        // (Sprache: JAVA vs. C#, Framework: Spring vs .NET)

        // Um ein wenig Klarheit zu schaffen, führen wir nun folgende Begriffe:
        // - Objekt und dessen Zustand,
        // - Klasse,
        // - Mitglieder einer Klasse (in C#):
        //   - Attribute/Felder, - Eigenschaften, - Konstante, - Methode, - Konstruktoren/Destruktoren
        // - Datenabstraktion: Kapselung und Data-Hiding,
        // - Klassen-Zusammenhalt, 
        // - Objekt-Kopplung,
        // - Faktorisierung,

        // - Modulariseriung,
        // - Vererbung,
        // - Generizität,
        // - Ersetzbarkeit (Typ Beziehungen)

        // Objekte: 
        // - kapseln Variablen und Methoden zu logischen Einheiten (KAPSELUNG) und
        // - schützen private Inhalte vor Zugriffen von außen (DATA-HIDING).
        // Zusammen wird dies DATENABSTRAKTION genannt und erlaubt das Objekt die Einheit zu sein,
        // um Verhalten unserer Software abzubilden.

        // Klasse:
        // Eine Klasse wird häufig als Schablone für die Erzeugung neuer OBJEKTE beschrieben. 
        // Wir vernachlässigen Details und merken uns:
        // - Was früher sprachlich der "Typ einer Variable" war, ist vergleichbar mit die "Klasse eines Objektes".

        // Polymorphismus:
        // Das bedeutet grob, "variablen können mehrere Typen haben".
        // Um dies umsetzen zu können brauchen wir eine Stelle and der wir diese Vielfalt
        // zum Ausdruck bringen können. Diese ist die KLASSE.
        // Wir merken uns, eine KLASSE ist definiert durch
        // - einen NAMEN (der dadurch erzeugte Typ, nicht ein Feld was "name" heißt!),
        // - dessen MITGLIEDER

        // MITGLIEDER einer Klasse:
        // Diese sind
        // - Felder (oder Attribute): bestehen aus Variablen. Diese sind entwerder
        //                            - primitive Variablen (int, flaot, ...) oder
        //                            - objekte (aus eigens geschriebenen oder vordefinierten KLASSEN abgeleitet)
        //                            Die FELDER stellen den Zustand eines OBJEKTES dar. 
        //                            - merke:
        //                              - "was macht mein OBJEKT aus? Was soll es sich merken?". 
        //                              - Verwende Hauptwörter (Nomen) dafür.
        //                            Zudem können Beziehungen abgebildet werden. Diese sind Teil des Zustandes,
        //                            werden aber speziell hervorgehoben im Bezug auf die OBJEKT-KOPPELUNG. Dazu später.
        //                            (Ein Haus hat Zimmer -> Klasse Haus hat Feld von Typ Liste<Zimmer>).
        // - Methoden: verändern den Zustand eines OBJEKTES.
        //             - merke:
        //               - "was soll mein OBJEKT an sich oder anderen ändern können?"
        //                Verwende Zeitwörter (Verben) dafür
        //             Es gibt METHODEN welche spezielle Namen und schreibweisen haben. Diese sind:
        //             - Eigenschaften: sind in C# eine spezielle schreibweise, wie der Zugriff auf FELDER gesteuert wird (DATA-HIDING). 
        //             - Konstruktoren/Destruktoren: sind Methoden welche beim erstellen/zerstören eines Objektes ausgefürht wird.
        //                                           Objekte werden erzeugt mit dem "new" Keyword und zerstört, wenn der Gargabe Collector 
        //                                           erkennt dass diese nicht mehr verwendet wird
        //                                           (keine Referenzen zeigen auf den Speicher des Objektes).
        // Eine komplette Liste von C# ist hier https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/members


        // Klassen-Zusammenhalt:
        // Ein hoher Klassen-Zusammenhalt wird erzielt, wenn:
        // - die MITGLIEDER einer Klasse "eng" zusammenarbeiten,
        // - durch den NAMEN der Klasse gut beschrieben werden und
        // - eine eindeutige Zuständigkeit diese Klasse, innerhalb des Programmes gefunden wird.
        // Enge Zusammenarbeit bedeutet:
        // - Die gesamten Informationen stehen innerhalb eines OBJEKTES mittels FELDER zur verfügung,
        // - um die dort definierten METHODEN ausführen zu können, ohne auf andere OBJEKTE verweisen zu müssen.
        // eindeutige Zuständigkeit bedeutet:
        // - Das programmierte Verhalten des OBJEKTES ist NUR mit dessen Methoden manipulierbar.
        // Ein niedriger KlassenZusammenhalt besteht, wenn z.B.:
        // - Wir eine Klasse "Trainer" haben, welche die Klassen "Tournier" und "Spieler" direkt verwaltet.
        // Direkt verwaltet bedeutet, der Trainer greift auf FELDER der Spieler zu und der Trainer besitzt METHODEN um diese Felder zu manipulieren.
        // Wichtig hier ist diese Manipulation wäre aber Zuständigkeit der Spieler. Ein Beispiel wäre "der Spieler geht zum Training, wärmt sich auf, und trainiert".
        // Diese Methoden sind in der Klasse Spieler zu implementieren, denn diese machen einen Spieler aus.
        // Achtung! Es ist aber durchaus in Ordnung, wenn wenn der Trainer diese Methoden aufruft. 
        // Was trainiert wird, ist Zuständigkeit des Trainers und kann natürlich den Spieler beeinflussen. 
        // Durch klar definierte und in sich geschlossene Zuständigkeiten, wird die Wartbarkeit der Software maßgeblich beeinflusst.
        // Ein Beispiel wäre, wenn der Spieler nicht immer einen Trainer hat, sondern später im Projekt klar wird, dass Spieler
        // selbständig trainieren können. Wenn wir den Trainer mit Zuständigkeiten des Spieler implementiert hätten, wäre das ein Problem, denn
        // nun kann der Spieler selbst nicht diese Aufgaben übernehmen, wenn kein Trainer vorhanden ist.
        // Die Gefahr ist nun, dass schnell mit einem "dirty Fix" der Spieler manche diese Zuständigkeiten bekommt.
        // Nun haben wir doppelt implementiert, und zwei Möglichkeiten über den Trainer und dem Spieler, ähnliche Aktionen ausführen zu können.
        // Diese Doppelgleiseigkeit, macht nun weitere Änderungen schwerer umsetzbar, denn es müssen an 2 Stellen Änderungen vollzogen werden.
        // Wir nehmen hier an, dass der alte Code nicht geändert wird.
        // Zudem ist die Gefahr hoch, Bugs einzubauen.
        // Der Alte Code kann ein anderes Verhalten wie der neue haben und fürht zu komischen, schwer nachvollziebaren Fehlern. 
        // Diese nehmen viel Zeit in Anspruch um behoben zu werden.

        // Wir merken uns:
        // - Der KLASSEN-ZUSAMMENHALT sollte so hoch wie möglich sein.
        // - Zuständigkeiten sind damit klar definiert und Wartung wird einfacher.
        //  Das wird durch gute FAKTORISIERUNG erreicht.

        // Objekt-Kopplung:
        // Wir sehen aber nun, dass die Klasse Trainer und Spieler zusammenhängen.
        // Dieser Zusammenhang, ist beispielsweise, dass die Zuständigkeit des Trainer darin besteht die Spieler so zu trainieren,
        // wie es sich dieser wünscht. 
        // Das beschreibt eine KOPPELUNG und diese soll so gering wie möglich sein.

        // Faktorisierung:
        // Ist die Zerlegung eines Computer-Programms in Einheiten mit zusammengehörigen Komponenten.
        // Wir haben nun Objekte welche uns erlauben Zustände aus der echtn Welt abzubilden und zu maniplieren.
        // Jedoch wie sollen wir das tun und wie hängen verschiedene Klassen voneinander ab?
        // Es gibt eine Vielzahl von Faktorisierungen eines Problemes und die dadruch entstehenden Vor- und Nachteile.
        // Erfahrung ist dafür nötig und eine gute Faktorisierung kann die Wartbarkeit eines Programms wesentlich erhöhen.
        // Ohne guter Faktorisierung haben wir nur ein kompliziert aufgebautes OOP Programm, ohne wesentliche Vorteile.
        //  Beispiel:


        // TODO: Wann verwende ich methoden? Wann Klassen?

        static void Main(string[] args)
        {
        }
    }
}
