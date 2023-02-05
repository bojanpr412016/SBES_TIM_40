using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static TheatreService.TheatreService;

namespace TheatreService
{
    public class TheatreService : ITheatreService
    {
        DBAccess db = new DBAccess();

        int idBr;

        public void dodajKorisnika(Korisnik k)
        {
            using (IDbConnection conn = new SQLiteConnection())
            {
                List<string> korisnici = new List<string>();
                string insertQuery = "INSERT INTO Korisnici (`Ime`,`StanjeRacuna`) VALUES (@Ime,@StanjeRacuna)";
                string selectQuery = "SELECT Ime FROM Korisnici";

                SQLiteDataReader reader;
                SQLiteCommand comm = new SQLiteCommand(selectQuery, db.mySQLiteConnection);

                comm.Connection.Open();
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    korisnici.Add(reader.GetString(0));
                }
                reader.Close();
                comm.Connection.Close();

                SQLiteCommand mySQLiteCommand = new SQLiteCommand(insertQuery, db.mySQLiteConnection);

                mySQLiteCommand.Connection.Open();

                mySQLiteCommand.Parameters.AddWithValue("@Ime", k.Ime);
                mySQLiteCommand.Parameters.AddWithValue("@StanjeRacuna", k.StanjeRacuna);


                mySQLiteCommand.ExecuteNonQuery();

                mySQLiteCommand.Connection.Close();


            }
        }

        public void dodajPredstavu(Predstava p)
        {
            Console.WriteLine("----------------------------------------------------------------");
            using (IDbConnection conn = new SQLiteConnection())
            {
                string insertQuery = "INSERT INTO Predstave (`Naziv`, `Vreme`,`Sala`, `CenaKarte`) VALUES (@Naziv,@Vreme,@Sala,@CenaKarte)";

                SQLiteCommand mySQLiteCommand = new SQLiteCommand(insertQuery, db.mySQLiteConnection);

                mySQLiteCommand.Connection.Open();

                mySQLiteCommand.Parameters.AddWithValue("@Naziv", p.Naziv);
                mySQLiteCommand.Parameters.AddWithValue("@Vreme", p.Vreme);
                mySQLiteCommand.Parameters.AddWithValue("@Sala", p.Sala);
                mySQLiteCommand.Parameters.AddWithValue("@CenaKarte", p.CenaKarte);

                var fInsertResult = mySQLiteCommand.ExecuteNonQuery();

                mySQLiteCommand.Connection.Close();

            }
        }

