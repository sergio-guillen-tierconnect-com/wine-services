using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Wines.DataAccess {
    public class WineDa {
        private string connectionString = "Server=localhost;Database=wines;Uid=root;Pwd=12345;";

        public List<Wine> GetWines() {
            List<Wine> wines = new List<Wine>();
            Wine item;
            MySqlConnection conn = new MySqlConnection(connectionString);
            try {
                conn.Open();

                string sql = "select * from wine";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    item = new Wine();
                    item.Id = reader.GetInt64(0);
                    item.Name = reader.GetString(1);
                    item.Grapes = reader.GetString(2);
                    item.Country = reader.GetString(3);
                    item.Region = reader.GetString(4);
                    item.Year = reader.GetString(5);
                    item.Description = reader.GetString(6);
                    item.Picture = reader.IsDBNull(7) ? null : reader.GetString(7);

                    wines.Add(item);
                }
                reader.Close();
            } catch (Exception) {

            } finally {
                conn.Close();
            }

            return wines;
        }

        public Wine GetWine(long id) {
            Wine item = null;
            MySqlConnection conn = new MySqlConnection(connectionString);
            try {
                conn.Open();

                string sql = "select * from wine where id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    item = new Wine();
                    item.Id = reader.GetInt64(0);
                    item.Name = reader.GetString(1);
                    item.Grapes = reader.GetString(2);
                    item.Country = reader.GetString(3);
                    item.Region = reader.GetString(4);
                    item.Year = reader.GetString(5);
                    item.Description = reader.GetString(6);
                    item.Picture = reader.IsDBNull(7) ? null : reader.GetString(7);
                    break;
                }
                reader.Close();
            } catch (Exception) {

            } finally {
                conn.Close();
            }

            return item;
        }

        public int Insert(Wine wine) {
            MySqlConnection conn = new MySqlConnection(connectionString);
            int rowsAffected = -1;
            try {
                conn.Open();
                string sql = @"insert into wine(winename, grapes, country, region, year, description, picture)
                               values(@name, @grapes, @country, @region, @year, @description, @picture)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("name", wine.Name);
                cmd.Parameters.AddWithValue("grapes", wine.Grapes);
                cmd.Parameters.AddWithValue("country", wine.Country);
                cmd.Parameters.AddWithValue("region", wine.Region);
                cmd.Parameters.AddWithValue("year", wine.Year);
                cmd.Parameters.AddWithValue("description", wine.Description);
                cmd.Parameters.AddWithValue("picture", wine.Picture);

                rowsAffected = cmd.ExecuteNonQuery();
            } catch (Exception) { } finally {
                conn.Close();
            }
            return rowsAffected;
        }

        public int Update(Wine wine) {
            MySqlConnection conn = new MySqlConnection(connectionString);
            int rowsAffected = -1;
            try {
                conn.Open();
                string sql = @"update wine
                               set
                               winename = @name, 
                               grapes = @grapes, 
                               country = @country, 
                               region = @region, 
                               year = @year, 
                               description = @description, 
                               picture = @picture
                               where id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", wine.Id);
                cmd.Parameters.AddWithValue("name", wine.Name);
                cmd.Parameters.AddWithValue("grapes", wine.Grapes);
                cmd.Parameters.AddWithValue("country", wine.Country);
                cmd.Parameters.AddWithValue("region", wine.Region);
                cmd.Parameters.AddWithValue("year", wine.Year);
                cmd.Parameters.AddWithValue("description", wine.Description);
                cmd.Parameters.AddWithValue("picture", wine.Picture);

                rowsAffected = cmd.ExecuteNonQuery();
            } catch (Exception) { } finally {
                conn.Close();
            }
            return rowsAffected;
        }

        public int Delete(long id) {
            MySqlConnection conn = new MySqlConnection(connectionString);
            int rowsAffected = -1;
            try {
                conn.Open();
                string sql = "delete from wine where id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);

                rowsAffected = cmd.ExecuteNonQuery();
            } catch (Exception) { } finally {
                conn.Close();
            }
            return rowsAffected;
        }
    }
}
