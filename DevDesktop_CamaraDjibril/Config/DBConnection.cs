using System.Diagnostics;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Data
{
    public class DBConnection
    {
        private DBConnection()
        {
        }

        public string Server { get; set; }
        public string Port { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public MySqlConnection Connection { get; set;}

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
           return _instance;
        }
    
        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(DatabaseName))
                    return false;
                string connstring = string.Format("Server={0}; port={1}; database={2}; UID={3}; password={4}", Server, Port, DatabaseName, UserName, Password);
                Connection = new MySqlConnection(connstring);
                Connection.Open();
                if (Connection.State != System.Data.ConnectionState.Open)
                    Debug.WriteLine("Connection failed");
            }
    
            return true;
        }

        public void Open()
        {
            Connection.Open();
        }
    
        public void Close()
        {
            Connection.Close();
        }        
    }
}