package lerneinheiten.L03Operatoren.uebung;

public class Loesung {
    public static void main(String[] args) {
        // Aufgabe
        Integer a = 4;
        Integer b = 3;
        Integer c = 3;
        Double d = 4.5;
        Integer e = 1;

        // a != 4
        System.out.println(a != 4);

        // a > b
        System.out.println(a > b);

        // b == c
        System.out.println(b == c);

        // (b+1) == 4
        System.out.println((b+1) == 4);

        // (a/b) == 1
        System.out.println((a/b) == 1);

        // e < c
        System.out.println(e < c);

        // (b/a) > 0
        System.out.println((b/a) > 0);

        // (a%e) != 0
        System.out.println((a%e) != 0);

        // (a > 0) && (a <= 4)
        System.out.println((a > 0) && (a <= 4));

        // !(a<c)
        System.out.println(!(a<c));

        // 1)
        // x und y jeweils Integer Variblen - diese sind die Positionen der x und y Achse. Siehe Achsen neben den Schachbrett.
        Integer x = 0;
        Integer y = 0;

        // 2)
        Boolean weiß = x % 2 == 0;
        Boolean schwarz = !weiß;
        // schwarz = x % 2 == 1;

        // weiß = x % 2 != 1;
        // schwarz = x % 2 != 0;

        // 3)
        weiß = (x % 2 == 0 && y % 2 == 0) || (x % 2 == 1 && y % 2 == 1);
        schwarz = !weiß;
        // schwarz = (x % 2 == 1 && y % 2 == 0) || (x % 2 == 0 && y % 2 == 1);

        // 4)
        weiß = (x % 2 == 0 && y % 2 == 0 && (x + y) % 3 != 0 ) || (x % 2 == 1 && y % 2 == 1 && (x + y) % 3 != 0);
        schwarz = (x % 2 == 1 && y % 2 == 0 && (x + y) % 3 != 0 ) || (x % 2 == 0 && y % 2 == 1 && (x + y) % 3 != 0);
        Boolean rot = (x + y) % 3 == 0;

        // 5)
        weiß = (x + y) % 2 == 0;
        schwarz = (x + y) % 2 == 1;

        // 6)
        schwarz = y == 0 || y == 5 || x == 0 || x == 5;
        weiß = !schwarz;

        // 7)
        Boolean schwarzAußen = y == 0 || y == 5 || x == 0 || x == 5;
        Boolean schwarzInnen = ((2 <= y && y <= 3) && (x == 2 || x == 3)) || ((2 <= x && x <= 3) && (y == 2 || y == 3));
        schwarz = schwarzAußen || schwarzInnen;

        weiß = ((1 <= y && y <= 4) && (x == 1 || x == 4)) || ((1 <= x && x <= 4) && (y == 1 || y == 4));

        // Tipp: formuliere die weiße Formel und setze schwarz auf !weiß, spart arbeit.
    }
}
