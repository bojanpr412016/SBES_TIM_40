using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Manager;
using System.Data;
using System.Data.SQLite;
using TheatreService;

namespace User
{

    public class User : ChannelFactory<ITheatreService>, ITheatreService, IDisposable
    {
        ITheatreService factory;
        DBAccess db = new DBAccess();

        public User(NetTcpBinding binding, EndpointAddress address)
            : base(binding, address)
        {
            /// cltCertCN.SubjectName should be set to the client's username. .NET WindowsIdentity class provides information about Windows user running the given process
            string cltCertCN = Manager.Formatter.ParseName(WindowsIdentity.GetCurrent().Name);

            this.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.Custom;
            this.Credentials.ServiceCertificate.Authentication.CustomCertificateValidator = new ClientCertValidator();
            this.Credentials.ServiceCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;

            /// Set appropriate client's certificate on the channel. Use CertManager class to obtain the certificate based on the "cltCertCN"
            this.Credentials.ClientCertificate.Certificate = CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, cltCertCN);



            factory = this.CreateChannel();
        }
        public string nazivKorisnika()
        {
            string naziv = Manager.Formatter.ParseName(WindowsIdentity.GetCurrent().Name);
            return naziv;
        }

        public void Dispose()
        {
            if (factory != null)
            {
                factory = null;
            }

            this.Close();
        }

        public void dodajPredstavu(Predstava p)
        {
            try
            {
                factory.dodajPredstavu(p);
                Console.WriteLine("Dodao");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }
        }

        public void izmeniPopust()
        {
            throw new NotImplementedException();
        }

        public void izmeniPredstavu(int u, object x)
        {
            try
            {
                //Debugger.Launch();
                factory.izmeniPredstavu(u, x);
                Console.WriteLine("dodao");

            }
            catch (Exception e)
            {

                Console.WriteLine("greska {0}", e.Message);
            }
        }

        public void napraviRezervaciju(int idP, int brKarata)
        {
            try
            {
                Debugger.Launch();
                factory.napraviRezervaciju(idP, brKarata);
            }
            catch (Exception e)
            {

                Console.WriteLine("greska {0}", e.Message);
            }
        }

        public void platiRezervaciju(int idRez, string ime)
        {
            try
            {
                factory.platiRezervaciju(idRez, ime);
            }
            catch (Exception e)
            {
                Console.WriteLine("Greska: {0}", e.Message);
            }
        }


        public void ispisiPredstave()
        {
            try
            {
                factory.ispisiPredstave();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public void dodajKorisnika(Korisnik k)
        {
            try
            {
                factory.dodajKorisnika(k);
            }
            catch (Exception e)
            {
                Console.WriteLine("Greska: {0}", e.Message);
            }
        }
    }
}



