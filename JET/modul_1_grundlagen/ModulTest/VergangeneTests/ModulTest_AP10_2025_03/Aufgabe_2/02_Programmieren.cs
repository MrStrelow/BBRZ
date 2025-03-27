using System.Text;

Console.OutputEncoding = Encoding.UTF8;
int dimension = 8;

string blueSquare = "🟦";
string greenSquare = "🟩";
string redTriangle = "🔺";

string[,] field = new string[dimension, dimension];

for (int y = 0; y < dimension; y++)
{
    for (int x = 0; x < dimension; x++)
    {
        // wenn wir in "für ein feld der farbe x, sind zeilen und spalten haben gerade oder ungerade" denken
        //bool blue = (x % 2 == 0 && y % 2 == 0 && (x + y) % 3 != 0) || (x % 2 == 1 && y % 2 == 1 && (x + y) % 3 != 0);
        //bool green = (x % 2 == 1 && y % 2 == 0 && (x + y) % 3 != 0) || (x % 2 == 0 && y % 2 == 1 && (x + y) % 3 != 0);
        //bool red = (x + y) % 3 == 0;

        // oder einfacher wenn wir alles in (x + y) % 3 bzw. (x + y) % 2 denken
        bool blue = (x + y) % 2 == 0 && (x + y) % 3 != 0;
        bool green = (x + y) % 2 == 1 && (x + y) % 3 != 0;
        bool red = (x + y) % 3 == 0;

        if (blue)
            field[y, x] = blueSquare;
        else if (green)
            field[y, x] = greenSquare;
        else if (red)
            field[y, x] = redTriangle;
    }
}

Print(field);

void Print(string[,] field)
{
    for (int y = 0; y < field.GetLength(0); y++)
    {
        for (int x = 0; x < field.GetLength(0); x++)
        {
            Console.Write(field[y, x]);
        }
        Console.WriteLine();
    }
}