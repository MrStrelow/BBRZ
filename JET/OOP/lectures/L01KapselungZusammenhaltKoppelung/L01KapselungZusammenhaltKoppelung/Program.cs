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

using static System.Net.Mime.MediaTypeNames;
using static L01KapselungZusammenhaltKoppelung.Nationality;
using static L01KapselungZusammenhaltKoppelung.TennisShoeProperties;
using static L01KapselungZusammenhaltKoppelung.TennisRacketProperties;
using static L01KapselungZusammenhaltKoppelung.FootballShoeProperties;
using static L01KapselungZusammenhaltKoppelung.Quality;
using static L01KapselungZusammenhaltKoppelung.Brand;
using static L01KapselungZusammenhaltKoppelung.Club;

namespace L01KapselungZusammenhaltKoppelung;

internal class Program
{
    // In der Objektorientierten Programmierung (OOP) kommen viele Konzepte und Richtlinien vor,
    // welche einem "überkompliziert" vorkommen können.
    // Jedoch um wirklich die Vorteile von OOP nutzen zu können, müssen wir uns mit
    // diesen Konzepten und Richtlinien beschäftigen. Ansonsten bauen wir Software, welche
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
    // Wenn wir diese Erweiterungen ohne viel nachzudenken einbauen, laufen wir Gefahr all diese VERANTWORTLICHKEITEN
    // den Sportler als METHODEN zu geben. Oft werden wir dann z.B. für den Krankenstand ein FELD in der
    // Klasse Sportler mit Typ List<(DateTime Start, DateTime End)> anlegen um die Historie eines Krankenstandes aufzuzeichnen.
    // Das ist eine Liste von 2er-Tupeln. Ein 2er-Tupel ist eine Liste mit genau 2 Einträgen.
    // Wir bauen uns damit eine große Klasse mit gemischen VERANTWORTLICHKEITEN welche
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
    // - klare KLASSEN-VERANTWORTLICHKEIT, - hoher KLASSEN-ZUSAMMENHALT,
    // - geringe OBJEKT-KOPPELUNG, - DATENABSTRAKTION (KAPSELUNG und DATA-HIDING), um mit 
    // Konzepten wie:
    // - GENERIZITÄT, - ERSETZBARKEIT (Typ Beziehungen)
    // eine gute FAKTORISIERUNG erreichen zu können.

    // Da diese Richtlinien sich manchmal wiedersprechen, führt uns dies zu so Entwurfsmustern (Software Patterns),
    // welche speziell in der OOP Anwendung finden. 
    // Diese sind ebenso Richtlinien um eine gute FAKTORISIERNG erreichen zu können. 
    // Leider ist die Anwendung solcher Muster abhängig vom
    // - zu lösendem Problem, - der Sprache, - und "Mode"
    // Mit "Mode" sind Trends gemeint, welche in Frameworks eingebaut werden, und somit die Entwicklung maßgeblich beeinflussen.
    // Mit der Zeit verändern sich Trends und somit die Frameworks einer Sprache, und damit auch die Verwendung der Sprache selbst.
    // (Sprache: JAVA vs. C#, Framework: Spring vs .NET)

    // Um ein wenig Klarheit zu schaffen, führen wir nun folgende Begriffe:
    // - Objekt und dessen Zustand,
    // - Module: Klassen, Interfaces
    // - Mitglieder einer Klasse (in C#):
    //   - Attribute/Felder, - Eigenschaften, - Konstante, - Methode, - Konstruktoren/Destruktoren

    // und gehen auf Konzepte welche zu einer guten Faktorisierung führen:
    // - Datenabstraktion: Kapselung und Data-Hiding,
    // - Verantwortlichkeiten
    // - Klassen-Zusammenhalt, 
    // - Objekt-Kopplung,
    // - Modulariseriung und Vererbung,
    // - Generizität,
    // - Ersetzbarkeit (Typ Beziehungen)

