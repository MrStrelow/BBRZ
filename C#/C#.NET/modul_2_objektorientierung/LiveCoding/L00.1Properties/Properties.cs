//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;

//namespace ReferenzUndWertDaten;

//public class ObjectInitializers
//{
//   static void Main(string[] args)
//   {
//       Hund hund = new Hund();
//       hund.Name = "hans";
//       // hund.SetName("hans");

//       Console.WriteLine(hund.Name);
//   }
//}

//public class Hund
//{
//   // FELD!
//   private string _name;

//   // EIGENSCHAFT!
//   public string Name {
//       get => _name;
//       set => _name = value == "hans" ? value : ""; // mit Ausdruck/Expression und Lambda Operator => (einzeilig)
//       // set => _name = value == "hans" ? value : throw new Exception();
//       // in python schreibweise _name = value if value == "hans" else "";

//       //set // mit Anweisun/Statement
//       //{
//       //  if (value == "hans") {
//       //    _name = value; // Das ist ein Methodenaufruf! obwohl es aussieht wie ei Zugriff auf ein Feld.
//       //  }
//       //}
//   }

//   public void SetNames(string val)
//   {
//       if(val == "hans")
//       {
//           //SetNames(val);
//           _name = val;
//       } 
//   }
//}
