using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Korisnik
    {
        public Korisnik(double popust, string ime, double stanjeRacuna)
        {
            Popust = popust;
            Ime = ime;
            StanjeRacuna = stanjeRacuna;
        }
        public Korisnik() { }

        public double Popust { get; set; }
        public string Ime { get; set; }
        public double StanjeRacuna { get; set; }
    }
}