    // Objekte: 
    // - Kategorisieren von MITGLIEDER zu logischen Einheiten (KAPSELUNG) und
    // - schützen privater MITGLIEDER vor Zugriffen von außen (DATA-HIDING).
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
    //             Eine METHODE ist eine Blackbox in der Variablen hineingegeben, verarbeitet und zurückgegeben werden.
    //             Variablen welche hineingeben werden, werden PARAMETER/ARGUMENTE genannt. 
    //             - merke:
    //               - "was soll mein OBJEKT mit seinem oder anderen FELDERN neues bauen können?"
    //               - Verwende Zeitwörter (Verben) als Namen der Methode.
    //             Es gibt METHODEN welche spezielle Namen und schreibweisen haben. Diese sind:
    //             - Eigenschaften: sind in C# eine spezielle schreibweise, wie der Zugriff auf FELDER gesteuert wird (DATA-HIDING). 
    //             - Konstruktoren/Destruktoren: sind Methoden welche beim erstellen/zerstören eines Objektes ausgefürht wird.
    //                                           Objekte werden erzeugt mit dem "new" Keyword und zerstört, wenn der Gargabe Collector 
    //                                           erkennt dass diese nicht mehr verwendet wird
    //                                           (keine Referenzen zeigen auf den Speicher des Objektes).
    // Eine komplette Liste von C# ist hier https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/members

    // Design von OOP Programmen:
    // Bevor wir uns mit Konzepten auseinander setzten welche zu guter FAKTORISIERUNG führen,
    // ein paar Daumenregeln für die ersten Schritte.
    // - Was wird eine Klasse?
    // - Was wird eine Methode?
    // Wir setzen uns zuerst mit unserer DOMÄNE auseinander und fragen uns was sind die OBJEKTE in dieser.
    // Unter DOMÄNE verstehen wir die Welt und dessen Dinge die wir modellieren wollen.
    // Ein Beispiel ist, die DOMÄNE: der Digitale Klon eines Olympia Events
    // Wir haben also alles relevante zu modellieren um Olympia digitial wiederzuspiegeln.

    // Hier finden wir folgende Aussagen:
    // - Sportler sind teil dieser Welt, 
    // - Sprotler können sich für Wettkämpfe registrieren
    // - Sprotler sind in einer Datebank zu speichern

    // Wir versuchen nun diese Aussagen nach der Art der Wörter zu kategorisieren.
    // Leider ist das nicht immer eindeutig und kann nicht blind gemacht werden (siehe FAKTORISIERUNG).
    // - Nomen werden KLASSEN,
    // - Adjektive werden SCHNITTSTELLEN (Interfaces). (Achtung! das bedeutet nicht dass jedes Interface ein Adjektiv ist.)
    // - Verben werden METHODEN,
    // zudem merken wir uns die BEZIEHUNGEN zwischen den KLASSEN.
    // - Sprotler stehen mit Wettkämpfen in beziehung. Ein Sprotler hat mehrere Wettkämpfe und ein Wettkampf hat mehrere Sprotler.

