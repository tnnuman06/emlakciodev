using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace emlakciodev
{

    public class EvYonetimi
    {
        private string dosyaAdi;

        public EvYonetimi(string dosyaAdi)
        {
            this.dosyaAdi = dosyaAdi;
        }

        public List<Ev> DosyadanEvleriOku()
        {
            List<Ev> evler = new List<Ev>();
            if (File.Exists(dosyaAdi))
            {
                string[] satirlar = File.ReadAllLines(dosyaAdi);
                foreach (var satir in satirlar)
                {
                    string[] bilgiler = satir.Split(',');
                    if (bilgiler.Length == 5)
                    {
                        evler.Add(new Ev(bilgiler[0], bilgiler[1], bilgiler[2], bilgiler[3], bilgiler[4]));
                    }
                    else if (bilgiler.Length == 4)
                    {
                        evler.Add(new Ev(bilgiler[0], bilgiler[1], bilgiler[2], bilgiler[3]));
                    }
                }
            }
            return evler;
        }

        public void DosyayaEvleriYaz(Ev ev)
        {
            using (StreamWriter sw = File.AppendText(dosyaAdi))
            {
                if (string.IsNullOrEmpty(ev.Depozito))
                {
                    sw.WriteLine($"{ev.OdaSayisi},{ev.KatNumarasi},{ev.Alani},{ev.Ucreti},{ev.Semt}");
                }
                else
                {
                    sw.WriteLine($"{ev.OdaSayisi},{ev.KatNumarasi},{ev.Alani},{ev.Ucreti},{ev.Depozito},{ev.Semt}");
                }
            }
        }
    }

}
