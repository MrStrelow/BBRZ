package lerneinheiten.L05InterfacesUndAbstrakteKlassen.optional.zahlen;

/*
    Hier sehen wir ein INTERFACE. Wir schreiben dies zumeist als Eigenschaftswort/Adjektiv.
    Ein Interface ist eine abstrakte Klasse welche nur abstrakte Methoden hat (wir ignorieren das keyword default, für jene welche das kennen).
    Bedeutet wir können nur sagen welches Methodenverhalten ein Summierbares Objekt haben muss. Wir zwingen also jene Klasse,
    welche summierbar ist, dort diese MEthode zu implementieren. Deshalb ist das Keyword auch IMPLEMENTS und nicht extends.
    Wir können zudem von mehreren Interfaces ableiten. Also eine Zahl ist Summierbar und Transformierbar.
    Siehe z.B. Zahl.
 */
public interface Summierbar {
    // interfaces können mit "default" keyword implementiert werden.
    Summierbar sum(Summierbar x);
}
