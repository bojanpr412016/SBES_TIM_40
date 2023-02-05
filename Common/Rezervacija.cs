using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum Stanje {NEPLACENA, PLACENA}
    public class Rezervacija
    {
        public Rezervacija(int id, int idPredstave, DateTime vremeRezervacije, int kolicinaKarata)
        {
            Id = id;
            IdPredstave = idPredstave;
            VremeRezervacije = vremeRezervacije;
            KolicinaKarata = kolicinaKarata;
            this.StanjeRezervacije = Stanje.NEPLACENA;
        }

        public Rezervacija() {
            this.StanjeRezervacije = Stanje.NEPLACENA;
        }

        public int Id { get; set; }
        public int IdPredstave { get; set; }
        public DateTime VremeRezervacije { get; set; }
        public int KolicinaKarata { get; set; }

        public Stanje StanjeRezervacije{ get; set; }
        
    }
}
