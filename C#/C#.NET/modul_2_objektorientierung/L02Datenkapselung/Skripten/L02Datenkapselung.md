# Datenabstraktion: Kapselung und Data-Hiding

In der objektorientierten Programmierung ist die Datenabstraktion ein fundamentales Prinzip. Sie erlaubt es uns, komplexe Systeme zu bauen, indem wir Details verbergen und nur die wesentlichen Informationen nach außen sichtbar machen. Wir verstehen diesen Überbegriff als eine Kombination aus zwei Kernkonzepten: **Kapselung** und **Data-Hiding**.

Anhand des `Hamster`-Beispiels werden wir diese Konzepte untersuchen und den Unterschied zwischen einem problematischen "View-Driven"-Ansatz und einem robusten "State-Driven"-Ansatz beleuchten.

---

## 1. Data-Hiding (Geheimnisprinzip)

Data-Hiding ist der Mechanismus, mit dem wir den internen Zustand eines Objekts vor unkontrolliertem Zugriff von außen schützen. In C# wird dies durch **Zugriffsmodifizierer (Access Modifiers)** erreicht. Das Ziel ist es, eine klare Trennung zwischen der "öffentlichen Schnittstelle" und der "privaten Implementierung" zu schaffen.

### Zugriffsmodifizierer

* `public`: Die Variable oder Methode ist von überall aus sichtbar und zugänglich. Dies ist Teil der öffentlichen Schnittstelle.
* `private`: Die Variable oder Methode ist **nur innerhalb der eigenen Klasse** sichtbar. Dies ist der strengste Schutz und sollte der Standard für interne Zustandsdaten (Felder) sein.
* `protected`: Die Variable oder Methode ist innerhalb der eigenen Klasse und in allen davon abgeleiteten (erbenden) Klassen sichtbar.

### Analyse von `Hamster.cs`

Schauen wir uns die Klasse `Hamster` an, um diese Prinzipien in Aktion zu sehen:

```csharp
public class Hamster
{
    // --- Data-Hiding durch private Felder ---
    // Diese Daten sind der interne Zustand des Hamsters. Keine andere Klasse
    // kann direkt darauf zugreifen. Dies ist gutes Data-Hiding.
    private Plane _plane;
    private List<Seedling> _mouth = new List<Seedling>();

    // --- Öffentliche Schnittstelle über Properties ---
    // Die Position ist öffentlich les- und schreibbar.
    public (int x, int y) Position { get; set; }

    // Die Darstellung ist öffentlich lesbar, aber nur die Hamster-Klasse
    // selbst kann sie ändern (private set). Das ist exzellentes Data-Hiding!
    public string Representation { get; private set; }

    // Ob der Hamster hungrig ist, kann von außen gelesen, aber nur
    // intern geändert werden.
    public bool IsHungry { get; private set; }
    
    // ... andere Methoden und Eigenschaften
}
```

### Die Rolle von Properties

Properties sind das perfekte Werkzeug für kontrolliertes Data-Hiding. Sie sehen von außen wie öffentliche Felder aus, sind aber in Wahrheit Methoden (`get` und `set`), die den Zugriff auf die eigentlichen, meist `private` gehaltenen Datenfelder (Backing Fields) steuern.

In `Hamster.cs` sehen wir das bei `Representation` und `IsHungry`.
* **`public string Representation { get; private set; }`**: Jede andere Klasse kann sehen, wie der Hamster aussieht (`get`), aber nur der Hamster selbst kann sein Aussehen ändern (`set`). Eine andere Klasse kann nicht einfach `meinHamster.Representation = "👻";` schreiben. Der Zustand bleibt unter der Kontrolle des Hamsters. Dies verhindert, dass der Zustand des Objekts inkonsistent wird.

---

## 2. Kapselung (Encapsulation)

Kapselung geht einen Schritt weiter als nur das Verstecken von Daten. Es ist das Prinzip, **zusammengehörige Daten und die Methoden, die auf diesen Daten operieren, in einer einzigen Einheit (einer Klasse) zu bündeln**.

Zwei wichtige Metriken zur Bewertung guter Kapselung sind **Kohäsion (Zusammenhalt)** und **Kopplung (Coupling)**.

