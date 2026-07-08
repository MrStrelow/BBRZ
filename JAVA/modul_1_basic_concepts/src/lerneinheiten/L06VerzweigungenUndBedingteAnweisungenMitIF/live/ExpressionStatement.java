package lerneinheiten.L06VerzweigungenUndBedingteAnweisungenMitIF.live;

public class ExpressionStatement {
    public static void main(String[] args) {
        // Zuweisen eines Alter. Abfragen ob dieses größer 18 ist.
        // Wenn 18 oder größer soll der Text willkommen der variable zugewiesen werden. Ansonsten "Zu jung".

        // 1) Statement - If-Else
        Integer alter = 25;
        String ausgabe;

        if (alter >= 18) {
            ausgabe = "willkommen";
        } else {
            ausgabe = "Zu jung";
        }

        System.out.println(ausgabe);

        // 2) Statement - switch (geht nicht !)
        // siehe Regeln.

        // 3) Expression - If-Else
        ausgabe = alter >= 18 ? "willkommen" : "Zu jung";
        ausgabe = (alter >= 18) ? "willkommen" : "Zu jung"; // gleich. nur mit klammer zur übersicht.

        System.out.println(ausgabe);

        // 4) Expression - switch (geht nicht !)
        // geht auch nicht! ABER hier für alter == 18

        ausgabe = switch (alter) {
            case 18 -> "willkommen";
            default -> "Zu jung";
        };

        System.out.println(ausgabe);

        // Für besonders Interessierte:
        ausgabe = switch (alter) {
            case Integer a when a >= 18 -> "willkommen";
            case Integer a              -> "Zu jung";
        };

        // Regeln:
        // * Expression für kompakte Logik und vielen Zuweisungen
        //      (viel in Javascript verwendet, auch modernes pattern matching - siehe switch).
        // * Statement für mehrzeilige Logik welche umfangreicher ist.
        //      (Stabiles bekanntes Werkzeug in allen Sprachen wie JAVA, C#, C++, GO, Rust, ...)
        // * Switch Statement ist eingeschränktes if-else. Kann nur auf gleichheit überprüfen (== und nicht z.B. >=)
        // * Switch Expression (pattern matching) ist ein mächtiges Werkzeug und kann auch ungleichheiten abfragen.
        //      Wir gehen nur auf die basics ein und schreiben es für ==.
        //      Allgemein ist es nicht das richtige Werkzeug für unser Problem hier. Es ist auch zu "anders" und passt nicht
        //      zu den anderen Kontrollstrukturen die wir kennen lernen. Es soll jedoch der Name im Kopf behalten werden für die Zukunft.
    }
}
