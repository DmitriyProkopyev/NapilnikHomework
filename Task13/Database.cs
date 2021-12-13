using System.Data;
using System.IO;
using System.Reflection;

namespace Model
{
    public class Database
    {
        public SearchResult MakeRequest(string passport)
        {
            DataTable table = null;

            try
            {
                table = GetDataTable(passport);
            }
            catch (SQLiteException exception)
            {
                return new SearchResult(false, SearchResult.SearchState.Error);
            }

            if (table.Rows.Count == 0)
                return new SearchResult(false, SearchResult.SearchState.NotFound);

            if (table.Rows[0].ItemArray[1] == null)
                return new SearchResult(false, SearchResult.SearchState.Fail);

            return new SearchResult(true, SearchResult.SearchState.Success);
        }

        private DataTable GetDataTable(string query)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string command = "select * from passports where num='" + Security.Sha256(query) + "' limit 1;";
            string connectionText = "Data Source=" + path + "\\db.sqlite";

            var connection = new SQLiteConnection(connectionText);
            connection.Open();
            var sqLiteDataAdapter = new SQLiteDataAdapter(new SQLiteCommand(command, connection));
            var dataTable = new DataTable();
            sqLiteDataAdapter.Fill(dataTable);
            connection.Close();

            return dataTable;
        }
    }
}
