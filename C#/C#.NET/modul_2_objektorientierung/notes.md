JET TODO:
* modul1:
    * mutability vs. immutability in the context of dictionaries. immutability is required for keys.
        * immuteable
        * string builder as mutable
* modul2: 
    * named arguments vs. positional argumetns
    * properties 
    * nullable ? and null coalesce ?? / ??=
    * strings as special reference type:
        * local string table for constants
        * reference type for anything else
    * datenkapselung
        * server client communication (delegate the call from client to server)
        * own immutable classes: make all fields readonly or properties using init instead of set. 
        * shallow vs. deep mutability - init keyword is shallow - need IReadOnlyCollection string Roles { get; init; } and call Roles = roles.ToList().AsReadOnly();
    * polymorphism
        * redesign first s.t. hamster is a record - then use tuple/records classes for immutabble data carriers. 
        TODO: where do i need a key to be a record class in my dictionary?

    * merke dir den bug von hamster:
        * mehrere hamster auf einem fleck.