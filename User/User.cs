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

namespace User
{
 
        public class User : ChannelFactory<ITheatreService>, ITheatreService, IDisposable
        {
            ITheatreService factory;

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

            public void dodajPredstavu()
            {
                try
                {
                    Debugger.Launch();
                    factory.dodajPredstavu();

                }
                catch (Exception e)
                {

                    Trace.TraceInformation(e.Message);
                }
            }

            public void izmeniPopust()
            {
                throw new NotImplementedException();
            }

            public void izmeniPredstavu()
            {
                throw new NotImplementedException();
            }

            public void napraviRezervaciju()
            {
                throw new NotImplementedException();
            }

            public void platiRezervaciju()
            {
                throw new NotImplementedException();
            }
        }

    }

