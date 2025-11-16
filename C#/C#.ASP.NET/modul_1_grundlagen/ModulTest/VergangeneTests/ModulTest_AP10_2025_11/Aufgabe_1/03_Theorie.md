1) Wann soll die ``http-Methode`` *get* und wann ``http-Methode`` *post* verwendet werden?
    * *get*: Wenn wir bereits existierende Daten abfragen (Das *R* in ``CRUD``. Ein Vergleich wäre ein *select* mit *from* und *where* in ``SQL`` bzw. ``LINQ``)
    * *post*: Wenn wir neue Daten anlegen wollen. (Das *C* in ``CRUD``. Ein Vergleich wäre ein *insert-into* bzw. *select-into* in ``SQL`` und ein *_context.Orders.Add(new Order());* mit *await _context.SaveChangesAsync();* in ``EF-Core``)
2) Wie kann die ``http-Methode`` *delete* als ``Request`` an einen ``Server`` gesendet werden?
    * mit ``javascript`` mit *const response = fetch(..., method: "DELETE", headers: ...)*, da es keinen Weg in ``html`` gibt einen solschen ``http-requst`` zu schicken.
3) Ist der **standardmäßige** Anwendugnsfall von javascript ``client-seitig`` oder ``server-seitig``?
    * ``client-seitig``. Es gibt aber auch Außnahmen wie ``node.js`` und der serverseitige teil von ``react`` bzw. ```next.js``.
4) Ist der **standardmäßige** Anwendugnsfall von ``asp.net`` ``client-seitig`` oder ``server-seitig``?
    * ``server-seitig``. Es gibt aber auch Außnahmen wie ``Blazor WebAssembly`` (*WASM*). Hier wird ``C#-Code`` (ähnlich wie javascript) direkt im Browser des Clients ausgeführt.
5) Wo werden bei einem ``Request`` der ``http-Methode`` *post* die ``Parameter`` übermittelt?
    * Im ``Request-Body``. z.B. steht dort dann *sort=ascending&mode=dark*. Der Body kann verschlüssel werden.
6) Wo werden bei einem ``Request`` der ``http-Methode`` *get* die ``Parameter`` übermittelt?
    * Als ``Query-String`` in der ``URL``. z.B. *https://meineApplication.com/Kunden?sort=ascending&mode=dark*.
7) Was bedeutet der ``Serverstatus`` *200*, *300*, *400* und *500*? Wo kann ich diese finden?
    * **200er (Erfolg)**: Es ist kein Fehler passiert. z.B. bei einem ``http-request`` mit der ``http-methode`` *get*.
    * **300er (Redirect)**: Wir leiten an eine andere Seite weiter. z.B. nach einem ``http-request`` mit der ``http-methode`` *post*. Wenn wir die ``Ressource`` mit *post* angelegt haben, wollen wir wieder auf eine passende website weitergeleitet werden. z.B. mit *RedirectToAction(nameof(Index))* im ``Controller``. Dieser ``Redirect`` erzeugt einen **neuen** ``http-request`` mit der ``http-methode`` *get* und gibt ein ``html`` file im ``Response-Body`` zurück.
    * **400er-Gruppe (Client-Fehler)**: Wenn der ``Client`` eine falsche url angibt, dann hat die Antwort den ``Status-Code`` *400* bzw. *403* wenn der Client nicht berechtigt ist die ``Ressource`` zu sehen.
    * **500er-Gruppe (Server-Fehler)**: Wenn unsere ``Middle-ware`` keine ``Exceptions`` fängt und auf Error.cshtml umleitet, dann hat die Antwort den ``Status-Code`` *50x*.