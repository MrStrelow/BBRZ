public class WhileUebung3 {
    public static void main(String[] args) {
//        Schreiben Sie eine While-Schleife, die von 10 bis 1 alle Zahlen im Format "10-9-8-7-6-5-4-3-2-1"
//        ausgibt.
//        - Speichern Sie hierbei die Zahl 10 in der Konstante *bound*
//        - Ändern Sie nun bound auf 100

        // Ohne Konstante.
        Integer zaehlvariable = 10;
        final Integer untereGrenze = 1;

        while (zaehlvariable >= untereGrenze) {

            if (zaehlvariable == untereGrenze) {
                System.out.print(zaehlvariable);

            } else {
                System.out.print(zaehlvariable + "-");
            }

            zaehlvariable--;
        }

        System.out.println();

        // Mit Konstante
        final Integer bound = 10;
        zaehlvariable = 0;



//        Schreiben Sie ein Programm, das eine Zahl vom Benutzer einliest und dann die Summe aller Zahlen
//        von 1 bis zur eingegebenen Zahl ausgibt



//        Schreiben Sie ein Programm, das den Benutzer nach einer Zahl fragt und dann die Fakultät dieser
//        Zahl berechnet. Verwenden Sie dazu eine While-Schleife. (Hinweis: Fakultät von 3 = 123 = 6, Fakultät
//        von 4 = 123*4 =24)

    }
}
