//class programm
//{
//    static void main(string[] args)
//    {

//    }
//}


// oder einfach.... ohne dem hier...

int[] numbers = [5,3,1,6];

// (3.) Implementiere das Wiederholen von (2.) für alle "Bubbles" 
for (int j = 0; j < numbers.Length - 1; j++)
{ 
// (2.) Implementiere das Vertauschen des i und i+1 elements, für eine "Bubble".
    for ( int i = 0; i < numbers.Length - 1 - j; i++ )
    {
        // (1.) Implementieren das Vertauschen des 1. und 2. Elements (mit index 0 und 1, ohne Schleife)
        if (numbers[i] > numbers[i+1])
        {
            int temp = numbers[i];
            numbers[i] = numbers[i+1];
            numbers[i + 1] = temp;

        }

        Console.WriteLine($"{i + 1} Paar [{string.Join(",", numbers)}]");
    }
    Console.Write("\n");
}




