using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Rezervacija
    {
        public Rezervacija(int id, int idPredstave, DateTime vremeRezervacije, int kolicinaKarata, bool stanjeRezervacije)
        {
            Id = id;
            IdPredstave = idPredstave;
            VremeRezervacije = vremeRezervacije;
            KolicinaKarata = kolicinaKarata;
            StanjeRezervacije = stanjeRezervacije;
        }

        public Rezervacija() { }

        public int Id { get; set; }
        public int IdPredstave { get; set; }
        public DateTime VremeRezervacije { get; set; }
        public int KolicinaKarata { get; set; }

        public bool StanjeRezervacije { get; set; }
        
    }
}
