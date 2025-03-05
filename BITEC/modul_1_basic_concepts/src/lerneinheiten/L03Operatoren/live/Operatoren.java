package lerneinheiten.L03Operatoren.live;

import java.util.Random;

public class Operatoren {
    public static void main(String[] args) {
        // Achtung! Typen der Inputs können den Operator ändern!

        // Addition
        System.out.println(35 + 17);

        // Concatenation
        System.out.println("35" + "17");

        Integer first = 35;
        Integer second = 17;

        System.out.println(first + second);

        //Arithmetische Operatoren
        System.out.println(5 / 2); // Integer Division
        System.out.println(5 % 2); // der Rest einer Integer Divitions, auch Modulo genannt

        System.out.println(5 / 2.); // "kommazahl" Division
        System.out.println(5 / 2.f);
        System.out.println(5 / 2.F);
        System.out.println(5 / 2.d);
        System.out.println(5 / 2.D);

        // Logische Operatoren
        Boolean userBerechtigt = true; // Atom
        Boolean userAktiv = true; // das nächste Atom usw.
        Boolean ausweisHinterlegt = true;
        Boolean alterErlaubt = true;

        // und logik
        Boolean zugangIstErlaubt = userBerechtigt && userAktiv && ausweisHinterlegt && alterErlaubt;

        Boolean genugPunkte = false;
        Boolean genugGeld = false;

        Boolean genugZeit = true;

        // oder logik mit und logik
        Boolean spielWeiter = ( genugPunkte || genugGeld ) && genugZeit;

        // Vergleichsoperatoren
        String meineAntwort = "82 wäre es gewesen";
        Boolean vergleich = meineAntwort == "82 wäre es gewesen";
        System.out.println(vergleich);

        Integer meineZahl = 10;
        vergleich = meineZahl == 50; // false
        vergleich = meineZahl != 50; // false
        vergleich = meineZahl >= 50;  // false
        vergleich = meineZahl <= 50;  // true
        System.out.println(vergleich);

        vergleich = 10 < meineZahl && meineZahl <= 50; // wenn wir einen Bereich angeben.
        vergleich = meineZahl > 10 && meineZahl <= 50; // oder so. geht auch.
        System.out.println(vergleich);

        vergleich = 0 <= meineZahl && meineZahl <= 10; // wenn wir einen Bereich angeben.
        System.out.println(vergleich);

        Random random = new Random();

        for (int i = 0; i < 1000; i++) {
            System.out.println(random.nextInt(0,2));
        }

        // Beispiel mit allem
        String correctUsername = "admin";
        String correctPassword = "password123";

        String username = "admin";
        String password = "password123";
        Boolean active = true;
        Integer userMessage = 248;
        Integer saltForHash = 145;
        ausweisHinterlegt = true;
        Integer alter = 19;

        System.out.println(userMessage & saltForHash);

        Boolean result =
                active &&
                ausweisHinterlegt &&
                (userMessage & saltForHash) % 2 == 0 &&
                        // Anwendung des Bitweisen & in Kombination mit Modulo 2 um einen "unerwartetes" Ergebnis zu erzeugen. Das Ergebnis ist schwer rückzurechnen.
                        // Es soll das Gefühl eines Hashs mit Salts darstellen welcher für die "Nichtlesbarkeit" von Usernamen und Passwörtern benötigt wird.
                        // Bitweise Operatoren können besser als Masken in Bildern verstanden werden. Siehe Tafel.
                alter >= 18 &&
                username == correctUsername &&
                password == correctPassword;

        System.out.println(result);
    }
}
