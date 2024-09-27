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
using L01KapselungZusammenhaltKoppelung;

using static System.Net.Mime.MediaTypeNames;
using static L01KapselungZusammenhaltKoppelung.Nationality;
using static L01KapselungZusammenhaltKoppelung.TennisShoeProperties;
using static L01KapselungZusammenhaltKoppelung.TennisRacketProperties;
using static L01KapselungZusammenhaltKoppelung.FootballShoeProperties;
using static L01KapselungZusammenhaltKoppelung.Quality;
using static L01KapselungZusammenhaltKoppelung.Brand;
using static L01KapselungZusammenhaltKoppelung.SportClub;

namespace L01KapselungZusammenhaltKoppelung;

internal class Program
{
// Für eine Erklärung der Grundlegenden Konzepte, siehe
// "Grundlegende Konzepte der OOP.md" im Ordner "slides_and_book"
    static void Main(string[] args)
    {
        // Unser Ziel ist es einen hohen Klassenzusammenhalt und geringe Koppelung in unserem System zu erreichen.
        // Wir verwendne dazu folgende Werkzeuge:
        // - Architektur Muster: Domain Driven Design (DDD)
        // - Entwurfsmuster: Command, Visitor, Iterator, Decorator, Observer, Strategy, Dependency Injection
        // Auch Konzepte:
        // - Generizität und
        // - Ersetzbarkeit werden wir verwenden.

        // Wir verwenden Domain Driven Design um die modellierung einer Domain durch Objektorientierung
        // in den Mittelpunkt zu stellen.
        // Das kann helfen um sich schnell änderne, komplexe und strukturiere Domänen gut wartbar darstellen zu können.
        // Andere Architekturen, wie MCV oder Layered Architectures beziehen sich oft zuerst auf technsichere Zuständigkeiten,
        // und müssen nichts mit Objektorientierung zu tun haben.
        // Wir sehen aber dass diese sich nicht gegenseitig ausschließen und verwenden
        // z.B. auch in der DDD Layer bzw. leben unsere DDD Klassen in der Model von MCV.

        // Jedoch beginnen wir zuerst ohne die Entwurfsmuster.
        // Wir wollen sehen wie es ohne diese aussieht im Bezug auf Klassenzusammenhalt und Koppelung.

        // Domain Driven Design:
        // Da wir in diesem Projekt viele Klassen besitzen ist oft eine Unterscheidung notwendig
        // welche Domain Experten und Programmierer zusammenbringt. 
        // Wir helfen dabei eine Ordnerstruktor/Namespace in folgende Komponenten zu unterteilen:

        // - Festlegen der Domain:
        //   Wir erstellen Klassen und Interfaces (Athleten, Event, ...) welche uns erleichtern das Problem zu beschreiben
        //   (z.B. UML: Klassendiagramm, Ablaufdiagramm, Use-Casediagramm, ...)
        //   Wir überlegen uns hier bereits wie wir hohen Klassenzusammenhalt und geringe Koppelung durch
        //   Datenabstraktion erreichen.

        //   Wir verwenden beim Festlegen der Domain folgende Bausteine:
        // - Bounded Context:
        //   allgemeine Module der Software, welche mehrere Klassen und Interfaces einbeziehen.
        //   z.B. FanManagement beinhaltet Fan und FanClubs

        // - Objects: 
        //   - Entities: sind Objekte welche Teil der Domain sind und
        //     - identifiziert (hat eine ID, oder eine kombination von Felder ist die ID) sind und einen
        //     - veränderbaren Zustand besitzen.
        //   - Value: sind Objekte welche nicht Teil der Domain sind, aber von Entities verwendet werden.
        //            z.B. Address, Authentication, PersonalInformation

        // - Aggregates:
        //   Sind zusammengefasste Entities in neuen Klassen. z.B. Match


        // 
        // - Repositories: Datenbankanbindung bzw. EF-Core Setup für zu speichernde Domain Objects.

        // - Services: 
        //   - Domain Services:
        //     Bieten Lösungen für Probleme an welche mehrere Entity Objekte beinhalten.
        //     Reduziert die Objektkoppelung nicht, aber legt diese klar offen.z.B. RegistrationService: registriert Athleten für Events und überprüft die Regulatorien.
        //   - Application Services:
        //     Direkte implementierung von Use Cases der Domain Objects.
        //     Beinhaltet Aufrufe an mehrere Domain Services und dessen Auswirkungen auf die Application.
        //     Das ist z.B. wir brauchen zuerst eine sichere Umgebung (Security) um den
        //     Athlete für einen Bewerb registrieren (Domain Service) zu können.
        //     Danach speichern wir die Domain Objects in der Datenbank (Repository)

        // - Layers: 
        //   - Domain Layer: Bounded Context (Module/Ordner) und darin Services, Entities, Aggregates, Repositories
        //   - Application Layer: Use Cases, Data Transfer Objects (DTO) um innerhalb der Layers zu kommunizieren, 
        //   - Infrastructure Layer: Datenbank, Email, Security
        //   - Presentation Layer: Controller der GUI, View (cshtml)
        //     z.B. Innerhalb dieses Layer ist hier der CV teil von MCV. Der M Teil ist in den andern Layern aufgeteilt.

        var dummyBuildingAddress = new BuidldingAddress()
        {
            Street = "who",
            District = "knows",
            Nationality = AUT,
            Number = 0,
            location = (10, 10)
        };

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

        // Hier schauen wir uns die DATENABSTRAKTION an.
        // Das bedeutet, - KAPSELUNG und DATA-HIDING.
        // - DATA-HIDING: wir erlauben so wenig wie möglich Zugriffe der MITGLIEDER von außen.
        // - KAPSELUNG: wir fügen MITGLIEDER so zusammen, dass diese Sinn machen.
        //              Ich KAPLSE so, dass KOPPELUNG niedrig und ZUSAMMENHALT hoch ist


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

        // Im Bezug auf KAPSELUNG sehen wir die relevanten Informationen innerhalb eines Athleten.
        // Wir werden aber sehen, dass wir jedoch komplexere Aktionen in Service Klassen auslagern werden.
        // Zur Zeit betrifft die compete() methode nur zwei Competitors (super-type von Athlete).
        // Wenn wir jedoch komplexeres Verhalten einbauen wollen, was mehr Objekte als Competitor betrifft,
        // (z.B. Regulatorien, Simulation, Wetten, ...) dann werden wir dieses Verhalten in einem Service auslagern.
        // Im Service kann die compete Methode ein Baustein des Services sein. 

        var thiem = new TennisAthlete
        (
            data: new PersonalInformation()
            {
                FirstName = "Dominik",
                LastName = "Thiem",
                Address = dummyAutAddress
            },
            footGear: tennisShoe,
            handGear: tennisRacket,
            id: dummyIdCard
        );

        //thiem.Compete(null);

        var muster = new TennisAthlete
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

        var diem = new TennisAthlete
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

        var kuster = new TennisAthlete
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

        // Frage: warum wird hier ein leerer konstruktor geduldet?
        TrainerExchange worldTrainerExchange = new TrainerExchange(TC_Madrid);

        var trainerAut = new Trainer
        (
            data: new PersonalInformation()
            {
                FirstName = "Treynor",
                LastName = "Kkotsch",
                Address = dummyAutAddress
            },
            currentClub: TC_Wien,
            trainerExchange: worldTrainerExchange,
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
            trainerExchange: worldTrainerExchange,
            id: dummyIdCard
        );

        // ####################### TEAM #######################
        // das kann ein Blödsinn sein. wer steuert mir dass addresse und location zusammenpassen?
        var franceStadium = new Place()
        {
            Address = dummyBuildingAddress,
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

        var austrianTennisTeam = new Team<TennisAthlete>(
            name: "AutTeam",
            trainer: trainerAut,
            transportation: autBus, 
            muster, thiem
        );

        var germanTennisTeam = new Team<TennisAthlete>(
            name: "GerTeam",
            trainer: trainerGer,
            transportation: gerTandem,
            kuster, diem
        );

        // ####################### FANS #######################
        // TODO:

        // ####################### EVENTS #######################
        // TODO: design flaw, date is not a key for a match.
        // location and time is the key.
        var tennisSoloCoupSchedule = new Schedule<TennisAthlete>();
        tennisSoloCoupSchedule.AddMatch(DateTime.Now, new TennisMatch<TennisAthlete>(muster, kuster));
        tennisSoloCoupSchedule.AddMatch(DateTime.Now.AddMinutes(1), new TennisMatch<TennisAthlete>(thiem, diem));

        var tennisSoloCoup = new TennisEvent<TennisAthlete>(tennisSoloCoupSchedule);
        tennisSoloCoup.Start();

        var tennisGroupCoupSchedule = new Schedule<Team<TennisAthlete>>();
        tennisGroupCoupSchedule.AddMatch(DateTime.Now, new TennisMatch<Team<TennisAthlete>>(austrianTennisTeam, germanTennisTeam));

        var tennisGroupCoup = new TennisEvent<Team<TennisAthlete>>(tennisGroupCoupSchedule);
        tennisGroupCoup.Start();

        // Erstelle Sport
        // Erstelle Places
    }
}