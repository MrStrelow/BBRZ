using System;
using System.Collections.Generic;
using System.Text;

namespace ModulTest;

// Achtung! Hinweis für die Zukunft!
// Wir gehen hier nicht auf OOP Design Prinzipien ein (Ersetzbarkeit, Koppelung, Zusammenhalt, etc).
// Auch gehen wir hier nicht Sprachkonstrukte von C# ein wie Non-Nullable Types, Properties, etc. ein.

// Wir wollen uns hier vertraut mit der Schreibweise von Klassen und dessen Hat-Beziehungen machen,
// welche näher an der JAVA-Syntax ist (diese solltet ihr aus dem Grundkurs schon einmal gesehen haben).

public class Student
{
    // Hat-Beziehungen
    Classroom classroom;

    // Konstruktor
    // Wenn ein Lehrer:innen Objekt erstellt wird, bekommt diese einen Klassenraum.
    public Student(Classroom classroom)
    {
        this.classroom = classroom;
    }

    // Methoden
    // Füge den Studenten der Collection im Tisch hinzu. 
    // Wenn der als Argument übergebene Tisch noch nicht dem Klassenraum hinzugefügt wurde, wird dieser hier hinzugefügt. 
    // Hier muss auch die Collection des Lehrers, befüllt werden, damit beide Datenstrukturen den selben Inhalt haben.

    // Bonus: Prüfe ob derselbe Schüler bereits auf einen anderen Tisch sitzt. 
    public void AddStudentToDesk(Desk desk)
    {
        // Bonus
        if (classroom.GetTeacher().GetSutdentLookup().ContainsKey(this))
            throw new ArgumentException($"💥Student is already assigned to the desk: {desk.GetHashCode()}💥.");

        // ohne Bonus
        if (!classroom.GetDesks().Contains(desk))
        {
            classroom.GetDesks().Add(desk);
        }

        desk.AddStudent(this);

        classroom.GetTeacher().PutStudentInLookup(desk, this);
    }
}

public class Desk
{
    // Hat-Beziehungen
    // Verwende eine Datenstruktur (Array, Liste, Dictionary) deiner Wahl.
    private Student[] students = new Student[2];

    // Methoden 
    // Hier soll ein Student der Datenstruktur hinzugefügt werden.
    // Falls kein Platz mehr am Tisch ist, soll diese Zuweisung nicht erfolgreich sein. 
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

        Console.WriteLine($"Oeration had no effect: The desk: {this.GetHashCode()} is already full.");
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
    private Teacher teacher;

    // Konstruktor mit Lehrer als Parameter
    public Classroom(Teacher teacher)
    {
        this.teacher = teacher;
    }

    // Default Konstruktor ohne Parameter
    public Classroom(){}

    // Methoden 
    public List<Desk> GetDesks()
    {
        return desks;
    }

    public Teacher GetTeacher()
    {
        return teacher;
    }

    public void SetTeacher(Teacher teacher)
    {
        this.teacher = teacher;
    }
}

public class Teacher
{
    // Felder
    // Erstelle eine Collection (Array, Liste, Dictionary) deiner Wahl um einen schnellstmöglichen Zugriff
    // auf die Tische eines Schüler zu gewährleisten.
    // (Anders formuliert: Wo muss der Lehrer hinschauen wenn er Schüler x sucht?)
    private Dictionary<Student, Desk> studentDeskLookup = new Dictionary<Student, Desk>();

    // Hat-Beziehungen
    private Classroom classroom;

    // Konstruktor
    // Wenn ein Lehrer:innen Objekt erstellt wird, bekommt diese einen Klassenraum.
    // Hier muss auch die Collection des Lehrers, befüllt werden,
    // damit die Datenstruktur des Lehrers und jene der Classroom den selben Inhalt haben.
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
    // Hier bekommt ein Lehrer eine Schüler:in welche schnellstmöglich gefunden werden muss.
    // Gefunden bedeutet, dass der Tisch der Schüler:in gefunden wird.
    public Desk FindStudentInRoom(Student student)
    {
        if (studentDeskLookup.TryGetValue(student, out Desk desk))
        {
            if (desk is null)
                throw new NullReferenceException($"💥Student: {student} has null desk💥.");

            return desk;
        }
        else
        {
            throw new InvalidOperationException("💥Student not found💥.");
        }
    }

    public void PutStudentInLookup(Desk desk, Student student)
    {
        if (desk is not null && student is not null)
        {
            studentDeskLookup[student] = desk;
        }
    }

