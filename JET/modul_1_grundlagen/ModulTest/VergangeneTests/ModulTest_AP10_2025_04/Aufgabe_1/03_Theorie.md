* a) Was ist der Unterschied zwischen einer ``If-Verzweigung`` und einer ``If-Bedingung``?
> * ``If-Verzweigung``: If mit else
> * ``If-Bedingung``: If ohne else

* b) Gegeben ist eine ``If-Verzweigung`` (if mit else). Was ist die ``logische Formel`` des ``else`` Zweigs, wenn die ``logische Formel`` für den ``if`` Zweig ``alter > 25`` ist?
> Die Negation der ``Bedingung`` im If-Zweig. ``!(alter > 25)``. Hier die Klammern nicht vergessen, da ``logische Operatoren `` *!* stärker als ``Vergleichsoperatoren`` *>* binden. Im Kopf umgeformt ist ``!(alter > 25)`` gleich ``alter <= 25``.


* c) Kann eine ``If-Verzweigung`` das gleiche Verhalten wie mehrere ``If-Bedingungen`` haben? Vergleiche dazu folgenden Code.
```csharp
if (false) 
{
    Console.WriteLine("If-Zweig")
} 
else 
{
    Console.WriteLine("Else-Zweig")
}
```

vs.

```csharp
if (false) 
{
    Console.WriteLine("If-Zweig") // ist jedoch eine If-Bedingung
} 

if (true) 
{
    Console.WriteLine("Else-Zweig") // ist auch eine IF-Bedingung
}
```
> Ja. Beide Programme haben das gleiche Verhalten, wenn diese den gleichen Output produzieren (Fachwort: gleiche operationale Semantik). Wir sehen sie also als "gleich" an. 



