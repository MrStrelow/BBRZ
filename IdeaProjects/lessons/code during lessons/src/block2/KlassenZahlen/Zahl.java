package block2.KlassenZahlen;

/*
    Wir verwenden hier abstract um zu verhindern, dass ein Objekt vom Typ Zahl erstellt werden kann.
    Wir denken und nämlich, dass eine Zahl nichts eigenständiges ist. Diese soll immer einen konkreteren Typen haben, z.B.
    DecimalZahl oder BinaryZahl.
    ACHTUNG! Es bedeutet, nicht dass wir kein Objekt von Zahl im code finden können! Wir können nämlich schreiben
    Zahl zahl = new BinaryZahl();. Wir wollen nur verhindern, dass Zahl zahl = new Zahl(); steht.
    Abstract kann zudem im Bezug zu einer Methode verwendet werden. Dies bedeutet dann, dass die Methode nicht hier implementiert
    wird, sondern in einer UNTER-Klasse, also eine Klasse welche die Zahl extended.
 */
public abstract class Zahl implements Transformierbar, Summierbar {

    private String wert;

    public String getWert() {
        return wert;
    }

    public void setWert(String wert) {
        this.wert = wert;
    }
}
