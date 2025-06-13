using Serilog;

public class Program
{
    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("../../../log.txt").CreateLogger();

        Log.Verbose("Verbose: heitß sehr ausführlich ist es steht also hier viel text viel details");
        Log.Debug("Debug: hier sind informationen fürs debugging. sehr viele also.");
        Log.Information("Information");
        Log.Warning("Warning");

        try
        {
            test();
        }
        catch (Exception ex)
        {
            Log.Error($"Message: {ex.Message}\nStackTrace: {ex.StackTrace}");
        }

        Log.Error("Error");
        Log.Fatal("Fatal");
        Log.CloseAndFlush();


    }

    static void test()
    {
        throw new Exception("Fehler ist aufgetreten - sehr hilfreich 🙂");
    }
}