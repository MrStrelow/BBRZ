# Demonstration und Erarbeitung der Notwendigkeit von Klassenbibliotheken und dem NuGet-Paketmanager

## Ziel
Das Ziel dieser Übung ist es, die Sinnhaftigkeit von Klassenbibliotheken zu verdeutlichen und das Verständnis für deren Nutzung und Struktur zu stärken. Dazu wird der NuGet-Paketmanager verwendet, um ein externes Paket wie **Serilog** einzubinden. Anschließend wird eine eigene Klassenbibliothek erstellt und in einem Projekt verwendet.

---

## Ablauf

### 1. Nutzung eines NuGet-Pakets (z. B. Serilog)
Zunächst wird ein externes Paket heruntergeladen und in einem Projekt verwendet. Dies dient dazu, die Vorteile von Klassenbibliotheken anhand eines konkreten Anwendungsbeispiels zu zeigen.

#### Schritte:
1. **Paketmanager öffnen**:
   - Öffne den NuGet-Paketmanager in Visual Studio:
     - Rechtsklick auf das Projekt > **NuGet-Pakete verwalten**.
   - Alternativ: Nutze die Konsole mit dem Befehl:
     ```
     Install-Package Serilog
     ```

2. **Paket hinzufügen**:
   - Suche nach **Serilog** und füge das Paket dem Projekt hinzu.

3. **Serilog konfigurieren und verwenden**:
   - Schreibe einen einfachen Logger:
   ```csharp
   using Serilog;

   class Program
   {
       static void Main(string[] args)
       {
           Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .CreateLogger();

           Log.Information("Dies ist eine Testmeldung.");
           Log.Warning("Achtung! Dies ist eine Warnung.");
           Log.CloseAndFlush();
       }
   }
