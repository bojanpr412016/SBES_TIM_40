using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Predstava
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public DateTime Vreme { get; set;}
        public int Sala { get; set; }
        public double CenaKarte { get; set; }

        public Predstava()
        {

        }

        public Predstava(int id, string naziv, DateTime vreme, int sala, double cenaKarte)
        {
            Id = id;
            Naziv = naziv;
            Vreme = vreme;
            Sala = sala;
            CenaKarte = cenaKarte;
        }
    }
}
