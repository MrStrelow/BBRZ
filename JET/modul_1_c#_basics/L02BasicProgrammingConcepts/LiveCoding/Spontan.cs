class Spontan
{
    static void Main(string[] args)
    {
        string test = "5";
        try
        {
            int number = int.Parse(test);
            Console.WriteLine(number);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fehler blabla");
            // logge den fehler, mit details von dem aufrufer, welches betriebssystem, wann war die anfrage an den server, ...
        }

        if( int.TryParse(test, out int result) )
        {
            Console.WriteLine("hat funktioniert");
        }
        else
        {
            Console.WriteLine("Fehler");
        }
    }
}
