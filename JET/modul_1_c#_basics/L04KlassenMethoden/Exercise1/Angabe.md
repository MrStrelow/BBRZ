# Custom Collections Exercise with Age-based Comparisons

This exercise builds on our previous example, adding functionality to:
1. **Track the age** of individual `Schaf` and `Schaefer` objects.
2. **Compare collections** (`Herde<Schaf>` and `Horde<Schaefer>`) based on the **total age** of their elements.
3. Implement an **interface `Ageable`** to facilitate comparisons between different types of collections.

---

## Step 1: Define `Ageable` Interface

All classes that have an age must implement this interface.

```java
interface Ageable {
    int getAge();
}
```

---

## Step 2: Modify `Schaf` and `Schaefer` Classes

Both classes will now include an age field and implement the `Ageable` interface.

```java
class Schaf implements Ageable {
    private String id;
    private int age;

    public Schaf(String id, int age) {
        this.id = id;
        this.age = age;
    }

    public String getId() {
        return id;
    }

    @Override
    public int getAge() {
        return age;
    }
}
```

```java
class Schaefer extends Hund implements Ageable {
    private int age;

    public Schaefer(String name, int age) {
        super(name);
        this.age = age;
    }

    @Override
    public int getAge() {
        return age;
    }

    public void hueten(Schaf schaf) {
        System.out.println(getName() + " is herding the sheep with ID: " + schaf.getId());
    }
}
```

---

## Step 3: Update `Herde<Schaf>` Collection

Extend `ArrayList<Schaf>` and implement `Comparable<Herde<Schaf>>`. The comparison is based on the total age of sheep.

```java
import java.util.ArrayList;

class Herde<Schaf extends Ageable> extends ArrayList<Schaf> implements Comparable<Herde<Schaf>> {
    
    // Calculate the total age of all sheep
    private int getTotalAge() {
        return this.stream().mapToInt(Schaf::getAge).sum();
    }

    @Override
    public int compareTo(Herde<Schaf> other) {
        return Integer.compare(this.getTotalAge(), other.getTotalAge());
    }
}
```

---

## Step 4: Implement `Horde<Schaefer>` as a Custom Collection

`Horde` implements `Collection<Schaefer>` and uses the total age for comparisons.

```java
import java.util.Collection;
import java.util.Iterator;
import java.util.NoSuchElementException;

class Horde implements Collection<Schaefer>, Comparable<Horde> {
    private Schaefer[] schaferArray;
    private int size;

    public Horde(int initialCapacity) {
        schaferArray = new Schaefer[initialCapacity];
        size = 0;
    }

    @Override
    public boolean add(Schaefer schafer) {
        if (size == schaferArray.length) {
            expandCapacity();
        }
        schaferArray[size++] = schafer;
        return true;
    }

    private void expandCapacity() {
        Schaefer[] newArray = new Schaefer[schaferArray.length * 2];
        System.arraycopy(schaferArray, 0, newArray, 0, schaferArray.length);
        schaferArray = newArray;
    }

    private int getTotalAge() {
        int totalAge = 0;
        for (int i = 0; i < size; i++) {
            totalAge += schaferArray[i].getAge();
        }
        return totalAge;
    }

    @Override
    public int compareTo(Horde other) {
        return Integer.compare(this.getTotalAge(), other.getTotalAge());
    }

    // Other methods omitted for brevity...
}
```

---

## Step 5: Enable Cross-Type Comparison Between `Herde` and `Horde`

Add a generic method that compares any collection of `Ageable` objects.

```java
class CollectionUtils {
    public static int compareAgeableCollections(Collection<? extends Ageable> col1, Collection<? extends Ageable> col2) {
        int age1 = col1.stream().mapToInt(Ageable::getAge).sum();
        int age2 = col2.stream().mapToInt(Ageable::getAge).sum();
        return Integer.compare(age1, age2);
    }
}
```

---

## Usage Example

```java
public class Main {
    public static void main(String[] args) {
        Herde<Schaf> herde = new Herde<>();
        herde.add(new Schaf("S1", 3));
        herde.add(new Schaf("S2", 5));

        Horde horde = new Horde(2);
        horde.add(new Schaefer("Schaefer1", 4));
        horde.add(new Schaefer("Schaefer2", 6));

        System.out.println("Comparison result (Herde vs. Horde): " + 
            CollectionUtils.compareAgeableCollections(herde, horde));
    }
}
```

---

## Summary

This exercise demonstrates:
- Implementing an `Ageable` interface for cross-type compatibility.
- Using **total age** to compare collections.
- Creating custom collections (`Herde` and `Horde`) with extended functionality.

