namespace Exercise2;
class Program
{
    static void Main()
    {
        // 1)
        // x und y jeweils int Variblen - diese sind die Positionen der x und y Achse. Siehe Achsen neben den Schachbrett.
        int x = 0;
        int y = 0;

        // 2)
        bool weiß = x % 2 == 0;
        bool schwarz = !weiß;
        // schwarz = x % 2 == 1;

        // weiß = x % 2 != 1;
        // schwarz = x % 2 != 0;

        // 3)
        weiß = (x % 2 == 0 && y % 2 == 0) || (x % 2 == 1 && y % 2 == 1);
        schwarz = !weiß;
        // schwarz = (x % 2 == 1 && y % 2 == 0) || (x % 2 == 0 && y % 2 == 1);

        // 4)
        weiß = (x % 2 == 0 && y % 2 == 0 && (x + y) % 3 != 0) || (x % 2 == 1 && y % 2 == 1 && (x + y) % 3 != 0);
        schwarz = (x % 2 == 1 && y % 2 == 0 && (x + y) % 3 != 0) || (x % 2 == 0 && y % 2 == 1 && (x + y) % 3 != 0);
        bool rot = (x + y) % 3 == 0;

        // 5)
        weiß = (x + y) % 2 == 0;
        schwarz = (x + y) % 2 == 1;

        // 6)
        schwarz = y == 0 || y == 5 || x == 0 || x == 5;
        weiß = !schwarz;

        // 7)
        bool schwarzAußen = y == 0 || y == 5 || x == 0 || x == 5;
        bool schwarzInnen = ((2 <= y && y <= 3) && (x == 2 || x == 3)) || ((2 <= x && x <= 3) && (y == 2 || y == 3));
        schwarz = schwarzAußen || schwarzInnen;

        weiß = ((1 <= y && y <= 4) && (x == 1 || x == 4)) || ((1 <= x && x <= 4) && (y == 1 || y == 4));

        // Tipp: formuliere die weiße Formel und setze schwarz auf !weiß, spart arbeit.
    }
}
