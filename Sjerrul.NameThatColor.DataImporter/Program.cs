using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sjerrul.NameThatColor.DataImporter
{
    static class Program
    {
        static void Main(string[] args)
        {
            SQLiteConnection.CreateFile("MyDatabase.sqlite");
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();

            SQLiteTransaction transaction = m_dbConnection.BeginTransaction();


            string sql = File.ReadAllText("mainsurvey_sqldump.sql"); // http://xkcd.com/color/colorsurvey.tar.gz for the full database
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            transaction.Commit();

            SQLiteCommand sqlComm2 = new SQLiteCommand("end", m_dbConnection);
            sqlComm2.ExecuteNonQuery();
            m_dbConnection.Close();
        }
    }
}
