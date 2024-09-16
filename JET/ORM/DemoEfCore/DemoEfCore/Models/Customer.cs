using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoEfCore.Models;

class Customer

{
    public int Id { get; set; }
    
    // EF-Core erlaubt kein null in der database 
    public string FirstName { get; set; } = null!;
    
    // EF-Core erlaubt kein null in der database
    public string LastName { get; set;} = null!;
    
    // ? attribute ist nullable und deshalb ist auch in der Datenbank null erlaubt.
    public string? Address { get; set; }
    
    // ? attribute ist nullable und deshalb ist auch in der Datenbank null erlaubt.
    public string? Phone { get; set; }

    // ? attribute ist nullable und deshalb ist auch in der Datenbank null erlaubt.
    public string? email;
    public string? Email
    {
        get => email;
        set
        // Suche:   ([a-zA-Z0-9\.\-_]{2,})@([a-zA-Z0-9\-\._]+[a-zA-Z]{2,3})
        // Ersetze: $2@$1
        {// gmail.com@mathias.cammerlander
            Regex checkMail = new Regex(@"^[a-zA-Z0-9\.\-_]{2,}@([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,3}$");

            if (value != null)
            {
                if (checkMail.IsMatch(value))
                {
                    email = value;
                }
                else
                {
                    email = null;
                    // throw new ArgumentException("not an Email");
                }
            }
            else
            {
                email = null;
            }
            
        }
    }

    // wenn eine Collection (LinkedList, HashSet, Queue, Stack, ObservableCollection, ...)
    // verwendet wird, wird eine 1 zu n Beziehung erstellt.
    public ICollection<Order> Orders { get; set; } = null!;

}
