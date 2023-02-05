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
        void napraviRezervaciju();
        [OperationContract]
        void platiRezervaciju();
        [OperationContract]
        void ispisiPredstave();
        //[OperationContract]
        //void izmeniVreme();
        //[OperationContract]
        //void izmeniSalu();
        //[OperationContract]
        //void izmeniCenuKarte();

    }
}
