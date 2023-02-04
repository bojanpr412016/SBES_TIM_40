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
        void dodajPredstavu();
        [OperationContract]
        void izmeniPredstavu();
        [OperationContract]
        void izmeniPopust();
        [OperationContract]
        void napraviRezervaciju();
        [OperationContract]
        void platiRezervaciju();

    }
}