    // Wie lesen wir nun, "Sprotler sind in einer Datebank zu speichern" und "Sprotler können sich für Wettkämpfe registrieren"
    // KLASSE: Sportler, Wettkampf
    // Scnittstellen: Sprotler sind "speicherbar"
    // Beziehung: Ein Sprotler hat mehrere Wettkämpfe und ein Wettkampf hat mehrere Sprotler.
    //            Die Klasse Sportler hat nun Zugriff auf Wettkampf und umgekehrt, wenn dieser Sprotler bei einem Wettkampf betritt.
    // METHODEN:    sportler.registieren(wettkampf) oder wettkampf.registrieren(sportler)?
    //              Am Beginn hat der Sportler keinen Wettkampf, nach dem Aufruf der registriert Methode erst.
    //              dazu müssen wir mehr über die Anwendung nachdenken. Wer hat die VERANTWORTLICHKEIT über dieses Verhalten?
    //              Der Sportler registriert sich aus Eigeninitiative, scheint also seine Methode zu sein.
    //              Aber die Entscheidung ob ein Sportler:
    //               - aktzeptiert wird, - bereits registriert ist, - gesperrt ist (doping)
    //              liegt eher bei dem Wettkampf. Die Implementierung der "checks" sollte nicht beim Sportler sein (KLASSEN-ZUSAMMENHALT).
    //              Was nun?
    //              wettkampf.registiere(sportler) scheint sinnvoll, aufgrund der checks in der Methode.
    //              Denke an was du in diese Methode schreiben würdest?
    //              Der Wettkampf hat eher Beziehungen zu Dopingstellen und sonstigen Regulatorien, nicht der Sportler.
    //              Ist jedoch die Registrierung wirklich die VERANTWORTLICHKEIT des Wettkampfes? (KLASSEN-ZUSAMMENHALT)
    //              Und zwingen wir Wettkampf und Sportler in eine engere Beziehung als notwendig
    //              durch wettkampf.registiere(sportler)? (OBJEKT-KOPPELUNG)
    //              Die Anwort ist, ja. Der Wettkampf ist zwar konzeptionell näher als der Sprotler an diesen "checks",
    //              hat aber an sich nichts mit diesen zu tun. Eine andere Klasse sollte die die Registrierung vollziehen.
    //              Es sollte beispielsweise ein RegistrationService angeboten werden,
    //              welche in Beziehung mit den Klassen Sportler und Wettkampf steht.
    //              Wir sehen nun dass dieses Entwirren gar nicht so einfach ist, und nicht offensichtlich
    //              warum wir eine solche Trennung brauchen.
    //              Um diese Entscheidungen besser nachvollziehen zu können denken wir an die folgendne Richtlinien und Konzepte der OOP.


    // Faktorisierung:
    // Ist die Zerlegung eines Computer-Programms in Einheiten mit zusammengehörigen Komponenten.
    // Wir haben nun Objekte welche uns erlauben Zustände aus der echtn Welt abzubilden und zu maniplieren.
    // Jedoch wie sollen wir das tun und wie hängen verschiedene Klassen voneinander ab?
    // Es gibt eine Vielzahl von Faktorisierungen eines Problemes und die dadruch entstehenden Vor- und Nachteile.
    // Erfahrung ist dafür nötig und eine gute Faktorisierung kann die Wartbarkeit eines Programms wesentlich erhöhen.
    // Ohne guter Faktorisierung haben wir nur ein kompliziert aufgebautes OOP Programm, ohne wesentliche Vorteile.
    // Um eine gute FAKTORISIERUNG erreichen zu können, verwenden wir die noch zu besprechenden
    // - Richtlinien (DATENABSTRAKTION, VERANTWORTLICHKEITEN, ZUSAMMENHALT, KOPPELUNG) und
    // - Konzepte (ERSETZBARKEIT, GENERIZITÄT).
    // Normalerweise muss die FAKTORISIERUNG einige Male geändert werden; man spricht von REFAKTORISIERUNG.
    // Diese ändert die Struktur eines Programms, lässt aber dessen Funktionalität von diesem unverändert.
    // Wir merken uns:
    // - kein optimales Design im Bezug auf Richtlinien (KOPPELUNG, ...) und Konzepten (ERSETZBARKEIT, ...)
    //   mit dem 1. Versuch möglich. Laufende REFAKTORISIERUNG in Teilen der Software nötig.
    // - Refaktorisieren so früh wie möglich, falls Probleme erkennt werden

    // Klassen-Verantwortlichkeiten
    // Diese können wir durch drei w-Ausdrücke beschreiben:
    // - "was ich weiß": Beschreibung des Zustands der Objekte (FELDER)
    // - "was ich mache": Verhalten der Objekte (meist METHODEN)
    // - "wen ich kenne": sichtbare Objekte, Klassen, etc. (DATENABSTRAKTION, BEZIEHUNGEN)
    // Das "ich" steht dabei jeweils für die Klasse. Wenn etwas geändert werden soll,
    // das in den Verantwortlichkeiten einer Klasse liegt, dann sind dafür die Entwickler:innen dieser Klasse zuständig.

