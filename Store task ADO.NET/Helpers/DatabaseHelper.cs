using Store_task_ADO.NET.Models;
using Store_task_ADO.NET.ViewModels;
using Store_task_ADO.NET.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_task_ADO.NET.Helpers
{
    public class DatabaseHelper
    {
        public async static Task AddProducts(ICollection<ProductUC> collection)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
                conn.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * FROM Products";

                var addedProductNames = new List<String>();
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var product = new Product()
                        {
                            Id = int.Parse(reader["ProductId"].ToString()),
                            Name = reader["ProductName"].ToString(),
                            Price = reader["ProductPrice"].ToString(),
                            Discount = int.Parse(reader["ProductDiscount"].ToString()),
                            ImagePath = reader["ImagePath"].ToString(),
                        };
                        var productView = new ProductUC();
                        product.Price += "$";
                        var productViewModel = new ProductUCViewModel(product);
                        productView.DataContext = productViewModel;
                        if (!addedProductNames.Contains(product.Name))
                        {
                            addedProductNames.Add(product.Name);
                            collection.Add(productView);
                        }
                    }
                }
            }
        }

        public async static Task DeleteProductById(int id)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
                conn.Open();

                SqlCommand command = conn.CreateCommand();

                command.CommandText = @"DELETE FROM Products
                                        WHERE ProductId = @id";

                var param = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    SqlValue = id,
                    ParameterName = "@id"
                };

                command.Parameters.Add(param);

                await command.ExecuteNonQueryAsync();
            }
        }

        public static async Task UpdateProduct(Product product)
        {
            using (var conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
                conn.Open();

                SqlCommand command = conn.CreateCommand();

                command.CommandText = @"UPDATE Products
                                        SET 
                                        ProductPrice = @price
                                        ProductName = @name
                                        ProductDiscount = @discount
                                        WHERE ProductId = @id";

                var param1 = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    SqlValue = product.Id,
                    ParameterName = "@id"
                };

                var param2 = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Money,
                    SqlValue = product.Price,
                    ParameterName = "@price"
                };

                var param3 = new SqlParameter()
                {
                    SqlDbType = SqlDbType.NVarChar,
                    SqlValue = product.Name,
                    ParameterName = "@name"
                };

                var param4 = new SqlParameter()
                {
                    SqlDbType = SqlDbType.Int,
                    SqlValue = product.Discount,
                    ParameterName = "@discount"
                };

                command.Parameters.Add(param1);
                command.Parameters.Add(param2);
                command.Parameters.Add(param3);
                command.Parameters.Add(param4);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
