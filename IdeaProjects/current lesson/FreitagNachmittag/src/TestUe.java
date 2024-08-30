import java.util.Arrays;
import java.util.Scanner;

public class TestUe {
    public static void main(String[] args) {
        // Verwaltung Budget von Familienurlaub:
        // - verschiedene Kostenkategorien
        //  (wie Unterkunft, Verpflegung, Transport und Aktivitäten)
        // - Beiträge mehrerer Familienmitglieder

        // Variablen definieren/deklarieren:
        Scanner sc = new Scanner(System.in);


        // Wir haben drei Möglichkeiten eine Variable zu definieren:
        // - ich weise einen Wert zu.
        // Double budget = 5.0;

        // - ich weise eine Variable zu.
//        Double anotherDouble = 45.0; // hier Wert.
//        Double budget = anotherDouble; // hier Variable.

        // - ich weise einen Wert zu welcher über eine Methode oder einen Operator erzeugt wird.
        // Operator:
//        Double budget = 5. + 3.;
//        Double budget = anotherDouble + anotherDouble;

        // Methode:
//        Double budget = Math.max(3., 7.);
//        Double budget = Math.max(anotherDouble, anotherDouble+2);

        // Wir deklarieren hier eine Variable mit dem Namen "budget".
        Double budget;

        Double kostenUnterkunft;
        Double kostenVerpflegung;
        Double kostenTransport;
        Double kostenAktivitaeten;

        String[] familienMitglieder;
        Double[] beitragVonFamilienMitglieder;

        // Logik:
        System.out.print("Bitte geben Sie Ihr Urlaubsbudget ein: ");
        budget = sc.nextDouble();


        System.out.print("Bitte geben Sie die Kosten für die Unterkunft ein: ");
        kostenUnterkunft = sc.nextDouble();

        System.out.print("Bitte geben Sie die Kosten für die Verpflegung ein: ");
        kostenVerpflegung = sc.nextDouble();

        System.out.print("Bitte geben Sie die Kosten für die Transport ein: ");
        kostenTransport = sc.nextDouble();

        System.out.print("Bitte geben Sie die Kosten für die Aktivitäten ein: ");
        kostenAktivitaeten = sc.nextDouble();


        System.out.print("Bitte geben Sie die Anzahl der Familienmitglieder ein: ");
        Integer anzahlFamilienmitglieder = sc.nextInt();
//        familienMitglieder = new String[sc.nextInt()]; // geht auch so.

        familienMitglieder = new String[anzahlFamilienmitglieder];
        beitragVonFamilienMitglieder = new Double[anzahlFamilienmitglieder];


        Double verbleibendesBudget = budget - kostenUnterkunft - kostenVerpflegung - kostenTransport - kostenAktivitaeten;

        System.out.println("Budget: ");
        System.out.println("\t\t\t\t\t" + budget);
        System.out.println("Kosten:");
        System.out.println("\tUnterkunft:\t\t" + kostenUnterkunft);
        System.out.println("\tVerpflegung:\t" + kostenVerpflegung);
        System.out.println("\tTransport:\t\t" + kostenTransport);
        System.out.println("\tAktivitäten:\t" + kostenAktivitaeten);
        System.out.println("________________________________________");
        System.out.println("Verbleibende Budget: " + verbleibendesBudget);

//        for (int i = 0; i < familienMitglieder.length; i++) { // ist das gleiche
        for (int i = 0; i < anzahlFamilienmitglieder; i++) {
            System.out.print("Bitte den Namen vom " + (i + 1) + ". Familienmitglied eingeben: ");
            familienMitglieder[i] = sc.next();

            System.out.println(Arrays.asList(familienMitglieder));

            System.out.print("Bitte den Beitrag vom " + (i + 1) + " Familienmitglied eingeben: ");
            beitragVonFamilienMitglieder[i] = sc.nextDouble();
        }

        // Ausgabe:


    }
}
