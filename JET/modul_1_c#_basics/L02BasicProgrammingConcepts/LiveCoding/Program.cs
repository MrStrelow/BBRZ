//class MyMainClass
//{
//    static void Main(string[] args)
//    {

//        // 1.) userinput

//        // 2.) schachbrett erstellen
//        int size = 6;
//        string whiteSquareCode = "\u2588";
//        string blackSquareCode = '\u2591'.ToString();
//        string[,] board = new string[size, size];


//        //for (int y = 0; y < brett.GetLength(0); y++)
//        //{
//        //    for (int x = 0; x < brett.GetLength(1); x++)
//        //    {
//        //        if (x % 2 == 0)
//        //        {
//        //            if (y % 2 == 0)
//        //            {
//        //                brett[y, x] = blackSquareCode;
//        //            }
//        //            else
//        //            {
//        //                brett[y, x] = whiteSquareCode;
//        //            }
//        //        } 
//        //        else
//        //        {
//        //            if (y % 2 == 0)
//        //            {
//        //                brett[y, x] = whiteSquareCode;
//        //            }
//        //            else
//        //            {
//        //                brett[y, x] = blackSquareCode;
//        //            }
//        //        }
//        //    }
//        //}


//        for (int y = 0; y < board.GetLength(0); y++)
//        {
//            for (int x = 0; x < board.GetLength(1); x++)
//            {
//                //if ( (x % 2 == 0 && y % 2 == 0) || (x % 2 == 1 && y % 2 == 1) )
//                if ((x + y) % 2 == 0)
//                {
//                    board[y, x] = blackSquareCode;
//                }
//                else
//                {
//                    board[y, x] = whiteSquareCode;
//                }
//            }
//        }

//        Console.WriteLine("Bitte Start Koordinaten angeben [y x]: ");
//        string[] userinput = Console.ReadLine().Split(" ");
//        int yStart = int.Parse(userinput[0]);
//        int xStart = int.Parse(userinput[1]);

//        Console.WriteLine("Bitte Ziel Koordinaten angeben [y x]: ");
//        userinput = Console.ReadLine().Split(" ");
//        int yEnd = int.Parse(userinput[0]);
//        int xEnd = int.Parse(userinput[1]);

//        board[yStart, xStart] = "o";
//        board[yEnd, xEnd] = "x";

//        int deltaX = xStart - xEnd;
//        int deltaY = yStart - yEnd;
//        double k = (double) deltaX / deltaY;

//        // TODO: here linie coden
//        for (int i = yStart+1; i < yEnd; i++)
//        {
//            int j = (int) Math.Round(k * i);
//            board[i, j] = "~";
//        }


//        for (int y = 0; y < board.GetLength(1); y++)
//        {
//            for (int x = 0; x < board.GetLength(0); x++)
//            {
//                Console.Write(board[y, x]);
//            }
//            Console.WriteLine();
//        }


//        // 3.) linien zeichnen

//    }
//}