struct Car
{
    public string Model;
    public int Year;
}

class Program
{
    static void Main(string[] args)
    {
        Car car1;
        car1.Model = "Ford";
        car1.Year = 2023;
        Test();
    }

    static int Test()
    {
        int a = 5;
        return a;
    }
}