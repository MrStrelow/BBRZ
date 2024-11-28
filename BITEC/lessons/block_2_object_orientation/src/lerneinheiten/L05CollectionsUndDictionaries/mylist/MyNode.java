package lerneinheiten.L05CollectionsUndDictionaries.mylist;

public class MyNode<Typ> {
    // Feld
    private Typ value;

    // Hat-Beziehungen
    private MyNode<Typ> nachbar;

    // Konstruktor
    public MyNode(Typ value) {
        this.value = value;
    }

    // Methoden
    // get-set Methoden
    public Typ getValue() {
        return value;
    }

    public MyNode<Typ> getNachbar() {
        return nachbar;
    }

    public void setNachbar(MyNode<Typ> nachbar) {
        this.nachbar = nachbar;
    }
}
