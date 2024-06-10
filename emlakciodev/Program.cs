using emlakciodev;
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nEmlakçı Uygulaması");
            Console.WriteLine("1. Kiralık Ev");
            Console.WriteLine("2. Satılık Ev");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                IslemYap(new EvYonetimi("kiralik_evler.txt"), true);
            }
            else if (secim == "2")
            {
                IslemYap(new EvYonetimi("satilik_evler.txt"), false);
            }
            else
            {
                Console.WriteLine("Lütfen istenilen değerleri giriniz.Program sonlandırılıyor...");
                break;
            }
            Console.WriteLine("Lütfen kararınızı girin: (tamam/ devam)");
            string karar = Console.ReadLine().ToLower();
            switch (karar)
            {
                case "tamam":
                    Environment.Exit(0);
                    break;
                case "devam":
                    Main();
                    break;
                default:
                    Console.WriteLine("Hatalı giriş yapıldı. Tekrar dene.");
                    break;
            }
        }
    }

    static void IslemYap(EvYonetimi evYonetimi, bool kiralikMi)
    {
        Console.WriteLine("\n1. Kayıtlı Evleri Görüntüleme");
        Console.WriteLine("2. Yeni Ev Girişi");
        Console.Write("Seçiminiz: ");
        string islemSecim = Console.ReadLine();

        if (islemSecim == "1")
        {
            List<Ev> evler = evYonetimi.DosyadanEvleriOku();
            EvBilgileriniGoster(evler);
        }
        else if (islemSecim == "2")
        {
            YeniEvGirisi(evYonetimi, kiralikMi);
        }
        else
        {
            Console.WriteLine("Geçersiz seçim.");
        }
        Console.ReadKey();
    }

    static void EvBilgileriniGoster(List<Ev> evler)
    {
        foreach (var ev in evler)
        {
            Console.WriteLine(ev);
        }
    }

    static void YeniEvGirisi(EvYonetimi evYonetimi, bool kiralikMi)
    {
        Console.Write("Evin oda sayısı: ");
        string odaSayisi = Console.ReadLine();
        Console.Write("Evin kat numarası: ");
        string katNumarasi = Console.ReadLine();
        Console.Write("Evin alanı: ");
        string alani = Console.ReadLine();
        Console.Write("Evin fiyatı: ");
        string ucreti = Console.ReadLine();
        Console.Write("Evin semti: ");
        string semt = Console.ReadLine();

        Ev yeniEv;
        if (kiralikMi)
        {
            Console.Write("Evin depositosu: ");
            string depozitosu = Console.ReadLine();
            yeniEv = new Ev(odaSayisi, katNumarasi, alani, ucreti, depozitosu,semt);
        }
        else
        {
            yeniEv = new Ev(odaSayisi, katNumarasi, alani, ucreti,semt);
        }

        

        evYonetimi.DosyayaEvleriYaz(yeniEv);
        Console.WriteLine("Girilen ev bilgileri dosyaya kaydedildi.");
    }
}