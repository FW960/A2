using Entities;
using System.Data.SqlClient;
using System.IO;
using System.Text.Json;

namespace Repo
{
    public class DbRepository
    {
        private readonly SqlConnection _connection = new SqlConnection();
        public DbRepository()
        {
            string configFile = File.ReadAllText(@"C:\Users\windo\source\repos\Task\DbRepository\dbConfig.json");

            connectionsStrings str = JsonSerializer.Deserialize<connectionsStrings>(configFile);

            _connection.ConnectionString = str.Default;
        }

        public void Create(DealDTO dto)
        {
            try
            {
                _connection.Open();

                var cmd = _connection.CreateCommand();

                cmd.CommandText = "INSERT INTO dealsTable1(declaration, seller, sellerInn, buyer, buyerInn, dealDate, volume) values(@dec, @sel, @selI, @buy, @buyI, @date, @vol)";

                cmd.Parameters.AddWithValue("@dec", dto.declaration);
                cmd.Parameters.AddWithValue("@sel", dto.seller);
                cmd.Parameters.AddWithValue("@selI", dto.sellerInn);
                cmd.Parameters.AddWithValue("@buy", dto.buyer);
                cmd.Parameters.AddWithValue("@buyI", dto.buyerInn);
                cmd.Parameters.AddWithValue("@date", dto.dealDate);
                cmd.Parameters.AddWithValue("@vol", dto.volume);

                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                _connection.Close();
            }

        }
    }
}
