# .NET
In diesem Projekt schauen wir uns folgedes an:
* Was ist .NET, .NET Core, .NET Framework, C#, und Visual Studio (VS)?
* Was finden wir in der Ordnerstruktur welche von VS?
* Was werden für Artefakte erzeugt, wenn wir ein .NET projekt builden?
* Wie builden wir Projekte mit dem Terminal, wie mit VS?

## Was ist .NET, .NET Core, .NET Framework, C#, und Visual Studio (VS)?
Wir unterscheiden hier zwischen:
* Programmiersprachen: diese sind in der .NET Welt unter anderem C#, F#, C++, ...
* Frameworks: .NET -> eine Ansammlung an allgemeinen Komponenten, Bibliotheken und Tools, welche es einfacher machen verschiedene Teile des Software Engineerings zu verbinden. .NET Framework und .NET Core sind Framworks welche unter .NET nun zusammen gefügt wurden. .NET Framework war Windows spezeifisches Framework immerwiederkehrende Aufgaben des Software Engineerings vorzuprogrammieren. Das wäre Entwicklung von Web Applikationen, Datenbankenanbindungnen, usw.
.NET Core war ein versuch .NET Framework plattformunabhängig zu machen und neue Schwerpunkte wie z.B. Microservices zu setzen.
Es wurde ab Version 8 einfach als .NET bezeichnet und bietet nun alles unter einem Schirm an.
(Erzeuge Projekte ohne dem Beinamen .net Framework, z.B. "Console App" vs. "Console App (.NET Framework)).
* Die Entwicklungsumgebung ist hier VS. Es gibt auch von JET Brains (Macher von Intellij) eine C# Programmier umgebung. Es wird jedoch empfohnen VS zu verwenden.

## Was finden wir in der Ordnerstruktur welche von VS?
Wenn wir ein Projekt anlegen (Console App), dann wird uns eine Datei mit einem oder mehreren Ordner angelegt. 
* **Datei**: Diese hat die Endung .sln welche als "Solution" bezeichnet wird. 
Dies ist eine "Projektmappe" welche mehrere Projekte beinhalten kann. Diesbezügliche Konfigurationen sind in dieser Dateil enthalten.
Eine Konfoguratin wäre, welche welche Erweiterungen werden verwendet, welche Analysetools, Build-Prozesse, Debugging configs, Version Control, usw.
Alles was Projektübergreifend funktionieren soll.
* **Ordner**: Inerhalb eines Ordners befindet sich nun ein Projekt, welches folgende Struktur hat:
    * **bin**: Dieser Ordner wird beim Kompilieren des Projekts erstellt. Enthält die kompilierten Ausgabedateien (z.B. .exe oder .dll). Wird in Unterordner für verschiedene Build-Konfigurationen (z.B. Debug, Release) und Plattformen (z.B. net7.0) unterteilt.
    * **obj**: Enthält temporäre Dateien, die während des Build-Prozesses erstellt werden. Hier werden u.a. Zwischenergebnisse gespeichert, bevor die endgültige Kompilierung erfolgt. Auch hier gibt es Unterordner für Build-Konfigurationen.
    * **Properties**: In diesem Ordner werden Projekt- und Konfigurationseinstellungen gespeichert. Typischerweise findet man hier z.B. eine launchSettings.json, die Informationen zur Ausführung des Projekts enthält (z.B. Konfiguration für den Debugger).
    * **Dependencies**: Visual Studio organisiert Abhängigkeiten (NuGet-Pakete und andere Bibliotheken) in diesem Abschnitt. Diese Abhängigkeiten werden in der Projektdatei (.csproj) aufgeführt. Hier können alle externen Bibliotheken und Pakete gefunden werden, die das Projekt verwendet.
    * **MyProject.csproj**: Jede .NET-Projektdatei in Visual Studio hat eine Datei mit der Endung .csproj (bei C#-Projekten). Diese Datei enthält wichtige Informationen wie: 
        * Zielplattform (z.B. .NET 6.0, .NET Framework 4.8)
        * Abhängigkeiten zu externen Paketen (z.B. NuGet-Pakete)
        * Build-Einstellungen (Debug/Release)
    Es kann hier Beispielsweise gesteuer werden welche Ordner für die Kompilierung verwendet werden. 
    * **Program.cs**: Dies ist die Hauptdatei eines Konsolenanwendungsprojekts. Hier befindet sich die Einstiegsmethode (Main), die als Startpunkt des Programms dienen kann.



### Wichtige Dateiendungen in .NET-Projekten
* **.csproj**: Die Projektdatei eines C#-Projekts. Enthält alle wichtigen Konfigurationen und Einstellungen des Projekts.
* **.cs**: Quellcode-Dateien für C#. Jede C#-Klasse, Schnittstelle oder Struktur befindet sich in einer .cs-Datei.
* **.dll**: Dynamische Bibliothek (Dynamic Link Library), die erstellt wird, wenn ein Projekt kompiliert wird. Diese Datei wird für Bibliotheksprojekte oder für ausführbare Anwendungen benötigt.
* **.exe**: Eine ausführbare Datei, die bei Konsolen- oder Desktopanwendungen erstellt wird. Diese Datei kann direkt auf Windows-Systemen ausgeführt werden.
* **.json**: JSON-Dateien werden oft für Konfigurationen und Einstellungen verwendet. Beispielsweise appsettings.json oder launchSettings.json.
* **.config**: In älteren .NET-Projekten (insbesondere .NET Framework) werden Konfigurationsdateien wie App.config oder Web.config verwendet, um Einstellungen zu speichern.
* **NuGet-Paketdateien**: packages.config: Wird in älteren Projekten verwendet, um NuGet-Abhängigkeiten zu verwalten. In modernen Projekten werden NuGet-Abhängigkeiten direkt in der .csproj-Datei aufgeführt.

### Beispiel:
 * **L01MyFirstDotNetProject.deps.json:**
Diese Datei enthält Abhängigkeiten und Metadaten über das Projekt, wie Informationen zu den verwendeten Bibliotheken und Frameworks. Sie wird von der .NET-Laufzeit verwendet, um sicherzustellen, dass alle notwendigen Pakete und Abhängigkeiten vorhanden sind, bevor die Anwendung ausgeführt wird.

* **L01MyFirstDotNetProject.dll**:
Die Dynamic Link Library (DLL) enthält den kompilierten Code der Anwendung in Form von CIL (Common Intermediate Language). Diese Datei wird von der .NET Runtime (CLR) verwendet, um den Code zur Laufzeit auszuführen. In einer typischen .NET-Anwendung kann der .exe-Loader auf diese DLL zugreifen.

* **L01MyFirstDotNetProject.exe:**
Dies ist die ausführbare Datei der Anwendung. Sie enthält einen "Entry Point", mit dem das Programm unter Windows ausgeführt werden kann. Die eigentliche Logik befindet sich in der .dll, und diese .exe dient als Startpunkt für die Anwendung.

* **L01MyFirstDotNetProject.pdb**:
Die Program Database (PDB)-Datei enthält Debug-Informationen. Sie wird verwendet, um Debugging-Sitzungen zu ermöglichen, indem sie Informationen über den Quellcode und die Zuordnung von CIL-Code zu den Originalquellen bereitstellt. Diese Datei hilft Entwicklern, Fehler im Code zu finden, indem sie z.B. Zeilennummern oder Variablenwerte beim Debuggen sichtbar macht.

* **L01MyFirstDotNetProject.runtimeconfig.json:**
Diese Datei definiert Konfigurationsparameter für die .NET-Laufzeit, wie die spezifische .NET-Version, die für das Projekt verwendet wird. Sie gibt an, welche Runtime von der Anwendung erwartet wird und hilft der .NET-Laufzeit, die passende Umgebung für die Ausführung der Anwendung bereitzustellen.

## Was werden für Artefakte erzeugt, wenn wir ein .NET projekt builden?

### Was brauchen wir zuerst? - Compiler, Virtual Machine und intermediate Language
Compiler schreiben aus den von uns geschriebenen Code, Code welche für den Computer lesbar ist. Hier kommen viele technische Details hinzu um welche wir uns nicht den Kopf zerbrechen müssen. 
Der Compilier ist also ein Programm was C# code nimmt und diesen in die Intermediary Language (IL) unwandelt.
Danach wird diese IL genommen und von der Virtual Machine ausgeführt. Das kann auch das Betriebssystem sein (bei C und C++). Java und C# haben jedoch explizit diesen Zwischenschritt der Virtual Machine, damit Plattformunabhängigkeit gewährleistet wird.

Hier ein kleiner Vergleich der Begrifflichkeiten von JAVA und C#.
| Merkmal                       | Java (JVM)                                   | C# (.NET CLR)                                 |
|-------------------------------|----------------------------------------------|------------------------------------------------|
| **Intermediary Language**              | Bytecode in `.class`-Dateien                | Intermediate Language (IL) in `.dll`/`.exe`   |
| **Virtaul Machine**              | **JAVA Virtual Machine (JVM)** - mehrere Sprachen wie Kotlin, Scala und JAVA kompilieren in Bytecode welcher von der JVM ausgeführt wird | **Common Language Runtime (CLR)** - mehrere Sprachen wie F#, VisualBasic, C# kompilieren in IL welche in der CLR ausgeführt wird |

Beides sind hier Just-in-time Compiler, welcher es erlauben wenn das Programm aufgerufen wird ensprechend verwendete Teile des Codes zu kompilieren, anstatt alles unter einmal. 

### Was wird nun bei Build generiert? 
Schauen wir uns die IL von C# genauer an welche nicht wie in JAVA in einem class file, sondern verteilt in mehreren Files ist.

Dazu verwenden wir den Befehlt *ildasm L01MyFirstDotNetProject.dll*. Wir gehen dazu in den Terminal innerhalb von VS und ändern den Pfad zu **cd bin\Debug\net8.0**. Wir sehen folgendes:

```csharp
.method public hidebysig specialname rtspecialname 
        instance void  .ctor() cil managed
{
  // Code size       8 (0x8)
  .maxstack  8
  IL_0000:  ldarg.0
  IL_0001:  call       instance void [System.Runtime]System.Object::.ctor()
  IL_0006:  nop
  IL_0007:  ret
} // end of method Program::.ctor
```

* **.method**: Dies markiert den Beginn einer neuen Methode.
* **public**: Die Sichtbarkeit der Methode ist öffentlich, d. h. sie kann von anderen Klassen aufgerufen werden.
* **hidebysig**: Dies bedeutet, dass die Methode nicht durch die Signatur der Methode in einer abgeleiteten Klasse überladen werden kann.
* **specialname**: Dies bedeutet, dass es sich um einen speziellen Methodennamen handelt (in diesem Fall den Konstruktor).
* **instance**: Dies zeigt an, dass die Methode auf einer Instanz der Klasse aufgerufen wird, nicht als statische Methode.
* **void**: Der Rückgabewert der Methode ist void, was bedeutet, dass sie nichts zurückgibt.
* **.ctor()**: Dies ist der Name der Methode, der den Konstruktor der Klasse darstellt.
* **cil managed**: Dies gibt an, dass die Methode in Common Intermediate Language (CIL) geschrieben ist und von der CLR (Common Language Runtime) verwaltet wird.

* **Code size**: Dies zeigt die Größe des Codes in Bytes an. In diesem Fall beträgt die Größe 8 Bytes (0x8).
* **.maxstack 8**: Dies gibt die maximale Größe des Stapels an, die für diese Methode verwendet wird. Hier beträgt der Maximalwert 8.
* **IL_0000**: ldarg.0: Diese Anweisung lädt das erste Argument (in diesem Fall die this-Referenz der Instanz, auf der die Methode aufgerufen wird) auf den Stapel.
* **IL_0001**: call instance void [System.Runtime]System.Object::.ctor(): Diese Anweisung ruft den Konstruktor der Basisklasse Object auf. Dies ist der Standard-Konstruktor, der für alle Klassen in .NET verfügbar ist. Dies ist wichtig, um sicherzustellen, dass die Basisklasse korrekt initialisiert wird.
* **IL_0006**: nop: Dies ist eine "no operation"-Anweisung, die keine Aktion ausführt. Sie kann zur Synchronisation oder für Debugging-Zwecke verwendet werden.
* **IL_0007**: ret: Diese Anweisung beendet die Methode und gibt die Kontrolle an den Aufrufer zurück.

### Was bedeuten die zahlen neben IL? z.B. IL0001
Die Zahlen neben den IL-Anweisungen (wie IL_0000, IL_0001, usw.) sind sogenannte IL-Offsets. Sie geben die Position oder den Offset der jeweiligen Anweisung im IL-Code an. 

* **Offset**: Die Zahlen sind in der Regel in hexadezimaler Form und stellen die Anzahl der Bytes dar, die seit Beginn der Methode gezählt werden. Sie zeigen an, an welcher Stelle im IL-Code sich die jeweilige Anweisung befindet.

* **Identifikation**: Jedes IL-Label hat ein eindeutiges Offset, das es ermöglicht, die Reihenfolge der Ausführung der Anweisungen zu verfolgen. Dies ist besonders nützlich für das Debugging und die Analyse des Codes.

### Warum war es nicht eine fortlaufende Nummer wie 0001, 0002, 0003, und 0004?
Die IL-Offsets neben den IL-Anweisungen sind nicht notwendigerweise fortlaufend oder gleichmäßig, weil sie die Anzahl der Bytes repräsentieren, die in der IL-Implementierung für jede Anweisung benötigt werden.

* **IL_0000**: ldarg.0 benötigt 1 Byte.
* **IL_0001**: call instance void [System.Runtime]System.Object::.ctor() könnte 5 Bytes benötigen (1 Byte für den Befehl und 4 Bytes für die Argumente).
* **IL_0006**: nop benötigt 1 Byte.
* **IL_0007**: ret benötigt 1 Byte.


## Wie builden wir Projekte mit dem Terminal, wie mit VS?
Ein neues C#-Projekt erstellen:
Öffnen Sie das Terminal und navigieren Sie zu dem Ordner, in dem Sie Ihr Projekt erstellen möchten.

Führen Sie den folgenden Befehl aus, um eine neue Konsolenanwendung zu erstellen:
```dotnet new console -n MyApp```
Dies erstellt einen neuen Ordner MyApp mit einem grundlegenden C#-Programm.

Den Code kompilieren und ausführen:
Navigieren Sie in den Projektordner:

``` cd MyApp ```
Kompilieren und führen Sie die Anwendung aus:

``` dotnet run ```
Dieser Befehl kompiliert den Code und führt ihn sofort aus.

Eine ausführbare (.exe) Datei erstellen:
Um eine ausführbare Datei zu generieren, veröffentlichen Sie das Projekt:

``` dotnet publish -c Release -r win-x64```

Dies erstellt eine ausführbare Datei im Ordner bin/Release/net7.0/win-x64/publish (passen Sie dies je nach Ihrer .NET-Version an).
Sie können jetzt die .exe-Datei direkt aus dem Veröffentlichungsordner ausführen.