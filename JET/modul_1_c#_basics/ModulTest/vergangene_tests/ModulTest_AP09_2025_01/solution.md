```csharp
// Guard Clauses
public void ValidatePilotGuardClause()
{
    // Guards
    if (!IsActive)
        throw new InvalidOperationException("❗Pilot ist nicht aktiv.");

    if (Age <= 18)
        throw new InvalidOperationException("❗Pilot muss älter als 18 Jahre sein.");

    if (string.IsNullOrEmpty(MedicalClearanceCertificate))
        throw new InvalidOperationException("❗Pilot besitzt kein medizinisches Freigabezertifikat.");

    if (LicenseExpiry <= DateTime.Now)
        throw new InvalidOperationException("❗Die Lizenz des Piloten ist abgelaufen.");

    if (Flieger.IstGross && FlightCount < 200)
    {
        throw new InvalidOperationException("❗Pilot hat zu wenig Flüge für ein Großes Flugzeug.");
    }

    // Gute Zustände
    if (Flieger.IstGross) 
    {  
        if (FlightCount >= 200 && FlightCount <= 500)
        {
            Console.WriteLine("✅ Pilot hat zwischen 200 und 500 Flügen. Ein Co-Pilot mit mehr als 500 Flügen ist erforderlich um ein großes Flugzeug fliegen zu können.");
        }
        else if (FlightCount > 500)
        {
            Console.WriteLine("✅ Pilot hat mehr als 500 Flüge. Dieser Pilot darf ein großes Flugzeug fliegen.");
        }
    }
    else
    {
        Console.WriteLine("✅ Pilot darf das Flugzeug fliegen.");
    }
}
```

```csharp
using System;
using System.Collections.Generic;

public class Student
{
    // Hat keine Felder/Eigenschaften und Beziehungen.
}

public class Desk
{
    // Hat-Beziehungen
    // Verwende eine Datenstruktur (Array, Liste, Dictionary) deiner Wahl.
    private Student[] students = new Student[2];

    // Methoden 
    // Hier soll ein Student der Datenstruktur hinzugefügt werden. Falls kein Platz mehr am Tisch ist, soll diese Zuweisung nicht erfolgreich sein. 
    public void AddStudent(Student student)
    {
        for (int i = 0; i < students.Length; i++)
        {
            if (students[i] == null)
            {
                students[i] = student;
                return;
            }
        }
        Console.WriteLine("This desk is already full.");
    }

    public Student[] GetStudents()
    {
        return students;
    }
}

public class Classroom
{
    // Hat-Beziehungen
    // Verwende eine Datenstruktur (Array, Liste, Dictionary) deiner Wahl.
    private List<Desk> desks = new List<Desk>();

    // Methoden 
    // Füge den als Parameter übergebenen Studenten den Parameter Tisch hinzu. 
    // Wenn ein Tisch noch nicht der Klasse hinzugefügt wurde, wird dieser hier hinzugefügt. 
    // Bonus: Prüfe ob ein Schüler schon bereits auf einen anderen Tisch sitzt. 
    public void AddStudentToDesk(Student student, Desk desk)
    {
        if (!desks.Contains(desk))
        {
            desks.Add(desk);
        }
        
        desk.AddStudent(student);
    }

    public List<Desk> GetDesks()
    {
        return desks;
    }
}

public class Teacher
{
    // Felder
    // Erstelle eine Collection (Array, Liste, Dictionary) deiner Wahl um einen schnellstmöglichen Zugriff auf die Tische eines Schüler zu gewährleisten.
    // (Anders formuliert: Wo muss der Lehrer hinschauen wenn er Schüler x sucht?)
    private Dictionary<Student, Desk> studentDeskLookup = new Dictionary<Student, Desk>();

    // Hat-Beziehungen
    private Classroom classroom;

    // Konstruktor
    // Wenn ein Lehrer:innen Objekt erstellt wird, bekommt diese einen Klassenraum.
    // Hier muss auch die Collection welche oben definiert wurde, befüllt werden.
    public Teacher(Classroom classroom)
    {
        this.classroom = classroom;

        foreach (Desk desk in classroom.GetDesks())
        {
            foreach (Student student in desk.GetStudents())
            {
                if (student is not null)
                {
                    studentDeskLookup[student] = desk;
                }
            }
        }
    }

