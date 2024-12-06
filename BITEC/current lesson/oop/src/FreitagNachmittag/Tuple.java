package FreitagNachmittag;

import java.util.Objects;

public class Tuple<T, U> {
    private T x;
    private U y;

    public Tuple(T x, U y) {
        this.x = x;
        this.y = y;
    }

    public T getX() {
        return x;
    }

    public U getY() {
        return y;
    }

    public void setX(T x) {
        this.x = x;
    }

    public void setY(U y) {
        this.y = y;
    }

    @Override
    public String toString() {
        return "(" + x + ", " + y + ")";
    }

    // Achtung! Da wir für die HashMap einen Hash brauchen, welcher nicht identity vergleicht,
    // müssen wir die equals methode überschreiben.
    // Dazu erzeugen wir einen neuen hash, welcher die "Kombination" aus den Hashes der einzelnen Elemente ist.
    @Override
    public int hashCode() {
        return Objects.hash(x, y); // Combine hashes of both fields
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true; // Same reference
        if (o == null || getClass() != o.getClass()) return false; // Null or different class
        Tuple<?, ?> tuple = (Tuple<?, ?>) o;
        return Objects.equals(x, tuple.x) &&
                Objects.equals(y, tuple.y); // Compare fields
    }
}