    public Dictionary<Student, Desk> GetSutdentLookup()
    {
        return studentDeskLookup;
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

public class Programm
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Erstelle ein School Objekt
        School bbrz = new School();

        // Erstelle zwei Classroom Objekte mit dem Default Konstruktor
        Classroom r510 = new Classroom();
        Classroom r434 = new Classroom(); 

        // Erstelle zwei Lehrer:innen mit dem Konstruktor welcher Klassenräume übernimmt
        Teacher mathias = new Teacher(r510);
        Teacher robert = new Teacher(r434);

        // Setzte gib nun die Klassenräume den Lehrer:innen über eine Set Methode.
        r510.SetTeacher(mathias);
        r434.SetTeacher(robert);

        // Füge die Klassen der Schulde hinzu
        bbrz.AddClassroom(r510);
        bbrz.AddClassroom(r434);

        // Füge 2 Tische der 1. Klasse und 3 Tische der 2. Klasse hinzu
        r510.GetDesks().Add(new Desk());
        r510.GetDesks().Add(new Desk());

        r434.GetDesks().Add(new Desk());
        r434.GetDesks().Add(new Desk());

        // Erstelle drei Schüler:innen für jede der Klassen
        Student hans = new Student(r510);
        Student abdul = new Student(r510);
        Student angela = new Student(r510);

        Student igor = new Student(r434);
        Student lin = new Student(r434);
        Student alexandra = new Student(r434);

        // Setze 3 Schüler:innen auf die Tische in einer Klasse und 2 Schüler:innen auf Tische in der anderen Klasse.
        hans.AddStudentToDesk(r510.GetDesks()[0]);
        abdul.AddStudentToDesk(r510.GetDesks()[0]);
        angela.AddStudentToDesk(r510.GetDesks()[1]);

        igor.AddStudentToDesk(r434.GetDesks()[0]);
        lin.AddStudentToDesk(r434.GetDesks()[1]);

        // Setze den fehlenden Schüler:innen auf einen noch nicht im Klassenzimmer existierenden Tisch.
        alexandra.AddStudentToDesk(new Desk());

        // Einer der Lehrer:innen sucht (auf welchen Tisch soll er/sie schauen?) schnell einen Schüler:innen deiner Wahl.
        // Gib dazu diesen mit dessen Tisch aus. Es reicht das Objekt auf die konsole auszugeben. Es muss kein Menschen lesbarer Text verwendet werden.
        Desk deskOfAbdul = mathias.FindStudentInRoom(abdul);
        Console.WriteLine($"Student1: {hans.GetHashCode()} is sitting at a desk: {deskOfAbdul.GetHashCode()}");
        
        // Gibt alle Schüler:innen inklusive Tisch in der Schule auf die Console aus.
        Console.WriteLine("\nStudents in the classroom:");
        foreach (Classroom classroom in bbrz.GetClassrooms())
        {
            Console.WriteLine($"Classroom: {classroom.GetHashCode()}");
            foreach (Desk desk in classroom.GetDesks())
            {
                foreach (Student student in desk.GetStudents())
                {
                    if (student is not null)
                    {
                        Console.WriteLine($"A student:{student.GetHashCode()} is sitting at a desk: {desk.GetHashCode()}");
                    }
                }
            }

        }

        // Füge eine:n Schüler:in einem freien Tisch in einem Klassenzimmer hinzu. Findet der Lehrer diese:n?
        Student lateStudent = new Student(r510);
        lateStudent.AddStudentToDesk(r510.GetDesks()[1]);

        Desk deskOfLateStudent = mathias.FindStudentInRoom(lateStudent);
        Console.WriteLine($"\nTeacher: {mathias.GetHashCode()} is looking for Late Student: {lateStudent.GetHashCode()}, which is sitting at a desk: {deskOfLateStudent.GetHashCode()}");
        
        // Eine neue Lehrerin bekommt eine bestehende Klasse.
        // Überschreibe dazu den Lehrer in einer bestehenden Klasse mit dem Objekt der neuen Lehrerin.
        // Findet sie die Schüler?
        Teacher monika = new Teacher(r510);

        Desk deskOfAngela = monika.FindStudentInRoom(angela);
        Console.WriteLine($"\nTeacher: {monika.GetHashCode()} is looking for Late Student: {angela.GetHashCode()}, which is sitting at a desk: {deskOfAngela.GetHashCode()}");
        
        // Suche nun mit dem Lehrer der anderen Klasse. Was passiert nun?
        deskOfLateStudent = robert.FindStudentInRoom(lateStudent);
        Console.WriteLine($"\nTeacher: {mathias.GetHashCode()} is looking for Late Student: {lateStudent.GetHashCode()}, which is sitting at a desk: {deskOfLateStudent.GetHashCode()}");   
    }
}