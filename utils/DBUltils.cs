using System.Data;
using Npgsql;


namespace BAITAPOOP1.utils {
    public class DBUltils {
        private static DBUltils instance;
        private NpgsqlConnection conn;

        private DBUltils() {
            string connString = "Host=localhost;Username";
            conn = new NpgsqlConnection(connString);
        }

        public static DBUltils Instance {
            get {
                if (instance == null) {
                    instance = new DBUltils();
                }
                return instance;
            }
            private set { DBUltils.instance = value; }
        }

        public DataTable ExecuteQuery(string query) {
            DataTable result = new DataTable();
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn)) {
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd)) {
                    adapter.Fill(result);
                }
            }
            return result;
        }

        public int ExecuteNonQuery(string query) {
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn)) {
                return cmd.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(string query) {
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn)) {
                return cmd.ExecuteScalar();
            }
        }
    }
}