        public void ispisiPredstave()
        {
            using (IDbConnection conn = new SQLiteConnection())
            {
                string selectQuery = "SELECT * FROM Predstave";
                SQLiteDataReader reader;
                SQLiteCommand comm = new SQLiteCommand(selectQuery, db.mySQLiteConnection);

                comm.Connection.Open();
                reader = comm.ExecuteReader();
                Console.WriteLine($"ID   {reader.GetName(1)} {reader.GetName(2)} {reader.GetName(3)} {reader.GetName(4)}");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)} {reader["Naziv"]} {reader.GetDateTime(2).ToString("yyyy/MM/dd")} {reader["Sala"]} {reader["CenaKarte"]}");
                }

                comm.Connection.Close();
            }
        }

        public void izmeniCenuKarte()
        {
            throw new NotImplementedException();
        }

        public void izmeniPopust()
        {
            throw new NotImplementedException();
        }

        public void izmeniPredstavu(int u, object x)
        {
            using (IDbConnection conn = new SQLiteConnection())
            {
                string selectQuery = "SELECT * FROM Predstave WHERE Id=" + u;

                SQLiteCommand comm = new SQLiteCommand(selectQuery, db.mySQLiteConnection);


                //Predstava p = new Predstava();

                /*using (SQLiteDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetInt32(0)} {reader["Naziv"]} {reader.GetDateTime(2).ToString("yyyy/MM/dd")} {reader["Sala"]} {reader["CenaKarte"]}");
                        p.Naziv = reader.GetString(1);
                        p.Vreme = reader.GetDateTime(2);
                        p.Sala = reader.GetInt32(3);
                        p.CenaKarte = reader.GetFloat(4);
                        break; 
                    }
                }*/

                string updateSala = "UPDATE Predstave SET Sala = @Sala WHERE   Id=" + u;
                string updateVreme = "UPDATE Predstave SET Vreme = @Vreme WHERE   Id=" + u;
                string updateCena = "UPDATE Predstave SET CenaKarte = @CenaKarte WHERE   Id=" + u;

                if (x.GetType() == typeof(int))
                {
                    comm.Connection.Open();
                    comm = new SQLiteCommand(updateSala, db.mySQLiteConnection);
                    comm.Parameters.AddWithValue("@Sala", x);
                    comm.ExecuteNonQuery();
                    comm.Connection.Close();
                }
                else if (x.GetType() == typeof(double))
                {
                    comm.Connection.Open();
                    comm = new SQLiteCommand(updateCena, db.mySQLiteConnection);
                    comm.Parameters.AddWithValue("@CenaKarte", x);
                    comm.ExecuteNonQuery();
                    comm.Connection.Close();
                }
                else if (x.GetType() == typeof(DateTime))
                {
                    comm.Connection.Open();
                    comm = new SQLiteCommand(updateVreme, db.mySQLiteConnection);
                    comm.Parameters.AddWithValue("@Vreme", x);
                    comm.ExecuteNonQuery();
                    comm.Connection.Close();
                }
                else
                    Console.WriteLine("Pogresan format");


                comm.Connection.Close();
            }
        }

        public void napraviRezervaciju(int idP, int brKarata)
        {
            using (IDbConnection conn = new SQLiteConnection())
            {
                Rezervacija r = new Rezervacija();
                string selectQuery = "SELECT Vreme FROM Predstave WHERE Id=" + idP;

                SQLiteCommand comm = new SQLiteCommand(selectQuery, db.mySQLiteConnection);
                DateTime vreme = new DateTime();

                SQLiteDataReader reader;


                comm.Connection.Open();
                reader = comm.ExecuteReader();
                //Console.WriteLine($"ID   {reader.GetName(1)} {reader.GetName(2)} {reader.GetName(3)} {reader.GetName(4)}");
                while (reader.Read())
                {
                    vreme = reader.GetDateTime(0);
                    Console.WriteLine(vreme);
                }
                reader.Close();
                comm.Connection.Close();



                string insertQuery = "INSERT INTO Rezervacije (`IdPredstave`,`VremeRezervacije`, `KolicinaKarata`, `Stanje`) VALUES (@IdPredstave,@VremeRezervacije,@KolicinaKarata,@Stanje)";
                SQLiteCommand mySqliteCommand = new SQLiteCommand(insertQuery, db.mySQLiteConnection);

                mySqliteCommand.Connection.Open();
                mySqliteCommand.Parameters.AddWithValue("@IdPredstave", idP);
                mySqliteCommand.Parameters.AddWithValue("@VremeRezervacije", vreme);
                mySqliteCommand.Parameters.AddWithValue("@KolicinaKarata", brKarata);
                mySqliteCommand.Parameters.AddWithValue("@Stanje", r.StanjeRezervacije);
                mySqliteCommand.ExecuteNonQuery();
                mySqliteCommand.Connection.Close();

            }
        }

        public void platiRezervaciju(int idRez, string ime)
        {
            using (IDbConnection conn = new SQLiteConnection())
            {
                
                //string ime = Manager.Formatter.ParseName(WindowsIdentity.GetCurrent().Name);
                int a = 0;
                int b = 0;
                
                string updateStanje = "UPDATE Korisnici SET StanjeRacuna = @StanjeRacuna WHERE Ime=" + ime;
                string selectQuery = "SELECT IdPredstave,KolicinaKarata FROM Rezervacije WHERE Id=" + idRez;


                int cena = 0;

                SQLiteDataReader reader;
                SQLiteCommand comm = new SQLiteCommand(selectQuery, db.mySQLiteConnection);
                

                comm.Connection.Open();
                reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    a = reader.GetInt32(0);
                    b = reader.GetInt32(1);
                }
                reader.Close();
                comm.Connection.Close();

                //Console.WriteLine("{0} , kol{1}", a, b);
                
                //string selectQuery2 = "SELECT CenaKarte FROM Predstave WHERE Id=" + a;

                //SQLiteCommand comm1 = new SQLiteCommand(selectQuery2, db.mySQLiteConnection);
                //comm1.Connection.Open();

                //while (reader.Read())
                //{
                //    cena = reader.GetInt32(0);
                //    Console.WriteLine("{0}", cena);
                //}

                //reader.Close();
                //comm1.Connection.Close();

                //comm.Connection.Open();

                //comm.Parameters.AddWithValue("@StanjeRacuna", 0);


                //comm.ExecuteNonQuery();

                //comm.Connection.Close();

            }

        }
    }
}