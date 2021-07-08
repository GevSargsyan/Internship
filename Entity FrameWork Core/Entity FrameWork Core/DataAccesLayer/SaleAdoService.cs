using Entity_FrameWork_Core.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_FrameWork_Core.DataAccesLayer
{
    public class SaleAdoService
    {

        public async Task CreateSaleAsync(Sale sale)
        {

            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=EFCORE1;Trusted_Connection=True;";
            var query = $"INSERT INTO SALE(DateSold,Price,AmountSold,ProductId) values" +
                $"{sale.DateSold},{sale.Price},{sale.AmountSold},{sale.ProductId}";

            using (var sqlConnection = new SqlConnection(connectionString))
            {

                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();

                await  sqlCommand.ExecuteNonQueryAsync();


            }

        }
        public async Task UpdateSaleAsync(Sale sale)
        {

            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=EFCORE1;Trusted_Connection=True;";
            var query = $"UPDATE SALE set DateSold={sale.DateSold},Price={sale.Price},AmountSold={sale.AmountSold})" +
                $"where Id={sale.SaleId}";
                

            using (var sqlConnection = new SqlConnection(connectionString))
            {

                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();

                await  sqlCommand.ExecuteNonQueryAsync();


            }

        }
        
        public async Task DeleteSaleAsync(int saleId)
        {

            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=EFCORE1;Trusted_Connection=True;";
            var query = $"DELETE FROM SALE" +
                $"where SaleId={saleId}";
                

            using (var sqlConnection = new SqlConnection(connectionString))
            {

                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();

                await  sqlCommand.ExecuteNonQueryAsync();


            }

        }
        
        public async Task<List<Sale>> GetSaleAsync(int saleId)
        {
            var resultSales = new List<Sale>();

            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=EFCORE1;Trusted_Connection=True;";
            var query = "SELECT * FROM Sales";
                

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();

                var reader = await sqlCommand.ExecuteReaderAsync();

                while (reader.Read())
                {
                    resultSales.Add( new Sale
                    {
                        DateSold=reader.GetDateTime(1),
                        Price=reader.GetFloat(2),
                        AmountSold=reader.GetInt32(3)

                    });
                }

            }


            return resultSales;
        }
        
    }
}
