class MyMainClass
{
    static void Main(string[] args)
    {

        // 1.) userinput

        // 2.) schachbrett erstellen
        int size = 6;
        string whiteSquareCode = "\u2588";
        string blackSquareCode = '\u2591'.ToString();
        string[,] brett = new string[size, size];


        //for (int y = 0; y < brett.GetLength(0); y++)
        //{
        //    for (int x = 0; x < brett.GetLength(1); x++)
        //    {
        //        if (x % 2 == 0)
        //        {
        //            if (y % 2 == 0)
        //            {
        //                brett[y, x] = blackSquareCode;
        //            }
        //            else
        //            {
        //                brett[y, x] = whiteSquareCode;
        //            }
        //        } 
        //        else
        //        {
        //            if (y % 2 == 0)
        //            {
        //                brett[y, x] = whiteSquareCode;
        //            }
        //            else
        //            {
        //                brett[y, x] = blackSquareCode;
        //            }
        //        }
        //    }
        //}


        for (int y = 0; y < brett.GetLength(0); y++)
        {
            for (int x = 0; x < brett.GetLength(1); x++)
            {
                //if ( (x % 2 == 0 && y % 2 == 0) || (x % 2 == 1 && y % 2 == 1) )
                if ((x + y) % 2 == 0)
                {
                    brett[y, x] = blackSquareCode;
                }
                else
                {
                    brett[y, x] = whiteSquareCode;
                }
            }
        }


        // TODO: here linie coden


        for (int y = 0; y < brett.GetLength(1); y++)
        {
            for (int x = 0; x < brett.GetLength(0); x++)
            {
                Console.Write(brett[y, x]);
            }
            Console.WriteLine();
        }


        // 3.) linien zeichnen

    }
}