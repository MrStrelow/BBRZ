package lerneinheiten.L05InterfacesUndAbstrakteKlassen.erweiterung_von_collections;

import java.util.Collection;
import java.util.Iterator;
import java.util.NoSuchElementException;

class Horde implements Collection<Schaefer>, AgeableCollection {
    private Schaefer[] schaferArray; // Array zur Speicherung der Schäfer-Objekte
    private int size; // Aktuelle Anzahl der Elemente im Array

    // Konstruktor zur Initialisierung des Arrays mit einer gegebenen Kapazität
    public Horde(int initialCapacity) {
        schaferArray = new Schaefer[initialCapacity];
        size = 0;
    }

    // Gibt die Anzahl der Schäfer in der Horde zurück
    @Override
    public int size() {
        return size;
    }

    // Prüft, ob die Horde leer ist (keine Schäfer enthalten)
    @Override
    public boolean isEmpty() {
        return size == 0;
    }

    // Überprüft, ob ein bestimmtes Schäfer-Objekt in der Horde enthalten ist
    @Override
    public boolean contains(Object o) {
        if (!(o instanceof Schaefer)) return false;
        for (int i = 0; i < size; i++) {
            if (schaferArray[i].equals(o)) {
                return true;
            }
        }
        return false;
    }

    // Gibt einen Iterator zurück, um die Horde zu durchlaufen
    @Override
    public Iterator<Schaefer> iterator() {
        return new Iterator<>() {
            private int index = 0; // Aktuelle Position im Array

            @Override
            public boolean hasNext() {
                return index < size;
            }

            @Override
            public Schaefer next() {
                if (!hasNext()) {
                    throw new NoSuchElementException(); // Exception, wenn keine Elemente mehr vorhanden sind
                }
                return schaferArray[index++];
            }
        };
    }

    // Gibt den Inhalt der Horde als Array zurück
    @Override
    public Object[] toArray() {
        Schaefer[] newArray = new Schaefer[size];
        System.arraycopy(schaferArray, 0, newArray, 0, size);
        return newArray;
    }

    // Kopiert die Elemente in ein gegebenes Array
    @Override
    public <T> T[] toArray(T[] a) {
        if (a.length < size) {
            return (T[]) java.util.Arrays.copyOf(schaferArray, size, a.getClass());
        }
        System.arraycopy(schaferArray, 0, a, 0, size);
        if (a.length > size) {
            a[size] = null; // Setzt das nächste Element auf null, wenn das Array größer ist
        }
        return a;
    }

    // Fügt einen neuen Schäfer zur Horde hinzu
    @Override
    public boolean add(Schaefer schafer) {
        if (size == schaferArray.length) {
            expandCapacity(); // Erweitert das Array, wenn es voll ist
        }
        schaferArray[size++] = schafer;
        return true;
    }

    // Entfernt ein Schäfer-Objekt aus der Horde
    @Override
    public boolean remove(Object o) {
        if (!(o instanceof Schaefer)) return false;
        for (int i = 0; i < size; i++) {
            if (schaferArray[i].equals(o)) {
                System.arraycopy(schaferArray, i + 1, schaferArray, i, size - i - 1);
                schaferArray[--size] = null; // Verhindert Speicherleck
                return true;
            }
        }
        return false;
    }

    // Prüft, ob alle Elemente einer gegebenen Collection in der Horde enthalten sind
    @Override
    public boolean containsAll(Collection<?> c) {
        for (Object o : c) {
            if (!contains(o)) {
                return false;
            }
        }
        return true;
    }

    // Fügt alle Elemente aus einer anderen Collection zur Horde hinzu
    @Override
    public boolean addAll(Collection<? extends Schaefer> c) {
        boolean modified = false;
        for (Schaefer schafer : c) {
            modified |= add(schafer);
        }
        return modified;
    }

    // Entfernt alle Elemente aus der Horde, die in der gegebenen Collection enthalten sind
    @Override
    public boolean removeAll(Collection<?> c) {
        boolean modified = false;
        for (Object o : c) {
            while (contains(o)) {
                remove(o);
                modified = true;
            }
        }
        return modified;
    }

    // Behält nur die Elemente, die auch in der gegebenen Collection enthalten sind
    @Override
    public boolean retainAll(Collection<?> c) {
        boolean modified = false;
        for (int i = 0; i < size; i++) {
            if (!c.contains(schaferArray[i])) {
                remove(schaferArray[i]);
                i--; // Index anpassen nach Entfernung
                modified = true;
            }
        }
        return modified;
    }

    // Entfernt alle Schäfer aus der Horde
    @Override
    public void clear() {
        for (int i = 0; i < size; i++) {
            schaferArray[i] = null;
        }
        size = 0;
    }

    // Erweitert die Kapazität des Arrays dynamisch
    private void expandCapacity() {
        Schaefer[] newArray = new Schaefer[schaferArray.length * 2];
        System.arraycopy(schaferArray, 0, newArray, 0, schaferArray.length);
        schaferArray = newArray;
    }

    // Berechnet das Gesamtalter aller Schäfer in der Horde
    public int getTotalAge() {
        int totalAge = 0;
        for (int i = 0; i < size; i++) {
            totalAge += schaferArray[i].getAge();
        }
        return totalAge;
    }

    // Vergleicht diese Horde mit einer anderen basierend auf dem Gesamtalter der Schäfer
    @Override
    public int compareTo(AgeableCollection other) {
        return Integer.compare(this.getTotalAge(), other.getTotalAge());
    }
}
