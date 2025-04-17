package lerneinheiten.L09SchleifenFor.live;

import java.util.Scanner;

public class A05MusterDiamantFortgeschrittenKompaktSpitz {
    public static void main(String[] args) {

// Wir können den Code stark verkürzen wenn wir uns den **Abstand** der aktuellen Spalte
// ``int abstandZurMitteSpalte = Math.abs(groesseSpielfeld - 1 - spalte);`` und Zeile den Diagonalen ausrechnen
// ``int abstandZurMitteZeile = Math.abs(groesseSpielfeld - 1 - zeile);``. Hier ist ``zeile`` der Zählindex der äußeren Schleife, ``spalte`` 
// der Zählindex der inneren Schleife und ``Math.abs()`` der absolute Wert einer Zahl (heißt Vorzeichen weg). Siehe Bild unten.
// Dieser **Abstand** von z.B. dem grünen Viereck zu den roten Diagonalen ist jeweils 2. Es ist auch der **Abstand** des 
// violetten Vierecks 2. Wenn wir diese Abstände ausrechnen können, schaffen wir eine ähnliche **Bedingung**
// wie ``zeile >= spalte`` für die "Trennlinie" der Dreiecke zu finden?
//        
// * Überlege nun für die orangen Vierecke was ist der summierte Abstand von ``abstandZurMitteSpalte + abstandZurMitteZeile`` zu der roten Diagonale?* Dieser ist hier immer 4. * Wie rechne ich jedoch aus dass **4** so eine spezielle zahl hier ist? Es scheint die ``groesseSpielfeld - 1`` zu sein.
// * Was ist nun die Bedingung dass wir **auf** dieser orangen linie sind?
// * Was ist nun die Bedingung dass wir **innerhalb** dieser orangen linie sind?
// * Was ist nun die Bedingung dass wir **innerhalb** udn **auf** dieser orangen linie sind?

//🔹🔹🔹🔹🟥🔹🔹🔹🔹
//🔹🔹🔹🟨🟥🟨🔹🔹🔹
//🔹🔹🟨⬜🟥⬜🟩🔹🔹
//🔹🟨⬜⬜🟥⬜⬜🟨🔹
//🟥🟥🟥🟥🟥🟥🟥🟥🟥
//🔹🟨⬜⬜🟥⬜⬜🟨🔹
//🔹🔹🟪⬜🟥⬜🟨🔹🔹
//🔹🔹🔹🟨🟥🟨🔹🔹🔹
//🔹🔹🔹🔹🟥🔹🔹🔹🔹

        // userinput
        Scanner scanner = new Scanner(System.in);
        System.out.print("Gib die größe des Musters ein [zahl]: ");
        Integer groesseSpielfeld = scanner.nextInt();

        // mustergenerierung
        int breite = 2 * groesseSpielfeld - 1;

        for (int zeile = 0; zeile < breite; zeile++) {
            for (int spalte = 0; spalte < breite; spalte++) {

                // abstand zur mitte berechnen
                int abstandZurMitteZeile = Math.abs(groesseSpielfeld - 1 - zeile);
                int abstandZurMitteSpalte = Math.abs(groesseSpielfeld - 1 - spalte);

                // sind innerhalb der Raute sind
                if (abstandZurMitteSpalte + abstandZurMitteZeile <= groesseSpielfeld - 1) {
                    System.out.print("⬜");
                } else {
                    System.out.print("🔹");
                }
            }
            System.out.println();
        }
    }
}
