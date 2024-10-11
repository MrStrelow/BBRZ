# Zusammenfassung zur Variablenumwandlung

In C# können Variablen zwischen verschiedenen Datentypen umgewandelt werden. Hier sind drei häufige Fälle der Umwandlung:

## 1. Zahl zu Zahl

Bei der Umwandlung von Zahlen gibt es zwei häufige Szenarien:

- **int zu double:** Ein ganzzahliger Wert kann in einen Gleitkommawert umgewandelt werden, um Dezimalwerte zu ermöglichen. Diese Umwandlung erfolgt implizit, da sie keine Daten verliert.
  
  ```csharp
  int intValue = 10;
  double doubleValue = intValue; // Implizite Umwandlung
  ```

- **double zu int:** Hierbei wird der Gleitkommawert in einen ganzzahligen Wert umgewandelt. Bei dieser Umwandlung geht der Dezimalteil verloren, und die Umwandlung erfolgt explizit, um Klarheit zu schaffen.
  
  ```csharp
  double doubleValue = 10.5;
  int intValue = (int)doubleValue; // Explizite Umwandlung
  ```

## 2. String zu Zahl

Um einen String in eine Zahl umzuwandeln, können die `Parse`-Methoden verwendet werden:

- **int.Parse:** Wandelt einen String in eine Ganzzahl um.
  
  ```csharp
  string intString = "123";
  int intValue = int.Parse(intString);
  ```

- **double.Parse:** Wandelt einen String in einen Gleitkommawert um.
  
  ```csharp
  string doubleString = "123.45";
  double doubleValue = double.Parse(doubleString);
  ```

- **TryParse:** Eine sicherere Methode, die einen booleschen Wert zurückgibt, um anzuzeigen, ob die Umwandlung erfolgreich war.
  
  ```csharp
  string intString = "123";
  if (int.TryParse(intString, out int intValue))
  {
      // Umwandlung erfolgreich
  }
  ```

## 3. Zahl zu String

Eine Zahl kann in einen String umgewandelt werden, indem die `ToString`-Methode verwendet wird:

- **ToString:** Wandelt eine Zahl in ihren String-Darstellung um.
  
  ```csharp
  int intValue = 123;
  string intString = intValue.ToString();
  ```

## 4. Verwendung der Convert-Klasse

Die `Convert`-Klasse bietet eine einfache Möglichkeit, verschiedene Datentypen zu konvertieren:

- **Convert.ToInt32:** Wandelt einen Wert in eine Ganzzahl um.
  
  ```csharp
  string strValue = "123";
  int intValue = Convert.ToInt32(strValue);
  ```

- **Convert.ToDouble:** Wandelt einen Wert in einen Gleitkommawert um.
  
  ```csharp
  string strValue = "123.45";
  int intValue = 123;
  double doubleValue = Convert.ToDouble(strValue);
  double anotherDoubleValue = Convert.toDouble(intValue); // beides mit der gleichen Methode!
  ```

- **Convert.ToString:** Wandelt einen Wert in einen String um.
  
  ```csharp
  int intValue = 123;
  string intString = Convert.ToString(intValue);
  ```

Diese Methoden ermöglichen eine flexible und sichere Handhabung von Datentypen in C#.