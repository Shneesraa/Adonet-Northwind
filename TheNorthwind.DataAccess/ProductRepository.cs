using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheNorthwind.DataAccess
{
    public class ProductRepository
    {
        public Product Find(int id)
        {
            var product = default(Product);

            using (var sqlConnection = new SqlConnection(DbSettings.ConnectionString))
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandText = "select * from Products where ProductID = @id";
                sqlCommand.Parameters.AddWithValue("@id", id);

                sqlConnection.Open();
                using (var dataReader = sqlCommand.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        product = MapProduct(dataReader);
                    }
                }
                sqlConnection.Close();
            }

            return product;
        }

        private static Product MapProduct(SqlDataReader dataReader)
        {
            return new Product()
            {
                Id = dataReader.GetInt32("ProductID"),
                Name = dataReader.GetStringNullable("ProductName"),
                CategoryId = dataReader.GetInt32Nullable("CategoryID"),
                SupplierId = dataReader.GetInt32Nullable("SupplierID"),
                QuantityPerUnit = dataReader.GetStringNullable("QuantityPerUnit")
            };
        }

        public void Add(Product product)
        {
            using (var sqlConnection = new SqlConnection(DbSettings.ConnectionString))
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandText = @"
INSERT INTO [dbo].[Products]
([ProductName],[SupplierID],[CategoryID],[QuantityPerUnit],[UnitPrice],[UnitsInStock]
,[UnitsOnOrder],[ReorderLevel],[Discontinued])
VALUES
(@productName,@supplierId,@categoryId,@quantityPerUnit, @unitPrice, @unitsInStock, 
@unitsOnOrder, @reorderLevel, @discontinued)";

                sqlCommand.Parameters.AddWithValue("@productName", product.Name);
                sqlCommand.Parameters.AddWithValue("@supplierId", product.SupplierId);
                sqlCommand.Parameters.AddWithValue("@categoryId", product.CategoryId);
                sqlCommand.Parameters.AddWithValue("@quantityPerUnit", product.QuantityPerUnit);
                sqlCommand.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
                sqlCommand.Parameters.AddWithValue("@unitsInStock", product.UnitsInStock);
                sqlCommand.Parameters.AddWithValue("@unitsOnOrder", product.UnitsOnOrder);
                sqlCommand.Parameters.AddWithValue("@reorderLevel", product.ReorderLevel);
                sqlCommand.Parameters.AddWithValue("@discontinued", product.Discontinued);

                sqlConnection.Open();
                var affectedRows = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public void Update(Product product)
        {
            using (var sqlConnection = new SqlConnection(DbSettings.ConnectionString))
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandText = @"
UPDATE [dbo].[Products]
   SET [ProductName] = @productName,
      ,[SupplierID] = @supplierId,
      ,[CategoryID] = @categoryId,
      ,[QuantityPerUnit] = @quantityPerUnit
      ,[UnitPrice] = @unitPrice,
      ,[UnitsInStock] = @unitsInStock,
      ,[UnitsOnOrder] = @unitsOnOrder,
      ,[ReorderLevel] = @reorderLevel,
      ,[Discontinued] = @discontinued
 WHERE SupplierID = @id";

                sqlCommand.Parameters.AddWithValue("@id", product.Id);
                sqlCommand.Parameters.AddWithValue("@productName", product.Name);
                sqlCommand.Parameters.AddWithValue("@supplierId", product.SupplierId);
                sqlCommand.Parameters.AddWithValue("@categoryId", product.CategoryId);
                sqlCommand.Parameters.AddWithValue("@quantityPerUnit", product.QuantityPerUnit);
                sqlCommand.Parameters.AddWithValue("@unitPrice", product.UnitPrice);
                sqlCommand.Parameters.AddWithValue("@unitsInStock", product.UnitsInStock);
                sqlCommand.Parameters.AddWithValue("@unitsOnOrder", product.UnitsOnOrder);
                sqlCommand.Parameters.AddWithValue("@reorderLevel", product.ReorderLevel);
                sqlCommand.Parameters.AddWithValue("@discontinued", product.Discontinued);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public void Remove(Product product)
        {
            Remove(product.Id);
        }

        public void Remove(int id)
        {
            using (var sqlConnection = new SqlConnection(DbSettings.ConnectionString))
            using (var sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandText = "delete from Products where ProductID = @id";
                sqlCommand.Parameters.AddWithValue("@id", id);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
        public List<Product> GetAll()
        {
            var product = new List<Product>();

            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from Products";
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        product.Add(MapProduct(reader));
                    }
                }
                connection.Close();
            }
            return product;
        }
    }
}
