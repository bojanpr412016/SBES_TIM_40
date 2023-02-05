using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatreService
{
    public class DBAccess
    {
        public SQLiteConnection mySQLiteConnection;

        public DBAccess()
        {
            mySQLiteConnection = new SQLiteConnection("Data Source=TheatreDB.db");
            if (!File.Exists("./TheatreDB.db"))
            {

                SQLiteConnection.CreateFile("TheatreDB.db");
                Console.WriteLine("Database file created");
            }

        }

    }
}
