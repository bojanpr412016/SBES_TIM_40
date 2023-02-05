using Common;
using Manager;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TheatreService;
using System.Diagnostics;

namespace User
{
    public class Program
    {
        static void Main(string[] args)
        {
            /// Define the expected service certificate. It is required to establish cmmunication using certificates.
            string srvCertCN = "wcfservice2";
            DBAccess db = new DBAccess();


            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;

            /// Use CertManager class to obtain the certificate based on the "srvCertCN" representing the expected service identity.
            X509Certificate2 srvCert = CertManager.GetCertificateFromStorage(StoreName.TrustedPeople, StoreLocation.LocalMachine, srvCertCN);
            EndpointAddress address = new EndpointAddress(new Uri("net.tcp://localhost:9999/Receiver"),
                                      new X509CertificateEndpointIdentity(srvCert));

            User proxy1 = new User(binding, address);
            string cltCertCN = proxy1.nazivKorisnika();

            Console.WriteLine("{0}", cltCertCN);

            X509Certificate2 cltCert = CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, cltCertCN);


            string grupa = CertManager.GetCertificateGroupFromStorage(StoreName.My, StoreLocation.LocalMachine, cltCertCN);

            while (true)
            {
                using (User proxy = new User(binding, address))
                {
                    /// 1. Communication test
                    //proxy.TestCommunication();
                    //DBAccess db = new DBAccess();

                    Console.WriteLine("Odaberite funkciju:\n");
                    Console.WriteLine("1.Dodaj predstavu\n");
                    Console.WriteLine("2.Izmeni predstavu\n");
                    Console.WriteLine("3.Izmeni popust\n");
                    Console.WriteLine("4.Napravi rezervaciju\n");
                    Console.WriteLine("5.Plati rezervaciju\n");

                    int i = Int32.Parse(Console.ReadLine());
                    //string vreme;
                    object t;


                    switch (i)
                    {
                        case 1:
                            if (grupa == "Admin")
                            {
                                Predstava p = new Predstava();

                                //Console.WriteLine("Unesite id predstave:");
                                //p.Id = Int32.Parse(Console.ReadLine());
                                Console.WriteLine("Unesite naziv predstave:");
                                p.Naziv = Console.ReadLine();

                                //Console.WriteLine("Unesite vreme odrzavanja predstave:");
                                //p.Vreme = DateTime.Parse(Console.ReadLine());

                                Console.WriteLine("Unesite broj sale:");
                                p.Sala = Int32.Parse(Console.ReadLine());

                                Console.WriteLine("Unesite cenu karte:");
                                p.CenaKarte = Int32.Parse(Console.ReadLine());

                                //p.Vreme = DateTime.Parse("21/21/21");

                                var v = DateTime.Now.ToString("HH:mm");
                                p.Vreme = DateTime.Parse(v);

                                proxy.dodajPredstavu(p);
                            }
                            else
                            {
                                Console.WriteLine("Nemate pristup ovoj funkciji!'n");
                                Console.WriteLine("Test git");
                            }
                            break;
                        case 2:
                            if (grupa == "Admin")
                            {
                                //proxy.ispisiPredstave();
                                Console.WriteLine("Izaberite ID predstave koju zelite da izmenite.");
                                int u = Int32.Parse(Console.ReadLine());
                                //proxy.izmeniPredstavu(u);
                                Console.WriteLine("Izaberite polje koje zelite da izmenite:");
                                Console.WriteLine("1.Vreme odrzavanja predstave\n2.Sala u kojoj se predstava odrzava\n3.Cena karte za odabranu predstavu");
                                int k = Int32.Parse(Console.ReadLine());
                                switch (k)
                                {
                                    case 1:
                                        Console.WriteLine("Unesite novo vreme odrzavanja predstave(yyyy/MM/dd-hh");
                                        DateTime vreme = DateTime.Parse(Console.ReadLine());
                                        
                                        proxy.izmeniPredstavu(u, vreme);
                                        break;
                                    case 2:
                                        Console.WriteLine("Unesite novi broj sale:");
                                        int r = Int32.Parse(Console.ReadLine());
                                        proxy.izmeniPredstavu(u, r);
                                        break;
                                    case 3:
                                        Console.WriteLine("Unesite novu cenu karte:");
                                        double d = Double.Parse(Console.ReadLine());
                                        proxy.izmeniPredstavu(u, d);
                                        break;
                                    default:
                                        break;
                                }



                                //Predstava p = new Predstava();

                                //proxy.izmeniPredstavu(p);
                            }
                            else
                            {
                                Console.WriteLine("Nemate pristup ovoj funkciji!'n");
                            }
                            break;
                        case 3:
                                if(grupa == "Admin")
                                {                              
                                   
                                }
                                else
                                {
                                    Console.WriteLine("greska");
                                }
                                break;
                        default:
                            break;
                        
                    }

                    
                }
                Console.ReadLine();
            }
            
        
        }
    }
    }

