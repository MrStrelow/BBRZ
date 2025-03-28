```csharp
public class Person
{
    private string name;
    private char nickName;
    private int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
        this.nickName = 'a';
    }

    public Person(char nickName, int age)
    {
        this.nickName = nickName;
        this.age = age;
        this.name = "";
    }

    public int GetAge()
    {
        return age;
    }

    public void SetAge(int age)
    {
        if (age > 0)
            this.age = age;
    }
}
```