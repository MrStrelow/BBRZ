Gegeben ist folgendes Muster
```
             x
       0 1 2  3 4  5
    0 🔺🟩🟦🔺🟩🟦
    1 🟩🟦🔺🟩🟦🔺
  y 2 🟦🔺🟩🟦🔺🟩
    3 🔺🟩🟦🔺🟩🟦
    4 🟩🟦🔺🟩🟦🔺
    5 🟦🔺🟩🟦🔺🟩
```
Überlege: 
* Was ist die ``Formel`` für ein *blaues* Feld? 
```csharp
bool blue   = (x + y) % 3 == 2;
```

* Was ist die ``Formel`` für ein *grünes* Feld?
```csharp
bool green  = (x + y) % 3 == 1;
```

* Was ist die ``Formel`` für ein *rotes* Feld?
```csharp
bool red = (x + y) % 3 == 0;
```