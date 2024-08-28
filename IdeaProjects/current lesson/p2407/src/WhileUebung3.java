public class WhileUebung3 {
    public static void main(String[] args) {
//        Schreiben Sie eine While-Schleife, die von 10 bis 1 alle Zahlen im Format "10-9-8-7-6-5-4-3-2-1"
//        ausgibt.
//        - Speichern Sie hierbei die Zahl 10 in der Konstante *bound*
//        - Ändern Sie nun bound auf 100

        // ohne format
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

    }
}