    // Klassen-Zusammenhalt:
    // Ein hoher Klassen-Zusammenhalt wird erzielt, wenn:
    // - die MITGLIEDER einer Klasse "eng" zusammenarbeiten,
    // - durch den NAMEN der Klasse gut beschrieben werden und
    // - eine eindeutige VERANTWORTLICHKEIT diese Klasse innerhalb des Programmes gefunden wird.
    // Enger Zusammenarbeit bedeutet:
    // - Die gesamten Informationen stehen innerhalb eines OBJEKTES mittels FELDER zur Verfügung,
    // - um die dort definierten METHODEN ausführen zu können, ohne auf FELDER anderer OBJEKTE verweisen zu müssen.
    // Ein niedriger KLASSEN-ZUSAMMENHALT besteht, wenn z.B.:
    // - Wir eine Klasse "Trainer" haben, welche die Klassen "Sportler" direkt verwaltet.
    // Direkt verwaltet bedeutet, der Trainer greift auf FELDER der Sportler zu und der Trainer besitzt METHODEN um diese Felder zu manipulieren.
    // Wichtig hier ist diese Manipulation wäre aber VERANTWORTLICHKEIT der Sportler. Ein Beispiel wäre "der Sportler geht zum Training, wärmt sich auf, und trainiert".
    // Diese Methoden sind in der Klasse Sportler zu implementieren, denn diese machen einen Sportler aus.
    // Achtung! Es ist aber durchaus in Ordnung, wenn wenn der Trainer diese Methoden aufruft. 
    // Was trainiert wird, ist VERANTWORTLICHKEIT des Trainers und kann natürlich den Sportler beeinflussen. 
    // Durch klar definierte und in sich geschlossene VERANTWORTLICHKEITEN, wird die Wartbarkeit der Software maßgeblich beeinflusst.
    // Ein Beispiel wäre, wenn der Sportler nicht immer einen Trainer hat, sondern später im Projekt klar wird, dass Sportler
    // selbständig trainieren können. Wenn wir den Trainer mit VERANTWORTLICHKEITEN des Sportler implementiert hätten, wäre das ein Problem, denn
    // nun kann der Sportler selbst nicht diese Aufgaben übernehmen, wenn kein Trainer vorhanden ist.
    // Die Gefahr ist nun, dass schnell mit einem "dirty Fix" der Sportler manche diese VERANTWORTLICHKEITEN bekommt.
    // Nun haben wir doppelt implementiert, und zwei Möglichkeiten über den Trainer und dem Sportler, ähnliche Aktionen ausführen zu können.
    // Diese Doppelgleiseigkeit, macht nun weitere Änderungen schwerer umsetzbar, denn es müssen an 2 Stellen Änderungen vollzogen werden.
    // Wir nehmen hier an, dass der alte Code nicht geändert wird.
    // Zudem ist die Gefahr hoch, Bugs einzubauen.
    // Der Alte Code kann ein anderes Verhalten wie der neue haben und fürht zu komischen, schwer nachvollziebaren Fehlern. 
    // Diese nehmen viel Zeit in Anspruch um behoben zu werden.
    // Wir merken uns:
    // - Der KLASSEN-ZUSAMMENHALT sollte so hoch wie möglich sein.
    // - VERANTWORTLICHKEITEN sind damit klar definiert und Wartung wird einfacher.
    //  Das wird durch gute FAKTORISIERUNG erreicht.

