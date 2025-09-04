* Soll ein ``Repository`` von einem ``Service`` aufgerufen werden können?

**Antwort:** Ja. Der Zentrale Einstiegspunkt soll der ``Service`` sein. Dieser soll ``Repositories`` und adnere ``Services`` aufrufen um das gestellte Problem lösen zu können. Dieser bietet die ``Business Logik`` an. Es soll nicht direkt eine Anbindung an ein ``Repository`` von z.B. einem ``Controller`` möglich sein, welcher sich um *http* Endpoints kümmert. Dort sollen Service aufgerufen werden.

* Ein ``DTO`` wird vom verwendet ``Service`` verwendet um mit einer externen Schnittstelle (anderes Programm welches mit dem service unter http kommuniziert) zu kommunizieren.

**Anwort:** Ja. Das ist der Anwendungsfall eines Data Transfer Objects (DTO). Dieses ist leicht serialisierbar und enthält nur die Informationen welche nach außen hin preisgegeben werden sollen. Eine ``Klasse`` *User* hat z.B. eine ``Eigenschaft`` *Sozialversiherungsnummer*. Dieses wird intern benötigt, jedoch braucht die externe Anbindung dies nicht. Deshabl fehlt die *Sozialversicherugsnummer* im ``DTO``.

* Im ``Repository`` wird die *Datenbank* und *I/O* Logik einer ``Entity`` Zentralisiert. Es ist dort möglich ``CRUD`` und kompliziertere Abfragen durchzuführen.

**Antwort:** Ja. Der Sinn eines ``Repositories`` ist die ``Speicherungs und Abfrage Logik`` einer ``Entity`` zu zenralisieren.

* Eine ``Methode ``*A* welche eine andere ``Methode`` *B* mit ``await`` aufruf hat zur Folge, dass *A* als ``async`` gekennzeichnet werden muss.

**Anwort:** Ja. Die Daumenregel ist, es ist eine Kette von ``asynch`` und ``await``. Wenn eine ``Methode`` *B* mit ``await`` aufgerufen wird, muss auch die aufrufende ``Methode`` *A* ``async`` sein, um selst mit ``await`` aufgerufen zu werden.

* Wir verwenden ``Task.WhenAll(myTasks)`` und ``Task.WhenAny(myTasks)`` um nicht nur ``asynchron`` sondern auch ``gleichzeitg`` (concurrent) Code ausühren zu können.

**Antwort:** Ja. Wenn wir die einzelnen Methoden in *myTasks* mit ``await`` aufrufen, dann wird zuerst die erste ``Methode`` in myTasks aufgerufen und wenn diese fertig ist, erst die zweite. Wir sind immer noch asynchron, da wir nicht Rechenressourcen der CPU verschwenden, während wir auf die ``await`` Aufrufe in den ``Methoden`` warten. Unser Proigramm ist jedoch nicht schneller. Dazu verwenden wir *Task.WhenAll* um gleichzeitig die ``Methoden`` auszuführen. **Anmerkung:** Streng genommen müssten wir hier über ``Promises`` sprechen, nicht über ``Methoden``. 