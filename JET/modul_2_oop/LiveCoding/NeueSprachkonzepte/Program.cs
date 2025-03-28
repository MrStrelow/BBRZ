public class Person
{
    // Felder -> Eigenschaften
    public string Name { get; set; }
    private char nickName;
    private int age;

    public Person(string name, int age)
    {
        Name = name;
        this.age = age;
        this.nickName = 'a';
    }

    public Person(char nickName, int age)
    {
        this.nickName = nickName;
        this.age = age;
        Name = "";
    }

    public int GetAge()
    {
        return age;
    }

    public void SetAge(int age)
    {
        //if (age > 0)
            this.age = age;
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Person hans = new Person(name: "hans", age: 1);
        Console.WriteLine(hans.Name);
        hans.Name = "asdf";
        Console.WriteLine(hans.Name);
        //Person hans = new Person(nickName: "asdf", age: 1);
        //Person hans = new Person(age: 1);
    }
}