    // Objekt-Kopplung:
    // Wir sehen aber nun, dass die Klasse Trainer und Sportler zusammenhängen.
    // Dieser Zusammenhang, ist beispielsweise, dass die VERANTWORTLICHKEIT des Trainer darin besteht die Sportler so zu trainieren,
    // wie es sich dieser wünscht. 
    // Eine Veränderung oder Entfernung des Trainers, hätte direkte Folgen für den Sportler.
    // Das beschreibt eine KOPPELUNG und diese soll so gering wie möglich sein.
    // KOPPELUNGEN sind unvermeidbar in Systemen welche viele Beziehungen zwischen Klassen haben. 
    // Überlicherweise ist das immer der Fall.
    // Eine KOPPELUNG ist starkt wenn:
    // - viele Methoden und Variablen nach außen sichtbar sind (DATA-HIDING)
    // - im laufenden System Variablenzugriffe (FELDER) zwischen unterschiedlichen Objekten häufig auftreten
    // - und die Anzahl der PARAMETER/ARGUMENTE dieser Methoden groß ist
    // Bei kleinen Systemen, oder Teilen eines Systems, wo erwartet wird, dass diese sich nicht sehr stark ändern
    // ist ein stärkere Koppelung manchmal akzeptabel. Denn eine auflösung von einer Koppelung ist nicht so einfach.
    // Wir werden sehen, für "normale" Systeme reicht es ein Interface ode Abstrakte Klasse zu verwenden.
    // Wenn wir jedoch große, komplexe und wichtige Zusammenhänge in einem System haben, dann sind
    // z.B. Entwurfsmuster zu verwenden welche sich mit KOPPELUNG beschäftigen.
    // Diese haben jedoch einen Preis wie wir später sehen werden. Komplexität.
    // Aus 2 Klassen werden 14 mit kryptischen Begriffen. Es ist abzuschätzen ob ein solcher
    // Implementierungsaufwand sich rentiert.
    // An den Meisten Stellen eher nicht, an sehr speziellen Stellen sehr.
    // Beispiele für Entwurfsmuster sind welche sich mit KOPPELUNG beschäftigen sind:
    // - Command Pattern, oder
    // - Dependency Injection
    //   (welche mit Inversion of Control umgesetzt wird, bedeutet ein Framework kümmert sich drum
    //   z.B. Spring in JAVA oder .NET in C#).
    // Auch Muster auf einer höheren Ebene sind möglich. Damit sind Architektur Muster gemeint.
    // Hier gibt es z.B. Service Architekturen, z.B. die Event Driven Architecture.
    // Auch beschäftigen sich Model View Control (MCV) und die 3-Layer Architektur mit der KOPPELUNG,
    // Diese Architektur Muster versuchen jedoch eher mit VERANTWORTLICHKEITEN und ZUSAMMENHALT.

