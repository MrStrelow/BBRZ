import java.util.Scanner;

public class FunktionenErsteSchritte {
    public static void main(String[] args) {
        String dasIstDieRueckgabe = nameMeinerFunktion("da", " dort", 3);
        nameMeinerFuntionOhneRueckgabe("da");
    }

    static String nameMeinerFunktion(String ersterParameter, String zweiterParameter, int dritterParameter) {
        return "Hallo" + ersterParameter;
    }

    static void nameMeinerFuntionOhneRueckgabe(String ersterParameter) {
        System.out.println("hallo" + ersterParameter);
    }

    static void nameMeinerFunktionOhneRueckgabeUndOhneParameter() {
        System.out.println("hallo");
    }
}
