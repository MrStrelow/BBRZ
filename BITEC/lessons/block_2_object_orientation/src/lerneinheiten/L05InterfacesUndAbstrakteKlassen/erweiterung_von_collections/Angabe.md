# Aufgabe: Vergleich von "Herde" und "Horde" mit AgeableCollection

## Einführung
In dieser Übung erweitern wir die Konzepte der Herde und Horde, indem wir eine **komplexe Sammlung** mit einem **Vergleichsmechanismus** erstellen, der das **Alter** der Tiere berücksichtigt. Ziel ist es, eine Sammlung von Tieren (`Schaf`, `Schaefer`) zu verwalten, die mit einer `AgeableCollection` verglichen werden kann. Dafür wird ein **Adapter-Designmuster** verwendet, um die inneren Details der Sammlung zu verstecken und eine einheitliche Vergleichsmöglichkeit zu schaffen.

## Schritt 1: Definition der `AgeableCollection` Schnittstelle

Zuerst definieren wir eine Schnittstelle `AgeableCollection`, die das Vergleichen von Sammlungen auf der Basis des Alters von Tieren ermöglicht. Diese Schnittstelle erfordert, dass die Implementierungen eine Methode `compareTo()` bereitstellen.

```java
public interface AgeableCollection extends Comparable<AgeableCollection> {
// Keine getTotalAge() hier, nur die compareTo Methode
int compareTo(AgeableCollection other);
}
```

## Schritt 2: Die Klassen `Horde` und `Herde` erweitern

Die Klassen `Horde` (Sammlung von `Schaefer`) und `Herde` (Sammlung von `Schaf`) implementieren beide die `AgeableCollection` Schnittstelle. Diese Klassen enthalten eine private Methode `getTotalAge()`, die das Alter aller Tiere in der Sammlung summiert.

### **Horde Klasse:**

```java
public class Horde implements Collection<Schaefer>, AgeableCollection {
private Schaefer[] schaferArray;
private int size;

    public Horde(int initialCapacity) {
        schaferArray = new Schaefer[initialCapacity];
        size = 0;
    }

    // Private Methode zur Berechnung des Gesamtalters, wird versteckt
    private int getTotalAge() {
        int totalAge = 0;
        for (int i = 0; i < size; i++) {
            totalAge += schaferArray[i].getAge();
        }
        return totalAge;
    }

    // Implementierung der compareTo Methode
    @Override
    public int compareTo(AgeableCollection other) {
        if (other instanceof Horde) {
            return Integer.compare(this.getTotalAge(), ((Horde) other).getTotalAge());
        }
        return 0;
    }

    // Weitere Methoden zur Sammlung werden hier implementiert, z.B. size(), add(), remove()
}
```

### **Herde Klasse:**

```java
public class Herde implements Collection<Schaf>, AgeableCollection {
private Schaf[] schafArray;
private int size;

    public Herde(int initialCapacity) {
        schafArray = new Schaf[initialCapacity];
        size = 0;
    }

    // Private Methode zur Berechnung des Gesamtalters, wird versteckt
    private int getTotalAge() {
        int totalAge = 0;
        for (int i = 0; i < size; i++) {
            totalAge += schafArray[i].getAge();
        }
        return totalAge;
    }

    // Implementierung der compareTo Methode
    @Override
    public int compareTo(AgeableCollection other) {
        if (other instanceof Herde) {
            return Integer.compare(this.getTotalAge(), ((Herde) other).getTotalAge());
        }
        return 0;
    }

    // Weitere Methoden zur Sammlung werden hier implementiert, z.B. size(), add(), remove()
}
```

## Schritt 3: Verwenden von AgeableCollections

Jetzt können wir sowohl `Herde` als auch `Horde` verwenden und miteinander vergleichen, da beide die `AgeableCollection` Schnittstelle implementieren.

```java
public class Main {
public static void main(String[] args) {
Herde herde1 = new Herde(10);
Herde herde2 = new Herde(10);
Horde horde1 = new Horde(10);
Horde horde2 = new Horde(10);

        // Beispiel: Vergleiche zwei Herden oder zwei Horden basierend auf ihrem Gesamtalter
        System.out.println(herde1.compareTo(herde2));  // Ausgabe könnte 0, positiv oder negativ sein
        System.out.println(horde1.compareTo(horde2));  // Ausgabe könnte 0, positiv oder negativ sein
    }
}
```
