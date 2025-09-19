using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise.ue1 {
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsRegistered { get; set; }

        public User(string name, int age, bool isRegistered)
        {
            Name = name;
            Age = age;
            IsRegistered = isRegistered;
        }
    }

    public class Program
    {
        public static void ProcessUserGuardClause(User user)
        {
            if (user == null)
            {
                Console.WriteLine("❗User is null.");
                return;
            }

            if (!user.IsRegistered)
            {
                Console.WriteLine("❗User is not registered.");
                return;
            }

            if (user.Age < 18)
            {
                Console.WriteLine("❗User is too young.");
                return;
            }

            Console.WriteLine("✅User is processed.");
        }

        public static void ProcessUserNestedIf(User user)
        {
            if (user != null)
            {
                if (user.IsRegistered)
                {
                    if (user.Age >= 18)
                    {
                        Console.WriteLine("✅User is processed.");
                    }
                    else
                    {
                        Console.WriteLine("❗User is too young.");
                    }
                }
                else
                {
                    Console.WriteLine("❗User is not registered.");
                }
            }
            else
            {
                Console.WriteLine("❗User is null.");
            }
        }

        public static void CallUe1()
        {
            User hans = new User("Hans", 35, false);
            User alice = new User("Alice", 25, true);

            Console.WriteLine("\n############### 1 ###############");
            Console.WriteLine("--- Testing original nested-if method ---");
            Program.ProcessUserGuardClause(hans);
            Console.WriteLine("\n--- Testing new Guard Clause method Variante 1---");
            Program.ProcessUserNestedIf(hans);

            Console.WriteLine("--- Testing original nested-if method ---");
            Program.ProcessUserGuardClause(alice);
            Console.WriteLine("\n--- Testing new Guard Clause method Variante 1---");
            Program.ProcessUserNestedIf(alice);
        }
    }
}

