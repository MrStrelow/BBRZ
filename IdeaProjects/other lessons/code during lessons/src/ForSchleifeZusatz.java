public class ForSchleifeZusatz {
    public static void main(String[] args) {

        // Müssen wir immer alles in "einem Block" die komplette Aufgabe lösen? Natürlich nicht. Wenn wir es können
        // ist es gut, es kann aber auch sein, dass es Sinn macht die Aufgabe zu unterteilen egal ob wir sofort diese Lösen könnnen
        // oder nicht.


        // Versuchen wir folgendes Problem zu unterteilen.
        // generiere folgendes Muster:
        //  x---x
        //  -x-x-
        //  --x--
        //  -x-x-
        //  x---x

        // Variante 1 - mit Unterteilung in Schritten
        // beachte die Nummerierung Schritt 1-5!
        System.out.println("~~~~~~~~~ Variante 1 ~~~~~~~~~");
        System.out.println();


        // Schritt 1 - Feld erstellen
        int n = 5;
        String[][] feld = new String[n][n];

        // Schritt 2 - Feld mit "~" befüllen
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                feld[i][j] = "-";
            }
        }

        // Schritt 4 - Feld mit der 1. Diagonale befüllen (links nach rechts)
        // Hier soll erkannt werden, dass wenn wir uns die indices der 1. Diagonale anschauen -> (0,0) (1,1) (2,2) (3,3) (4,4)
        // der Index immer der gleiche für die X und Y-Achse ist. Wir brauchen also nur eine Schleife!
        for (int i = 0; i < n; i++) {
            feld[i][i] = "x";
        }


        // Schritt 5 - Feld mit der 2. Diagonale befüllen (rechts nach links)
        // Hier soll erkannt werden, dass wenn wir uns die indices der 2. Diagonale anschauen -> (0,4) (1,3) (2,2) (3,1) (4,0)
        // der Index von der x achse (j) verkehrt zum Schritt 4 ist. Wir schaffen das wenn "4 minus index" gemacht wird. Oder allgemein n-1-i.
        for (int i = 0; i < n; i++) {
            feld[i][n-1-i] = "x";
        }

        // alternativer Lösung für 5 - hier gibt es mehrere Möglichkeiten (Siehe Tafelbild vom 11.01.2024)
//        for (int i = 0; i < n; i++) {
//            for (int j = n-1; j >= 0; j--) {
//                if (i + j == n-1) {
//                    feld[i][j] = "x";
//                }
//            }
//        }



        // Schritt 3 - Ausgabe
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                System.out.print(feld[i][j]);
            }
            System.out.println();
        }

        // Nun können wir Schritte kombinieren, wenn diese sich anbieten!
        // Z.B das Zeichnen der Diagonale kann in einer gemeinsamen For Schleife gemacht werden (Schritt 4 und 5).

        //        for (int i = 0; i < n; i++) {
        //            feld[i][i] = "x";
        //            feld[i][n-1-i] = "x";
        //        }


        // variante 2
        System.out.println("~~~~~~~~~ Variante 2 ~~~~~~~~~");
        System.out.println();

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {

                if(i == j || i == n-1-j) {
                    System.out.print("x");
                } else {
                    System.out.print("-");
                }

            }
            System.out.println();
        }

    }
}



