* a) Welches Gesetz hilft uns `nested (verschachteltes) IF` als `Guard Clause` umzuschreiben? Versuche intuitiv zu erklären wieso.
> de morgan's law
> *verschachtelte If's* sind konzeptionell mit dem ``logischen UND`` und *untereinandergeschriebene If's* + ``early exit`` mit ``logischen ODER`` verbunden. Wir können also das gleiche Muster mit einer ``logischen Formel`` und der ``Anordnung von Ifs`` erzeugen. Durch de morgan's law gibt es eine ``Wahrheitstabelle`` `welche die gleichen Einträge für ``A && B`` und ``!(!A || !B)``. Damit ist das Verhalten beider ``Formeln`` nicht unterscheidbar (äquivalent). Wenn beides somit "gleich" ist, kann ich auch ein *verschachteltes If* als *untereinandergeschriebene If* schreiben welches die Programmlogik beibehält.

* b) Wenn ein verschachteltes IF mehrere `✅ gültige zustände` besitzt, ist dann ein Anwenden einer Guard Clause möglich? Begründe dein Antwort.
> ja
> Wir haben alle `✅ gültige zustände` unter den ``Guards``. Dort muss zwischen den verschiedenen logischen Zuständen unterschieden werden. (Oder wir entscheiden uns diese zusammenzufassen, was jedoch Informationsverlust bedeutet und nicht immer umsetzbar ist.)