namespace Exercise.ue2
{
    public class User
    {
        public bool IsActive { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public DateTime SubscriptionEnd { get; set; }

        // Achtung! Wir haben hier 2 Endpunkte ("User is active,..." und "User is active, a senior,...")
        // welche wir als sinnvoll erachten. 
        // Versuche zerst die 2 Zweige des Programmes mit Endpunkten getrennt zu behandeln und verbinde diese nachher.

        public void ProcessUserNestedIf()
        {
            if (IsActive)
            {
                if (Age > 18)
                {
                    if (Age < 65)
                    {
                        if (!string.IsNullOrEmpty(Email))
                        {
                            if (SubscriptionEnd > DateTime.Now)
                            {
                                Console.WriteLine("✅User is active, adult, has a valid email, and an active subscription.");
                            }
                            else
                            {
                                throw new InvalidOperationException("❗User's subscription has expired.");
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException("❗User email is missing.");
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(Email))
                        {
                            if (SubscriptionEnd > DateTime.Now)
                            {
                                Console.WriteLine("✅User is active, a senior, has a valid email, and an active subscription.");
                            }
                            else
                            {
                                throw new InvalidOperationException("❗Senior user's subscription has expired.");
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException("❗Senior user email is missing.");
                        }
                    }
                }
                else
                {
                    throw new InvalidOperationException("❗User must be older than 18.");
                }
            }
            else
            {
                throw new InvalidOperationException("❗User is not active.");
            }
        }

        public void ProcessUserGuardClause()
        {
            // ❗Ungewünschte Zustände 
            // Guard Clauses für allgemeine Prüfungen
            if (!IsActive)
                throw new InvalidOperationException("❗User is not active.");

            if (Age <= 18)
                throw new InvalidOperationException("❗User must be older than 18.");


            // Weitere Bedingungen je nach Altersgruppe: User
            if (Age < 65 && string.IsNullOrEmpty(Email))
                throw new InvalidOperationException("❗User email is missing.");

            if (Age < 65 && string.IsNullOrEmpty(Email))
                throw new InvalidOperationException("❗Senior user email is missing.");

            // Weitere Bedingungen je nach Altersgruppe: Senior
            if (Age >= 65 && SubscriptionEnd <= DateTime.Now)
                throw new InvalidOperationException("❗User's subscription has expired.");

            if (Age >= 65 && SubscriptionEnd <= DateTime.Now)
                throw new InvalidOperationException("❗Senior user's subscription has expired.");

            // ✅ gewünschte Zustände
            // Beide Endpunkte müssen wir in einer IF-Verzweigung trennen. Auch ein switch möglich.
            // Wir werden später Konzepte (ein paar Monate) anschauen welche uns erlauben solche Abfragen potentiell noch
            // eleganter zu gestalten (Pattern matching mit switch und when).
            if (Age < 65)
            {
                Console.WriteLine("✅User is active, adult, has a valid email, and an active subscription.");
            }
            else
            {
                Console.WriteLine("✅User is active, a senior, has a valid email, and an active subscription.");
            }
        }

        // Achtung! Nur als Beispiel! Wenn möglich immer gewünschte von ungewünschten Zuständen Trennen.
        public void ProcessUserGuardClauseMixedWithNested()
        {
            // ❗Ungewünschte Zustände
            // Guard Clauses für allgemeine Prüfungen
            if (!IsActive)
                throw new InvalidOperationException("❗User is not active.");

            if (Age <= 18)
                throw new InvalidOperationException("❗User must be older than 18.");


            // Weitere Bedingungen je nach Altersgruppe
            if (Age < 65)
            {
                // ❗Ungewünschte Zustände
                if (string.IsNullOrEmpty(Email))
                    throw new InvalidOperationException("❗User email is missing.");

                if (SubscriptionEnd <= DateTime.Now)
                    throw new InvalidOperationException("❗User's subscription has expired.");

                // ✅ gewünschter Zustand
                Console.WriteLine("✅User is active, adult, has a valid email, and an active subscription.");
            }
            else
            {
                // ❗Ungewünschte Zustände
                if (string.IsNullOrEmpty(Email))
                    throw new InvalidOperationException("❗Senior user email is missing.");

                if (SubscriptionEnd <= DateTime.Now)
                    throw new InvalidOperationException("❗Senior user's subscription has expired.");

                // ✅ gewünschter Zustand
                Console.WriteLine("✅User is active, a senior, has a valid email, and an active subscription.");
            }
        }

        // Rein logisch gesehen ist die folgende Methode nicht komplett gleich dem Programm mit dem verschachtelten if.
        // Wir haben jedoch hier in diesem Programm uns die Freiheit genommen, und Fehlermeldungen von Senior und User zusammenzufassen,
        // wenn z.B. die mail Adresse fehlt.
        public void ProcessUserKuerzerAberNichtGanzKorrekt()
        {
            // Guard Clauses für allgemeine Prüfungen
            if (!IsActive)
                throw new InvalidOperationException("User is not active.");

            if (Age <= 18)
                throw new InvalidOperationException("User must be older than 18.");

            // Wir ignorieren hier die Senior vs. User Ausgabe beim Werfen der Exception.
            if (string.IsNullOrEmpty(Email))
                throw new InvalidOperationException("User email is missing.");

            // Wir ignorieren hier die Senior vs. User Ausgabe beim Werfen der Exception.
            if (SubscriptionEnd <= DateTime.Now)
                throw new InvalidOperationException("User's subscription has expired.");

            // Weitere Bedingungen je nach Altersgruppe
            if (Age < 65)
            {
                Console.WriteLine("User is active, adult, has a valid email, and an active subscription.");
            }
            else
            {
                Console.WriteLine("User is active, a senior, has a valid email, and an active subscription.");
            }
        }

        public static void CallUe2()
        {
            User user = new User
            {
                IsActive = true,
                Age = 30,
                Email = "example@domain.com",
                SubscriptionEnd = DateTime.Now.AddMonths(1)
            };

            try
            {
                Console.WriteLine("\n############### 2 ###############");
                Console.WriteLine("--- Testing original nested-if method ---");
                user.ProcessUserNestedIf();
                Console.WriteLine("\n--- Testing new Guard Clause method Variante 1---");
                user.ProcessUserGuardClause();
                Console.WriteLine("\n--- Testing new Guard Clause method Variante - mixed---");
                user.ProcessUserGuardClauseMixedWithNested();
                Console.WriteLine("\n--- Testing new Guard Clause method Variante - einfacher, aber theoretisch nicht ganz korrekt---");
                user.ProcessUserKuerzerAberNichtGanzKorrekt();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

namespace Exercise.ue3
{
    using System.Text;

    public class Berg
    {
        public bool IstGefährlich { get; set; }
        public int höhe { get; set; }
    }


    public class Bergführer
    {
        // Eigenschaften / Felder
        public bool IsActive { get; set; }
        public int Age { get; set; }
        public string MedicalClearanceCertificate { get; set; }
        public DateTime CertificationExpiry { get; set; }
        public int TourCount { get; set; }

        // Hat-Beziehungen
        public Berg BergRoute { get; set; }

        public void ValidateGuide()
        {
            if (IsActive)
            {
                if (Age >= 21)
                {
                    if (!string.IsNullOrEmpty(MedicalClearanceCertificate))
                    {
                        if (CertificationExpiry > DateTime.Now)
                        {
                            if (BergRoute.IstGefährlich)
                            {
                                if (TourCount >= 50 && TourCount <= 200)
                                {
                                    Console.WriteLine("✅ Bergführer hat zwischen 50 und 200 Touren. Ein weiterer erfahrener Guide ist erforderlich, um diese Route zu bewältigen.");
                                }
                                else if (TourCount > 200)
                                {
                                    Console.WriteLine("✅ Bergführer hat mehr als 200 Touren. Dieser Guide darf die Route alleine führen.");
                                }
                                else
                                {
                                    throw new InvalidOperationException("❗ Bergführer hat zu wenig Erfahrung für diese Route.");
                                }
                            }
                            else
                            {
                                if (BergRoute.höhe > 5000)
                                {
                                    Console.WriteLine("✅ Berg ist zu hoch. Ein weiterer erfahrener Guide ist erforderlich, um diese Route zu bewältigen.");
                                }
                                else
                                {
                                    Console.WriteLine("✅ Bergführer darf die Tour durchführen.");
                                }
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException("❗ Die Zertifizierung des Bergführers ist abgelaufen.");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("❗ Bergführer besitzt kein medizinisches Freigabezertifikat.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("❗ Bergführer muss älter als 21 Jahre sein.");
                }
            }
            else
            {
                throw new InvalidOperationException("❗ Bergführer ist nicht aktiv.");
            }
        }

        public void ValidateGuideGuardClause()
        {
            // ❗Ungewünschte Zustände
            if (!IsActive)
                throw new InvalidOperationException("❗ Bergführer ist nicht aktiv.");

            if (Age < 21)
                throw new InvalidOperationException("❗ Bergführer muss älter als 21 Jahre sein.");

            if (string.IsNullOrEmpty(MedicalClearanceCertificate))
                throw new InvalidOperationException("❗ Bergführer besitzt kein medizinisches Freigabezertifikat.");

            if (CertificationExpiry <= DateTime.Now)
                throw new InvalidOperationException("❗ Die Zertifizierung des Bergführers ist abgelaufen.");

            if (BergRoute.IstGefährlich && TourCount < 50)
            {
                throw new InvalidOperationException("❗ Bergführer hat zu wenig Erfahrung für diese Route.");
            }
                
            // ✅Gewünschte Zustände
            if (BergRoute.IstGefährlich)
            {
                if (TourCount < 50)
                    throw new InvalidOperationException("❗ Bergführer hat zu wenig Erfahrung für diese Route.");

                if (TourCount > 200)
                {
                    Console.WriteLine("✅ Bergführer hat mehr als 200 Touren. Dieser Guide darf die Route alleine führen.");
                }
                else // Covers TourCount between 50 and 200
                {
                    Console.WriteLine("✅ Bergführer hat zwischen 50 und 200 Touren. Ein weiterer erfahrener Guide ist erforderlich, um diese Route zu bewältigen.");
                }
            }
            else
            {
                if (BergRoute.höhe > 5000)
                {
                    Console.WriteLine("✅ Berg ist zu hoch. Ein weiterer erfahrener Guide ist erforderlich, um diese Route zu bewältigen.");
                }
                else
                {
                    Console.WriteLine("✅ Bergführer darf die Tour durchführen.");
                }
            }
        }
        
        public static void CallUe3()
        {
            Bergführer guide = new Bergführer
            {
                IsActive = true,
                Age = 35,
                MedicalClearanceCertificate = "ValidCertificate",
                CertificationExpiry = DateTime.Now.AddMonths(12),
                TourCount = 150,
                BergRoute = new Berg { IstGefährlich = true, höhe = 4000 }
            };

            try
            {
                Console.WriteLine("\n############### 3 ###############");
                Console.WriteLine("--- Testing original nested-if method ---");
                guide.ValidateGuide();
                
                Console.WriteLine("\n--- Testing new Guard Clause method ---");
                guide.ValidateGuideGuardClause();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }
        }
    }
}

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        Exercise.ue1.Program.CallUe1();
        Exercise.ue2.User.CallUe2();
        Exercise.ue3.Bergführer.CallUe3();
    }
}