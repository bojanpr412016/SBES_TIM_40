using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static TheatreService.TheatreService;

namespace TheatreService
{
    public class TheatreService : ITheatreService
    {        
            DBAccess db = new DBAccess();

            int idBr;
            public void dodajPredstavu(Predstava p)
            {
                Console.WriteLine("----------------------------------------------------------------");
                using (IDbConnection conn = new SQLiteConnection())
                {
                    //Debugger.Launch();
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
                    //conn.Open();

                    comm.Connection.Open();
                    reader = comm.ExecuteReader();
                    Console.WriteLine($"ID   {reader.GetName(1)} {reader.GetName(2)} {reader.GetName(3)} {reader.GetName(4)}");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetInt32(0)} {reader["Naziv"]} {reader.GetDateTime(2).ToString("yyyy/MM/dd")} {reader["Sala"]} {reader["CenaKarte"]}");
                        //Console.WriteLine("ee");
                    }
                //comm.Connection.Close();
                //SqlDateTime vreme = new SqlDateTime(reader["Vreme"].to);
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
                Debugger.Launch();
                string selectQuery = "SELECT * FROM Predstave WHERE Id=" + u;
                //SQLiteDataReader reader;
                SQLiteCommand comm = new SQLiteCommand(selectQuery, db.mySQLiteConnection);
                //conn.Open();

                Predstava p = new Predstava();
                comm.Connection.Open();
                //reader = comm.ExecuteReader();
                //Console.WriteLine($"ID   {reader.GetName(1)} {reader.GetName(2)} {reader.GetName(3)} {reader.GetName(4)}");
                using (SQLiteDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetInt32(0)} {reader["Naziv"]} {reader.GetDateTime(2).ToString("yyyy/MM/dd")} {reader["Sala"]} {reader["CenaKarte"]}");
                        p.Naziv = reader.GetString(1);
                        p.Vreme = reader.GetDateTime(2);
                        p.Sala = reader.GetInt32(3);
                        p.CenaKarte = reader.GetFloat(4);
                        break; // (if you only want the first item returned)
                    }
                }

                //Console.WriteLine("ee");
                comm.Connection.Close();
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
                else if(x.GetType() == typeof(double))
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

        public void izmeniSalu()
        {
            throw new NotImplementedException();
        }

        public void izmeniVreme()
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
