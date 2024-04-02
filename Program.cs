using System.IO;
using OOPKONTAKT.Classes;

namespace OOPKONTAKT
{
    class Program
    {
        static void Main(string[] args)
        {           
            try
            {
                Kontakt kontakt = new Kontakt();
                string pathKontakt = @"X:\c#\oopkontakt\Files\kontaktlar.txt";
                string pathIsm = @"X:\c#\oopkontakt\Files\ismlar.txt";            
                while(true)
                {
                    System.Console.WriteLine("0.exit\n1.Kontakt qo'shish\n2.Kontakt o'chirish\n3.Kontaktlarni ko'rish\n4.Kontaktni tahrirlash\n5.Kontakt bosh harfi bilan ko'rish");
                    System.Console.Write("tanlang: ");
                    string tanlang = Console.ReadLine();
                    if(tanlang == "0")
                    {
                        break;
                    }
                    else if(tanlang == "1")
                    {
                        Console.Write("ism: ");
                        string ism = Console.ReadLine();
                        Console.Write("nomer(+siz): ");
                        string nomer = Console.ReadLine();
                        Kontakt kontakt1 = new Kontakt(ism, nomer);
                        kontakt1.addContact(pathIsm,pathKontakt);
                    }
                    else if(tanlang == "2")
                    {
                        kontakt.showContact(pathIsm,pathKontakt);
                        System.Console.Write("ism: ");
                        string ism = Console.ReadLine();
                        
                        kontakt.deleteContact(ism, pathIsm, pathKontakt);
                    }
                    else if(tanlang == "3")
                    {                        
                        kontakt.showContact(pathIsm,pathKontakt);
                    }
                    else if(tanlang == "4")
                    {
                        kontakt.showContact(pathIsm,pathKontakt);
                        System.Console.Write("ism: ");
                        string ism1 = Console.ReadLine();
                        kontakt.editContact(ism1,pathIsm,pathKontakt);                        
                    }
                    else if(tanlang == "5")
                    {
                        kontakt.showContact(pathIsm, pathKontakt);
                        System.Console.WriteLine("qaysi harf bo'yicha kontakt qidirmoqchisiz");
                        System.Console.Write("harf kiriting: ");
                        char harf = Convert.ToChar(Console.ReadLine());
                        kontakt.showContactName(harf, pathIsm, pathKontakt);
                    }
                }
                            
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
