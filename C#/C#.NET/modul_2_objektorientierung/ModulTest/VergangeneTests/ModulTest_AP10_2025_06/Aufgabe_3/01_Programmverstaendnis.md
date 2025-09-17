a) Begründe warum die Anwendung von ``Referenzdaten`` wie hier mit *string* in den 4 Fällen ein verschiedenes Verhalten hat. Gehe dazu 
* auf die Idee von ``Referenzdaten`` ein (was liegt meistens im ``Stack``, was liegt im ``Heap``) und 
    * (Daumenregel) Erste Referenz (Pfeil) liegt am Stack, die Objekte auf die gezeigt wird, am heap.

* wie werden ``Referenzen`` grafisch dargstellt? 
    * Ffeil ist Referenz. Kugeln sind Objekte auf denen Rerferenzen zeigen.

* Sparen wir uns Speicher wenn alle ``Referenzen`` auf ein Ziel zeigen? 
    * Ja. Denn wir haben nur ein Objekt am heap, egal wie viele Objekte wir erzeugen. Nicht 100 mal, wenn wir 100 Objekte anlegen.

* Ist *string* ein ``Wertdatentyp`` oder ein ``Referenzdatentyp``? 
    * ``Referenzdatentyp``, jedoch ist dieser immutable (kann keine werte ändern, nur neu anlegen).
    
* Es gibt bei einem *string* eine spezielle Speicherung, diese heißt ``internal string pool``, welche bei Version 2 verwendet wird. Wie wirkt sich dieser ``internal string pool`` in unserem Programm aus?
    * Der Compiler merkt sicht, dass wir 100 mal den gleichen String verwenden (wenn dieser z.B. readonly ist oder ``string a = "🐹";`` als Wert zugewiesen wird, nicht z.B. von außen wie ein Datenbankzugriff). Dadurch haben wir den Fall dass alle Referenzen auf das gleiche Objekt zeigen und wir Speicher sparen.