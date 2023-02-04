using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TheatreService.TheatreService;

namespace TheatreService
{
    public class TheatreService : ITheatreService
    {        
            //DBAccess db = new DBAccess();

            int idBr;
            public void dodajPredstavu()
            {
            Console.WriteLine("----------------------------------------------------------------");
            /*using (IDbConnection conn = new SQLiteConnection())
            {
                Debugger.Launch();
                string insertQuery = "INSERT INTO Predstave (`Naziv`, `Vreme`,`Sala`, `CenaKarte`) VALUES (@Naziv,@Vreme,@Sala,@CenaKarte)";

                SQLiteCommand mySQLiteCommand = new SQLiteCommand(insertQuery, db.mySQLiteConnection);

                mySQLiteCommand.Connection.Open();

                mySQLiteCommand.Parameters.AddWithValue("@Naziv", p.Naziv);
                mySQLiteCommand.Parameters.AddWithValue("@Vreme", p.Vreme);
                mySQLiteCommand.Parameters.AddWithValue("@Sala", p.Sala);
                mySQLiteCommand.Parameters.AddWithValue("@CenaKarte", p.CenaKarte);

                var fInsertResult = mySQLiteCommand.ExecuteNonQuery();

                mySQLiteCommand.Connection.Close();
            }*/
           
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
