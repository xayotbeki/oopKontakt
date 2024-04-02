namespace OOPKONTAKT.Classes
{
    public class Kontakt
    {
        public string Ism { get; set; }
        public string Nomer { get; set; }
        public Kontakt()
        {
            
        }
        public Kontakt(string ism, string nomer)
        {
            Ism = ism;
            Nomer = nomer;
        }

        public void addContact(string pathIsm, string pathKontakt)
        {
            using(var w = File.AppendText(pathIsm))
            {
                w.WriteLine($"{Ism}");
            }
            using(var w = File.AppendText(pathKontakt))
            {
                w.WriteLine($"+{Nomer}");
            }
            Console.WriteLine("kontakt muvoffaqiyatli qo'shildi✅");
        }
        public void deleteContact(string ism, string pathIsm, string pathKontakt)
        {
            string[] ismlar = File.ReadAllLines(pathIsm);
            string[] kontaklar = File.ReadAllLines(pathKontakt);
            List<string> newIsmlar = new List<string>();
            List<string> newKontaktlar = new List<string>();
            
            int i = 0;
            while(i<ismlar.Length)
            {
                if(ism == ismlar[i])
                {
                    int ind = Array.IndexOf(ismlar, ism);
                    // System.Console.WriteLine(ind);
                    for (int j = 0; j < ismlar.Length; j++)
                    {
                        if(ismlar[j] != ism)
                        {
                            newIsmlar.Add(ismlar[j]);
                            newKontaktlar.Add(kontaklar[j]);
                        }
                        else if(ismlar.Length == 1)
                        {
                            File.Delete(pathIsm);
                            File.Delete(pathKontakt);
                            using(var w = File.AppendText(pathIsm))
                            {
                                w.WriteLine("");
                            }
                            using(var w = File.AppendText(pathKontakt))
                            {
                                w.WriteLine("");
                            }
                        }                        
                    }
                }            
                i+=1;
            }
            if(newIsmlar.Count() != 0)
            {
                File.Delete(pathIsm);
                File.Delete(pathKontakt);
                for (int k = 0; k < newIsmlar.Count(); k++)
                {                    
                    using(var w = File.AppendText(pathIsm))
                    {
                        w.WriteLine($"{newIsmlar[k]}");
                    }
                    using(var w = File.AppendText(pathKontakt))
                    {
                        w.WriteLine($"{newKontaktlar[k]}");
                    }
                }
                System.Console.WriteLine("muvoffaqiyatli o'chirildi");
            }
        }
        public void showContact(string pathIsm, string pathKontakt)
        {
            string[] ismlar = File.ReadAllLines(pathIsm);
            string[] kontaklar = File.ReadAllLines(pathKontakt);
            if(ismlar.Length != 0)
            {
                System.Console.WriteLine("Kontaklar.....");
                for(int i=0; i<ismlar.Length; i++)
                {
                    if(ismlar[i] != "" && kontaklar[i] != "")
                    {
                        System.Console.WriteLine($"{ismlar[i]} => {kontaklar[i]}");
                    }                
                }
            }
            else
            {
                System.Console.WriteLine("Kontakt bo'sh");
            }       
        }
        public void editContact(string ism, string pathIsm, string pathKontakt)
        {
            string[] ismlar = File.ReadAllLines(pathIsm);
            string[] kontaklar = File.ReadAllLines(pathKontakt);
            List<string> newIsmlar = new List<string>();
            List<string> newKontaktlar = new List<string>();
            int index = Array.IndexOf(ismlar, ism);

            System.Console.WriteLine($"{ismlar[index]} => {kontaklar[index]}");
            System.Console.WriteLine("nimani tahrirlamoqchisiz ism yoki nomer");
            System.Console.Write("1.ism\n2.nomer\ntanlang: ");
            string tanlang = Console.ReadLine();
                            
            
            if(tanlang == "1")
            {               
                System.Console.Write("ism: ");
                string ism1 = Console.ReadLine();

                for(int j=0; j<ismlar.Length; j++)
                {
                    if(j == index)
                    {
                        newIsmlar.Add(ism1);
                        newKontaktlar.Add(kontaklar[j]);
                    }
                    else
                    {
                        newIsmlar.Add(ismlar[j]);
                        newKontaktlar.Add(kontaklar[j]);
                    }
                }                
            }
            else if(tanlang == "2")
            {
                System.Console.Write("nomer: ");
                string nomer = Console.ReadLine();

                for(int j=0; j<kontaklar.Length; j++)
                {
                    if(j == index)
                    {
                        newKontaktlar.Add(nomer);
                    }
                    else
                    {
                        newKontaktlar.Add(kontaklar[j]);
                    }
                }
            }
            
            if(newIsmlar.Count() != 0)
            {
                File.Delete(pathIsm);
                File.Delete(pathKontakt);
                for (int k = 0; k < newIsmlar.Count(); k++)
                {                    
                    using(var w = File.AppendText(pathIsm))
                    {
                        w.WriteLine($"{newIsmlar[k]}");
                    }
                    using(var w = File.AppendText(pathKontakt))
                    {
                        w.WriteLine($"{newKontaktlar[k]}");
                    }
                }
                System.Console.WriteLine("muvoffaqiyatli tahrirlandi");
            }

        }
        public void showContactName(char harf, string pathIsm, string pathKontakt)
        {
            string[] ismlar = File.ReadAllLines(pathIsm);
            string[] kontaklar = File.ReadAllLines(pathKontakt);
            if(ismlar.Length != 0)
            {
                int i = 0;
                while(i<ismlar.Length)
                {
                    if(ismlar[i][0] == harf)
                    {
                        System.Console.WriteLine($"{ismlar[i]} => {kontaklar[i]}");
                    }
                    i++;
                }
            }
            else
            {
                System.Console.WriteLine("Kontakt bo'sh");
            }  
        }
    
    }
}

// kontakt qo'shish, ✅
//  kontaktni o'chirish, ✅
// barcha kontaktlarni ko'rish ✅
// kontaktni tahrirlash, ✅
// va kontaktni nomi bo'yicha ko'rish ✅