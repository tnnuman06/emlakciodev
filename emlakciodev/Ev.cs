using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emlakciodev
{

    public class Ev
    {
        public string OdaSayisi { get; set; }
        public string KatNumarasi { get; set; }
        public string Alani { get; set; }
        public string Ucreti { get; set; }
        public string Depozito { get; set; }
        public string Semt { get; set; }

        public Ev(string odaSayisi, string katNumarasi, string alani, string ucreti, string depozito = "", string semt = null)
        {
            OdaSayisi = odaSayisi;
            KatNumarasi = katNumarasi;
            Alani = alani;
            Ucreti = ucreti;
            Depozito = depozito;
            Semt = semt;
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Depozito)
                ? $"{OdaSayisi} oda, {KatNumarasi}. kat, {Alani} m2, {Ucreti} TL fiyat,{Semt} Semtinde"
                : $"{OdaSayisi} oda, {KatNumarasi}. kat, {Alani} m2, {Ucreti} TL kira, {Depozito} TL depozito,{Semt} Semtinde";
        }
    }

}

