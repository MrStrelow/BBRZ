//class programm
//{
//    static void main(string[] args)
//    {

//    }
//}


// oder einfach.... ohne dem hier...

int[] numbers = [5,5,3,1,8,7,2,4];

// (1.) Implementieren das Vertauschen des 1. und 2. Elements (mit index 0 und 1, ohne Schleife)
if (numbers[0] > numbers[1])
{
    int temp = numbers[0];
    numbers[0] = numbers[1];
    numbers[1] = temp;
}

// (2.) Implementiere das Vertauschen des i und i+1 elements, für eine "Bubble".

// (3.) Implementiere das Wiederholen von (2.) für alle "Bubbles" 


Console.WriteLine($"{0 + 1} Paar [{string.Join(",", numbers)}]");