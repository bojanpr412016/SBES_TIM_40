using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum TipKorisnika{KORISNIK, SUPERKORISNIK}
    public class Korisnik
    {
        public Korisnik(double popust, string ime, double stanjeRacuna, TipKorisnika tipKorisnika)
        {
            Popust = popust;
            Ime = ime;
            StanjeRacuna = stanjeRacuna;
            this.tipKorisnika = tipKorisnika;
        }

        public double Popust { get; set; }
        public string Ime { get; set; }
        public double StanjeRacuna { get; set; }
        public TipKorisnika tipKorisnika { get; set; }
    }
}
