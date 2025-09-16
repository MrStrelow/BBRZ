1) Eine ``Methode`` mit ``Rückgabe`` besitzt eine ``Methodensignatur``. Diese beinhaltet:
    * einen ``Rückgabewert``/``Rückgabetyp``
    * den *Namen* der ``Methode`` und
    * einen oder mehrere ``Parameter``.

Ein Beispiel dafür ist ``double BerechneKuerzesteDistanz(Graph g)``

Was besitzt ein ``Lambda`` Ausdruck nicht, was eine ``Methode`` haben muss? 

**Antwort:** Der *Name* der ``Methode``. Ein ``Lambda`` Ausdruck ist eine Art eine ``Anonyme Methode`` darzustellen. Wenn wir das Wort ``Anonym`` verwenden, fehlt immer *etwas* was beim Normalen vorhanden ist..

2) Ein ``Objekt`` hat als ``Typ`` eine ``Klasse``. Durch dessen ``Klasse`` besitzt das ``Objekt`` ``Mitglieder``. Diese beinhalten:
    * ``Felder (Fields)``/``Eigenschaften (Properties)`` und
    * ``Methoden``

Ein Beispiel dafür ist ``new Kunde { Name = "Manuela", Alter = 36}.BerechneUmsatz();``.

Was besitzt ein ``Anonymes Objekt`` nicht, was ein ``Objekt`` haben muss? Wie kann ein ``Anonymes Objekt`` bei einem ``LINQ`` Ausdruck verwendet werden?

**Hinweis:** Ein *Anonymes Objekt* wird auch *Anonymer Typ* genannt.

**Antwort:** 
* Der *Typ* des ``Objekts`` und die *Methoden* des ``Objekts``. Wenn wir das Wort ``Anonym`` verwenden, fehlt immer *etwas* was beim Normalen vorhanden ist.
* Bei einem ``LINQ`` Ausdruck welcher eine ``Select`` ``Methode`` verwendet.