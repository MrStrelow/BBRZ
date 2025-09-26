
// call by value
int a = 5;

void ModifyCallByValue(int number) // ich kopiere argument in den parameter
{
    number = number + 5;
    // number += 5;
}

ModifyCallByValue(a);

Console.WriteLine(a);

// call by reference
a = 5;

void ModifyCallByReference(ref int number) // ich arbeite direkt mit a, nur unter den namen number.
{
    number = number + 5;
    // number += 5;
}

ModifyCallByReference(ref a);

Console.WriteLine(a);

// Anwendung: Try - Methoden
string alter = "25";

int umgewandeltesAlter = int.Parse(alter);
Console.WriteLine(umgewandeltesAlter);

bool worked = int.TryParse(alter, out int umgewandeltesAlterTry);
Console.WriteLine(umgewandeltesAlterTry);

// gefangen solange es nicht funktioniert
while (!int.TryParse(alter, out umgewandeltesAlterTry))
{
    Console.WriteLine("ok für immer");
}

Console.WriteLine(umgewandeltesAlterTry);