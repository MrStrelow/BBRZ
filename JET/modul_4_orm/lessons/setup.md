# Entity Framework Core:

## Setup
In Visual Studio neues console project erstellen. Dann im NuGet package manager (rechts klick auf projektmappe):
  * EntityFrameworkCore.SQLServer
  * EntityFrameworkCore.Design
  * EntityFrameworkCore.Tools
installieren.

### SQL Server
[express version](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) -> basic installation

connection string / Verbindungszeichenfolge kopieren und in VS verwenden.
z.B. für Microsoft Authentication
**Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;**

### Download SSMS
um außerhalb von vs studio navigieren zu können installiere ssms [(Sql Server Management Studio)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16&redirectedfrom=MSDN).


### SSMS - Anmelden mit sa user
zuerst:
* aktiviere sa user: server kontextmenü -> properties -> securitiy -> SQL Server and Windows Auth.
* aktiviere sa user in security folder -> Logins -> sa -> kontextmenü properties -> status -> enabled
	 * kontextmenü properties -> status: passwort festlegen.
 * restart msssql server im taskmanager (kann admin benötigen, deshalb suche taskmanager -> rechtsklick und als admin ausführen)

###  In VS Code- Anmelden mit sa user
Ansicht -> Server Explorer -> mit Datenbank verbinden -> Microsoft SQL Server (SqlClient) -> Wenn fehlende Packete festgestellt werden, diese installieren.
Danach:
* Servername: siehe SSMS - kontextmenü properties auf server und Name kopieren, und in VS einfügen.
* SQL authentification:
	* user: sa
	* password: "dein vergebenes pw"
	* database: demodb


# EF Core verwenden
## In EF Core - Anmelden mit sa user
generiere [hier](https://www.aireforge.com/tools/sql-server-connection-string-generator) den connection string aufgrund der infos aus der installation.
z.B. 
**Data Source=C432-LT-A7A3\SQLEXPRESS;Initial Catalog=demodb;User ID=sa;Password=*************;Trust Server Certificate=True**
Verwende diesen String im *DbContext*
**(Achtung nicht üblich! Secure local storage verwenden!)**

## Setup for CRUD der Tabellen
Für weitere befehle in der pm console (extras -> NuGet Packet Manager -> Console)
get-help entitiyframework eingeben. 
Wir schauen uns:
* Add-Migration InitialCreate
* Update-Database

an.

### Model Folder erstellen
erstelle folder mit namen Model. Erstelle Domain Klassen hier (z.B. keine Service Klasse, sondern eine welche teil der Domain, also deiner Welt ist, welche gebaut wird)

### Context erstellen
erstelle folder data welcher eine Klasse enthält, welche von DBContext ableitet.
* Hier werden DbSets erstellt welche quasi die Tabellen sind.
* Hier gibt es 2 wichtige Methoden:
	* OnConfiguration (durch ef core sql package): optionsBuilder.UseSqlServer um connection string der db zu übergeben. 
	* OnModelCreating: um Beziehungen genauer zu modellieren. 
		* z.B. explizite "n to m" relationship.

### Add-Migration InitialCreate
im NuGet console **Add-Migration InitialCreate** eingeben. Dies erzeugt Mapping von OOP elementen zu Datenbank elementen. Dies ist im Folder Migrations ersichtlich.

Danach ist eine Klasse **InitialCreate** im folder migrations ersichtlich. Diese ist eine unterklasse von migration und besitzt dadurch eine up und down methode.
* **up**: Wenn die Migration InitialCreate noch nicht angewandt wurde, wird die up Methode ausgeführt.
* **down**: Wenn die Migration InitialCreate bereits angewandt wurde und nun rückgängig gemacht werden soll, wird die down Methode ausgeführt.

Es kann auch eineSQL-Skript erstellt aus einer Migration Klasse erstellt werden, falls dies gewünscht ist.  Dieses erlaubt genau zu sehen, was genau bei der Erstellung der Tabellen ausgeführt wird.
Diese wird mit dem **script-migration** command erzeugt.

### Update-Database
um den generierten code umzusetzen, gib **Update-Database** ein um diese auf den SQL Server zu spielen.
Schau dazu in das SSMS oder im VS database connection explorer nach. 

Wenn verschiedene Migrations erstellt wurden, z.B. eine welche zusätzliche Felder nachträglich der Tabelle/Klasse hinzufügt, dann kann diese durch weiteres ausführen des Commands hinzugefügt werden. Die Timestamps im Namen helfen hier um die "Reihenfolge" zu bestimmen.

Falls eine Migration wieder Rückgängig gemacht werden soll, ist das Command "Update-Database -Migration 20240904222713_AddEmail" zu verwenden. Hier gehen wir davon aus, dass diese Migration bereits angewandt wurde. Hier erkennt EF Core ob es bereits verwendet oder nicht verwendet wurde. Ein weiteres Ausführen würde diese Migration wieder hinzufügen. 

Die Version der Datenbank, welche Migration also angewandt wurde, ist auch in der Tabelle "EFMigratoinsHistory"

Um alles auf den Ursprungszustand zurückzusetzen, kann "Update-Database -Migration 0" verwendet werden.

### Visualisierung
erweiterungen/extensions -> manage -> EF Core Power Tools -> 

## Mapping von Views

## Mapping von Funktionen

## Mapping von Prozeduren

## DB First
TODO