    // Methoden
    // Hier bekommt ein Lehrer eine Schüler:in welche schnellstmöglich gefunden werden muss. Gefunden bedeutet, dass der Tisch der Schüler:in gefunden wird.
    public Desk FindStudentInRoom(Student student)
    {
        if (studentDeskMap.TryGetValue(student, out Desk desk))
        {
            return desk;
        }
        else
        {
            throw new InvalidOperationException("Student not found.");
        }
    }
}

public class School
{
    // Erstelle eine Collection (Array, Liste, Dictionary) deiner Wahl welches Klassen verwaltet.
    private List<Classroom> classrooms = new List<Classroom>();

    // Methode welches ein Hinzufügen von Klassenräumen erlaubt.
    public void AddClassroom(Classroom classroom)
    {
        classrooms.Add(classroom);
    }

    // Methode welches die Klassenräume zurückgibt.
    public List<Classroom> GetClassrooms()
    {
        return classrooms;
    }
}

public class Program
{
    public static void Main()
    {
        // Erstelle ein School Objekt
        School school = new School();

        // Erstelle zwei Classroom Objekte
        Classroom classroom1 = new Classroom();
        Classroom classroom2 = new Classroom();

        // Füge die Klassen der Schulde hinzu
        school.AddClassroom(classroom1);
        school.AddClassroom(classroom2);

        // Füge 2 Tische der 1. Klasse und 3 Tische der 2. Klasse hinzu
        classroom1.GetDesks().Add(new Desk());
        classroom1.GetDesks().Add(new Desk());

        classroom2.GetDesks().Add(new Desk());
        classroom2.GetDesks().Add(new Desk());

        // Erstelle drei Schüler:innen für jede der Klassen
        Student student1 = new Student();
        Student student2 = new Student();
        Student student3 = new Student();

        Student student4 = new Student();
        Student student5 = new Student();
        Student student6 = new Student();

        // Setze 3 Schüler:innen auf die Tische in einer Klasse und 2 Schüler:innen auf Tische in die andere Klasse
        classroom1.AddStudentToDesk(student1, classroom1.GetDesks()[0]);
        classroom1.AddStudentToDesk(student2, classroom1.GetDesks()[0]);
        classroom1.AddStudentToDesk(student3, classroom1.GetDesks()[1]);

        classroom2.AddStudentToDesk(student4, classroom2.GetDesks()[0]);
        classroom2.AddStudentToDesk(student5, classroom2.GetDesks()[1]);

        // Setze den fehlenden Schüler auf eine noch nicht der Klasse hinzugefügten Tisch
        classroom1.AddStudentToDesk(student6, new Desk());

        // Erstelle zwei Lehrer:innen (im Hintergrund - Konstruktor - wird das Dictionary angelegt, was der Klassenzuweisung entspricht)
        Teacher teacher1 = new Teacher(classroom1);
        Teacher teacher2 = new Teacher(classroom2);

        // Einer der Lehrer:innen sucht (auf welchen Desk soll er/sie schauen?) schnell einen Schüler deiner Wahl.
        // Gib dazu diesen mit dessen Tisch aus. Es reicht das Objekt auf die konsole auszugeben. Es muss kein Menschen lesbarer Text verwendet werden.
        Desk deskOfStudent2 = teacher1.FindStudentInRoom(student2);
        Console.WriteLine($"Student1: {student1.GetHashCode()} is sitting at a desk: {deskOfStudent2.GetHashCode()}");
        
        // Gibt alle Schüler inklusive Tisch in der Schule auf die Console aus.
        Console.WriteLine("\nStudents in the classroom:");
        foreach (Classroom classroom in school.GetClassrooms())
        {
            Console.WriteLine($"Classroom: {classroom.GetHashCode()}");
            foreach (Desk desk in classroom.GetDesks())
            {
                foreach (Student student in desk.GetStudents())
                {
                    Console.WriteLine($"A student:{student.GetHashCode()} is sitting at a desk: {desk.GetHashCode()}");
                }
            }

        }
    }
}
```