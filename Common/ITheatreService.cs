using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface ITheatreService
    {
        [OperationContract]
        void dodajPredstavu(Predstava p);
        [OperationContract]
        void izmeniPredstavu(int u, object x);
        [OperationContract]
        void izmeniPopust();
        [OperationContract]
        void napraviRezervaciju(int idP, int brKarata);
        [OperationContract]
        void platiRezervaciju(int idRez, string ime);
        [OperationContract]
        void ispisiPredstave();
        [OperationContract]
        void dodajKorisnika(Korisnik k);

    }
}
