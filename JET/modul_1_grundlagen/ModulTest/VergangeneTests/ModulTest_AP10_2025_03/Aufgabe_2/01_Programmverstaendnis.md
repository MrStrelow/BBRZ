Gegeben ist folgendes Muster
```
             x
       0 1 2  3 4  5
    0 🔺🟩🟦🔺🟦🟩
    1 🟩🟦🔺🟦🟩🔺
  y 2 🟦🔺🟦🟩🔺🟩
    3 🔺🟦🟩🔺🟩🟦
    4 🟦🟩🔺🟩🟦🔺
    5 🟩🔺🟩🟦🔺🟦
```
Überlege: 
* Was ist die ``Formel`` für ein *blaues* Feld? 
```csharp
bool blue = (x % 2 == 0 && y % 2 == 0 && (x + y) % 3 != 0) || (x % 2 == 1 && y % 2 == 1 && (x + y) % 3 != 0);
```

* Was ist die ``Formel`` für ein *grünes* Feld?
```csharp
bool green = (x % 2 == 1 && y % 2 == 0 && (x + y) % 3 != 0) || (x % 2 == 0 && y % 2 == 1 && (x + y) % 3 != 0);
```

* Was ist die ``Formel`` für ein *rotes* Feld?
```csharp
bool red = (x + y) % 3 == 0;
```