* **Hohe Kohäsion (High Cohesion):** Eine Klasse sollte eine klar definierte Aufgabe haben. Alle ihre Methoden und Daten sollten auf diese eine Aufgabe ausgerichtet sein. Die `Hamster`-Klasse sollte sich um das Verhalten eines Hamsters kümmern, nicht darum, wie die Konsole gezeichnet wird.
* **Lose Kopplung (Low Coupling):** Klassen sollten so unabhängig wie möglich voneinander sein. Wenn Sie Klasse A ändern, sollten Sie idealerweise Klasse B nicht ebenfalls ändern müssen. Eine Klasse sollte nicht von den internen Implementierungsdetails einer anderen Klasse abhängig sein.

### View-Driven vs. State-Driven: Ein Fallbeispiel für schlechte Kapselung

Das `Hamster`-Beispiel zeigt ein kritisches Designproblem, das direkt mit Kapselung, Kohäsion und Kopplung zu tun hat. Der Hamster muss entscheiden, ob er auf einem Feld mit einem Setzling (`Seedling`) steht.

#### Der "View-Driven"-Ansatz (Schlecht)

Im Code sehen wir diese problematische Zeile:

```csharp
public class Hamster
{
    // ...
    // Diese Eigenschaft speichert das Symbol, das sich unter dem Hamster auf
    // der visuellen Ebene befindet.
    public string RememberSymbolOnPlane { get; set; } // Problematisch!
    // ...

    public void NutritionBehaviour()
    {
        // ...
        
        // Die Logik des Hamsters hängt von der visuellen Darstellung ab!
        if (RememberSymbolOnPlane == Seedling.Representation) // view logic: bad
        {
            // ... fressen oder einsammeln
        }
        // ...
    }
}
```

**Analyse des Problems:**

1.  **Hohe Kopplung:** Der `Hamster` ist jetzt **eng an die Implementierung der `Plane`-Klasse gekoppelt**. Der Hamster muss wissen, dass die `Plane` ihre Welt als eine Ansammlung von `string`-Symbolen darstellt. Was passiert, wenn die `Plane` morgen entscheidet, Emojis durch Farbcodes zu ersetzen? Dann bricht die gesamte Logik des Hamsters zusammen, und Sie müssen beide Klassen ändern.
2.  **Niedrige Kohäsion:** Die `Hamster`-Klasse überschreitet ihre Verantwortlichkeit. Sie kümmert sich nicht mehr nur um ihr eigenes Verhalten (hungrig sein, sich bewegen), sondern auch um die **Interpretation der visuellen Darstellung (View)** einer anderen Klasse. Die Trennung von Business-Logik (Was ist der Zustand der Welt?) und Darstellungs-Logik (Wie sieht die Welt aus?) wird verletzt.

#### Der "State-Driven"-Ansatz (Gut)

Die saubere Alternative, die im Code als Kommentar vorgeschlagen wird, ist:

```csharp
if (_plane.ContainsSeedling(Position)) // state logic: good
```

**Analyse der Lösung:**

1.  **Lose Kopplung:** Mit diesem Ansatz ist der `Hamster` von der internen Darstellung der `Plane` **entkoppelt**. Der Hamster fragt die `Plane` einfach: "Gibt es an meiner Position `(x, y)` einen Setzling?" Er verlässt sich auf eine klar definierte öffentliche Schnittstelle (`_plane.ContainsSeedling()`). Es ist ihm völlig egal, ob die `Plane` diese Information in einem `string[,]`, einer `List<Seedling>` oder einem `Dictionary` speichert. Die Implementierung der `Plane` kann sich jederzeit ändern, ohne den `Hamster` zu beeinträchtigen.
2.  **Hohe Kohäsion:** Jede Klasse behält ihre Verantwortlichkeit.
    * **`Hamster`:** Kümmert sich um seinen Zustand (`Position`, `IsHungry`) und sein Verhalten.
    * **`Plane`:** Kümmert sich um den Zustand der Spielwelt und beantwortet Fragen dazu.

Die **Business-Logik** (Was ist der Zustand?) ist jetzt klar von der **View** (Wie wird der Zustand dargestellt?) getrennt. Der `Hamster` trifft seine Entscheidungen basierend auf dem wahren Zustand der Welt, nicht auf dessen visueller Repräsentation. Das ist das Kernprinzip guter Kapselung.