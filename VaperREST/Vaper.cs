using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaperREST
{
    public class Vaper
    {

        //PROPERTIES
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Aroma { get; set; }
        public double Effekt { get; set; }
        public string Butik { get; set; }
        public int Uge { get; set; }

        //DEFAULT CONSTRUCTOR
        public Vaper()
        {

        }

        //CONSTRUCTOR MED ARGUMENTER
        public Vaper(int id, string navn, string aroma, double effekt, string butik, int uge)
        {
            Id = id;
            Navn = navn;
            Aroma = aroma;
            Effekt = effekt;
            Butik = butik;
            Uge = uge;
        }

        //TOSTRING
        public override string ToString()
        {
            return $"ID: {Id}, Navn: {Navn}, Aroma: {Aroma}, Effekt: {Effekt}, Butik: {Butik}, Uge: {Uge}";
        }

    }
}