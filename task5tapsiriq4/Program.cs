
using System;
using System.IO;

class Program
{
    static string faylAdi = "telebeler.txt";

   
    static void TelebeElaveEt()
    {
        try
        {
            Console.Write("Telebenin ID-sini daxil edin: ");
            string id = Console.ReadLine();

            Console.Write("Telebenin adini daxil edin: ");
            string ad = Console.ReadLine();

            Console.Write("Telebenin yasini daxil edin: ");
            string yas = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(faylAdi, true))
            {
                sw.WriteLine(id + ";" + ad + ";" + yas);
            }

            Console.WriteLine("Telebe ugurla elave edildi!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Xeta: " + ex.Message);
        }
    }

    
    static void HamisiniGoster()
    {
        try
        {
            if (!File.Exists(faylAdi))
            {
                Console.WriteLine("Telebe siyahisi bosdur.");
                return;
            }

            string[] setirler = File.ReadAllLines(faylAdi);

            if (setirler.Length == 0)
            {
                Console.WriteLine("Telebe siyahisi bosdur.");
                return;
            }

            Console.WriteLine("\n===== TELEBE SIYAHISI =====");

            foreach (string setir in setirler)
            {
                string[] melumat = setir.Split(';');

                if (melumat.Length == 3)
                {
                    Console.WriteLine("ID: " + melumat[0]);
                    Console.WriteLine("Ad: " + melumat[1]);
                    Console.WriteLine("Yas: " + melumat[2]);
                    Console.WriteLine("----------------------");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Xeta: " + ex.Message);
        }
    }

    
    static void AdaGoreAxtar()
    {
        try
        {
            if (!File.Exists(faylAdi))
            {
                Console.WriteLine("Axtaris ucun telebe yoxdur.");
                return;
            }

            Console.Write("Axtarilacaq telebenin adini daxil edin: ");
            string axtarilanAd = Console.ReadLine();

            string[] setirler = File.ReadAllLines(faylAdi);

            bool tapildi = false;

            foreach (string setir in setirler)
            {
                string[] melumat = setir.Split(';');

                if (melumat.Length == 3 &&
                    melumat[1].Equals(axtarilanAd, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nTelebe tapildi!");
                    Console.WriteLine("ID: " + melumat[0]);
                    Console.WriteLine("Ad: " + melumat[1]);
                    Console.WriteLine("Yas: " + melumat[2]);

                    tapildi = true;
                }
            }

            if (!tapildi)
            {
                Console.WriteLine("Bu adda telebe tapilmadi.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Xeta: " + ex.Message);
        }
    }

    
    static void Main()
    {
        int secim;

        do
        {
            Console.WriteLine("\n===== TELEBE SIYAHISI =====");
            Console.WriteLine("1. Telebe elave et");
            Console.WriteLine("2. Hamisini goster");
            Console.WriteLine("3. Ada gore axtar");
            Console.WriteLine("4. Cixis");

            Console.Write("Seciminizi daxil edin: ");

            if (!int.TryParse(Console.ReadLine(), out secim))
            {
                Console.WriteLine("Zehmet olmasa duzgun eded daxil edin!");
                continue;
            }

            switch (secim)
            {
                case 1:
                    TelebeElaveEt();
                    break;

                case 2:
                    HamisiniGoster();
                    break;

                case 3:
                    AdaGoreAxtar();
                    break;

                case 4:
                    Console.WriteLine("Proqramdan cixilir...");
                    break;

                default:
                    Console.WriteLine("Yanlis secim! 1-4 arasinda secin.");
                    break;
            }

        } while (secim != 4);
    }
}

