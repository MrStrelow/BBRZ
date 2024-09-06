import java.nio.DoubleBuffer;
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
        Double budget = null;

        Double kostenUnterkunft;
        Double kostenVerpflegung;
        Double kostenTransport;
        Double kostenAktivitaeten;

        Integer anzahlFamilienmitglieder = null;

        String[] familienMitglieder = null;
        Double[] beitragVonFamilienMitglieder = null;

        Double gesamterBeitragVonFamilienmitglieder = 0.0;
        Boolean benutzerMussBudgetAnpassen = false;
        Boolean benutzerWillKostenÄndern = false;

        Boolean benutzerWillUnterkunftÄndern;
        Boolean benutzerWillVerpflegungÄndern;
        Boolean benutzerWillTransportÄndern;
        Boolean benutzerWillAktivitaetÄndern;


        // Logik:
        Boolean benutzerWillNeueEingabe = true;

        while (benutzerWillNeueEingabe) {
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
            anzahlFamilienmitglieder = sc.nextInt();
    //        familienMitglieder = new String[sc.nextInt()]; // geht auch so.

            familienMitglieder = new String[anzahlFamilienmitglieder];
            beitragVonFamilienMitglieder = new Double[anzahlFamilienmitglieder];

            for (int i = 0; i < anzahlFamilienmitglieder; i++) {
                beitragVonFamilienMitglieder[i] = 0.0;
            }

            Double[] kosten = {kostenUnterkunft, kostenVerpflegung, kostenTransport, kostenAktivitaeten};

            Double gesamteAusgaben = berechneGesamtausgaben(kosten);
            Double verbleibendesBudget = berechneVerbleibendesBudget(budget, gesamteAusgaben);

            System.out.println("Budget: ");
            System.out.println("\t\t\t\t\t" + budget);
            System.out.println("Kosten:");
            System.out.println("\tUnterkunft:\t\t" + kostenUnterkunft);
            System.out.println("\tVerpflegung:\t" + kostenVerpflegung);
            System.out.println("\tTransport:\t\t" + kostenTransport);
            System.out.println("\tAktivitäten:\t" + kostenAktivitaeten);
            System.out.println("________________________________________");
            System.out.println("Verbleibende Budget: " + verbleibendesBudget);

            if (budget >= gesamteAusgaben) {
//                benutzerWillNeueEingabe = false;
                break;

            } else {

                Boolean weitereAenderungenNotwendig = true;

                do {
                    System.out.print("Budget reicht nicht aus! Wollen Sie bestehende Kosten ändern oder alles neu eingeben? [ändern/neu]: ");

                    String entscheidung;
                    Boolean nochmalsFragen = false;

                    // Unterschied zur While Schleife:
                    // - wir führen einmal den Block (also das in den geschwungenen Klammern {}) immer ein mal aus.
                    //  Am Ende überprüfen wir eine boolesche Variable, ob diese True ist,
                    //      - wenn ja, dann wiederhole die Schleife
                    //      - wenn nein, dann beende diese.


                    // Wenn der user einen Blödsinn eingibt, dann soll nochmal gefragt werden,
                    // was der User wirklich eingeben will.
                    do {
                        entscheidung = sc.next().toLowerCase();

                        switch (entscheidung) {
                            case "ändern" -> {
                                benutzerWillKostenÄndern = true;

                                benutzerWillNeueEingabe = false;
                                nochmalsFragen = false;
                            }
                            case "neu" -> {
                                benutzerWillNeueEingabe = true;

                                benutzerWillKostenÄndern = false;
                                nochmalsFragen = false;
                            }
                            default -> {
                                nochmalsFragen = true;
                                System.out.print("Fehlerhafte Eingabe: Bitte nochmals eingeben: ");
                            }
                        }

                    } while (nochmalsFragen);

                    if (benutzerWillKostenÄndern) {

                        System.out.println("Welche kosten sollen geändet werden?");
                        nochmalsFragen = false;

                        do {
                            System.out.println("Budget: ");
                            System.out.println("\t\t\t\t\t" + budget);
                            System.out.println("Kosten:");
                            System.out.println("\tUnterkunft:\t\t" + kostenUnterkunft);
                            System.out.println("\tVerpflegung:\t" + kostenVerpflegung);
                            System.out.println("\tTransport:\t\t" + kostenTransport);
                            System.out.println("\tAktivitäten:\t" + kostenAktivitaeten);
                            System.out.println("________________________________________");
                            System.out.println("Verbleibende Budget: " + verbleibendesBudget);

                            System.out.print("Eingabe [unterkunft/verpflegung/transport/aktivitäten]: ");
                            entscheidung = sc.next().toLowerCase();

                            switch (entscheidung) {
                                case "unterkunft" -> {
                                    System.out.print("Kosten Unterkunft: " + kostenUnterkunft + " ändern: ");
                                    kostenUnterkunft += sc.nextDouble();
                                }
                                case "verpflegung" -> {
                                    System.out.print("Kosten Verpflegung: " + kostenVerpflegung + " ändern: ");
                                    kostenVerpflegung += sc.nextDouble();
                                }
                                case "transport" -> {
                                    System.out.print("Kosten Transport: " + kostenTransport + " ändern: ");
                                    kostenTransport += sc.nextDouble();
                                }
                                case "aktivitäten" -> {
                                    System.out.print("Kosten Aktivitäten: " + kostenAktivitaeten + " ändern: ");
                                    kostenAktivitaeten += sc.nextDouble();
                                }
                                default -> {
                                    nochmalsFragen = true;
                                    System.out.print("Fehlerhafte Eingabe: Bitte nochmals eingeben: ");
                                }
                            }

                        } while (nochmalsFragen);


                        kosten = new Double[]{kostenUnterkunft, kostenVerpflegung, kostenTransport, kostenAktivitaeten};

                        gesamteAusgaben = berechneGesamtausgaben(kosten);
                        verbleibendesBudget = berechneVerbleibendesBudget(budget, gesamteAusgaben);

                        if (budget >= gesamteAusgaben) {
                            System.out.println("Budget deckt nun die Kosten!");
                            weitereAenderungenNotwendig = false;

                        } else {
                            System.out.println("Budget deckt die Kosten nicht! Bitte weitere Änderungen vornehmen.");
                            weitereAenderungenNotwendig = true;
                        }

                    } else {
                        weitereAenderungenNotwendig = false;
                        benutzerWillNeueEingabe = true;
                    }

                } while (weitereAenderungenNotwendig);

                if (!weitereAenderungenNotwendig && !benutzerWillNeueEingabe) {
                    break;
                }
            }
        }

        // Wir wiederholen die schleife für immer. Deswegen true bei der while-Schleife.
        // Aber ganz unten ist eine if-Verzweigung, welche, wenn wir genug budget haben, die Schleife verlässt.
        // Das machen wir mit break;

        Boolean nameWurdeSchonEingegeben = false;

        while (true) {
    //        for (int i = 0; i < familienMitglieder.length; i++) { // ist das gleiche
            System.out.println("Bitte gib deinen Beitrag ein: ");

            for (int i = 0; i < anzahlFamilienmitglieder; i++) {

                if (!nameWurdeSchonEingegeben) {
                    System.out.print("Bitte den Namen vom " + (i + 1) + ". Familienmitglied eingeben: ");
                    familienMitglieder[i] = sc.next();
                }

                System.out.print("Bitte den Beitrag von: " + familienMitglieder[i] + " eingeben: ");
                beitragVonFamilienMitglieder[i] += sc.nextDouble();
                gesamterBeitragVonFamilienmitglieder += beitragVonFamilienMitglieder[i];
//                beitragVonFamilienMitglieder[i] = sc.nextDouble(); // VARIANTE 2.
            }

            nameWurdeSchonEingegeben = true;

            if( gesamterBeitragVonFamilienmitglieder >= budget ) {
                break;

            } else {
                System.out.println("Beitrag reicht nicht aus.");
                System.out.println("Es fehlen noch " + (budget - gesamterBeitragVonFamilienmitglieder) + "€.");
                System.out.println("Teile nun den fehlenden Betrag auf! Das geld aus der 1. Runde wurde gespeichert");
//                gesamterBeitragVonFamilienmitglieder = 0.0; //VARIANTE 2: ohne akkumulierende Beiträge
            }
        }

        // Ausgabe:
        //  um Inhalt des Arrays mit dem Auge überprüfen zu können
//        System.out.println(Arrays.asList(familienMitglieder)); oder
        System.out.println("#################### ENDE ####################");
        System.out.println("Budget: " + budget);
        System.out.println("Beitrag jedes Familienmitglieds:");
        System.out.println(Arrays.toString(familienMitglieder));
        System.out.println(Arrays.toString(beitragVonFamilienMitglieder));

    }

    public static Double berechneGesamtausgaben(Double[] kosten) {
        // [10., 20., 10., 10., 10.]
        Double gesamteAusgaben = 0.0;

        for (int i = 0; i < kosten.length; i++) {
            gesamteAusgaben += kosten[i];
        }

        return gesamteAusgaben;
    }


    public static Double berechneVerbleibendesBudget(Double budget, Double gesamtausgaben) {
        return budget - gesamtausgaben;
    }

}