    static void Main(string[] args)
    {

        var dummyAutAddress = new Address()
        {
            Street = "who",
            District = "knows",
            Entrance = 0,
            Nationality = AUT,
            Number = 0,
            Top = 0
        };

        var dummyGerAddress = new Address()
        {
            Street = "who",
            District = "knows",
            Entrance = 0,
            Nationality = GER,
            Number = 0,
            Top = 0
        };

        var dummyIdCard = new IdCard(id: ":)");

        // Erstelle Team
        // TOOD:
        // erstelle:
        //  - 1 branch welcher die "beste" Lösung hat.
        //  - 1 Branch welcher Fehler aufweist?
        //  - oder mehrere über gewisse themen (hiding, abstraction, koppelung, usw.)

        // TODO: DATA-HIDING - using get/set and Object Initializers
        // vs. constructor and get public properties


        // Hier schauen wir uns die DATENABSTRAKTION an.
        // Das bedeutet, - KAPSELUNG und DATA-HIDING.
        // - DATA-HIDING: wir erlauben so wenig wie möglich Zugriffe der MITGLIEDER von außen.
        // - KAPSELUNG: wir fügen MITGLIEDER so zusammen, dass diese Sinn machen.
        //              Ich KAPLSE so, dass KOPPELUNG niedrig und ZUSAMMENHALT hoch ist

        // ####################### ATHLETES #######################

        var tennisShoe = new TennisShoes() 
        { 
            Brand = Nike,
            ShoeSize = 42,
            Quality = Quality.Medium,
            TennisShoeProperties = Sand
        };

        var tennisRacket = new TennisRacket()
        {
            Brand = Nike,
            Quality = Quality.Medium,
            TennisRacketProperties = TennisRacketProperties.Hard
        };


        // Hier haben wir im Bezug auf DATA-HIDING:
        // - Wir verwenden keinen Konstruktor bei PersonalInformation, nur uneingeschränktes get und set.
        // - Dadurch können NULL Werte entstehen,
        //   wenn ein FELD im "object initialiser" (der { }) vergessen wird.
        // - Warum erlauben wir das hier? Üblicherweise leben PersonalInformation in der Datenbank. 
        //   Da diese Objekte nur NULL sind wenn diese inder Datenbank NULL sind (falls das nicht in der Datenbank verboten ist),
        //   werden diese Objekte einfach von dieser Befüllt und nicht durch uns händeisch, wie hier.
        // - Wir behandeln es also wie ein Data Transfer Object oder Bean (JAVA) welche hier ist
        //   um Daten, ohne Funktionalität (Methoden und Beziehungen) zu halten.
        // - Der Athlet hier, welcher einen konkreten Konstruktor definiert hat,
        //   ist jedoch nicht sonderlich unterschiedlich zur PersonalInformation. Es dient nur zu Demonstationszwecken
        // - Dieser hat einen definierten Konstruktor, denn wir wollen hier genau steuern
        //   welche FELDER bei der initialisierung gesetzt werden.
        //   Dazu nutzen wir die die TYPBEZIEHUNG aus.
        //   Damit ist gemeint, dass wenn Athlete einen konkreten Konstruktor besitzt, TennisAthlete auf diesen
        //   zugreifen kann, um doppelten Code bei der Initialisierungzu vermeiden.
        Athlete thiem = new TennisAthlete
        (
            data: new PersonalInformation() { 
                FirstName = "Dominik", 
                LastName = "Thiem", 
                Address = dummyAutAddress 
            },
            footGear: tennisShoe,
            handGear: tennisRacket,
            id: dummyIdCard
        );

        Athlete muster = new TennisAthlete
        (
            data: new PersonalInformation() { 
                FirstName = "Thomas", 
                LastName = "Muster", 
                Address = dummyAutAddress 
            },
            footGear: tennisShoe,
            handGear: tennisRacket,
            id: dummyIdCard
        );

        Athlete diem = new TennisAthlete
        (
            data: new PersonalInformation()
            {
                FirstName = "Thominik",
                LastName = "Diem",
                Address = dummyGerAddress
            },
            footGear: tennisShoe,
            handGear: tennisRacket,
            id: dummyIdCard
        );

        Athlete kuster = new TennisAthlete
        (
            data: new PersonalInformation()
            {
                FirstName = "Domas",
                LastName = "Kuster",
                Address = dummyGerAddress
            },
            footGear: tennisShoe,
            handGear: tennisRacket,
            id: dummyIdCard
        );

        // ####################### COACHES #######################

        // warum wird hier ein leerer konstruktor geduldet?
        ClubExchange worldTrainerExchange = new ClubExchange(TC_Madrid);

        var trainerAut = new Trainer
        (
            data: new PersonalInformation()
            {
                FirstName = "Treynor",
                LastName = "kKotsch",
                Address = dummyAutAddress
            },
            currentClub: TC_Wien,
            clubExchange: worldTrainerExchange,
            id: dummyIdCard
        );

        var trainerGer = new Trainer
        (
            data: new PersonalInformation()
            {
                FirstName = "Tener",
                LastName = "Kotsch",
                Address = dummyGerAddress
            },
            currentClub: TC_Berlin,
            clubExchange: worldTrainerExchange,
            id: dummyIdCard
        );

        // ####################### TEAM #######################
        // das kann ein Blödsinn sein. wer steuert mir dass addresse und location zusammenpassen?
        var franceStadium = new Place()
        {
            Address = dummyGerAddress,
            location = (10,10)
        };

        var busNavi = new GpsNavi();
        var humanNavi = new HumanNavi(trainerGer);

        var autBus = new Bus
        (
            capacity: 56,
            currentLocation: franceStadium,
            dimension: (hoehe: 4, breite:3, laenge:13),
            navi: busNavi,
            costToOperatePerHour: 10,
            fuelConsumptionPer100km: 10
        );
        
        var gerTandem = new Tandem
        (
            capacity: 56,
            currentLocation: franceStadium,
            dimension: (hoehe: 4, breite: 3, laenge: 13),
            navi: busNavi
        );

        var austrianTennisTeam = new Team(trainer: trainerAut, transportation: autBus, muster, thiem);
        var germanTennisTeam = new Team(trainer: trainerGer, gerTandem, kuster, diem);

        // ####################### FANS #######################

        // Erstelle Event
        // Erstelle Sport
        // Erstelle Places
    }
}
