using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheNorthwind.DataAccess
{
    public class OrderRepository
    {
        public void Add(Orders orders)
        {
            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"INSERT INTO [dbo].[Orders]
           ([CustomerID]
           ,[EmployeeID]
           ,[OrderDate]
           ,[RequiredDate]
           ,[ShippedDate]
           ,[ShipVia]
           ,[Freight]
           ,[ShipName]
           ,[ShipAddress]
           ,[ShipCity]
           ,[ShipRegion]
           ,[ShipPostalCode]
           ,[ShipCountry])
     VALUES 
	 (@CustomerID, @EmployeeID, @OrderDate,@RequiredDate,@ShippedDate,@ShipVia, @Freight,@ShipName,@ShipAddress,@ShipCity,@ShipRegion,@ShipPostalCode,@ShipCountry)";

                command.Parameters.AddWithValue("@CustomerID", orders.CustomerID);
                command.Parameters.AddWithValue("@EmployeeID", orders.EmployeeID);
                command.Parameters.AddWithValue("@OrderDate", orders.OrderDate);
                command.Parameters.AddWithValue("@RequiredDate", orders.RequiredDate);
                command.Parameters.AddWithValue("@ShippedDate", orders.ShippedDate);
                command.Parameters.AddWithValue("@ShipVia", orders.ShipVia);
                command.Parameters.AddWithValue("@Freight", orders.Freight);
                command.Parameters.AddWithValue("@ShipName", orders.ShipName);
                command.Parameters.AddWithValue("@ShipAddress", orders.ShipAddress);
                command.Parameters.AddWithValue("@ShipCity", orders.ShipCity);
                command.Parameters.AddWithValue("@ShipRegion", orders.ShipRegion);
                command.Parameters.AddWithValue("@ShipPostalCode", orders.ShipPostalCode);
                command.Parameters.AddWithValue("@ShipCountry", orders.ShipCountry);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(Orders orders)
        {
            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"UPDATE [dbo].[Orders]
   SET [CustomerID] = @CustomerID
      ,[EmployeeID] = @EmployeeID
      ,[OrderDate] = @OrderDate
      ,[RequiredDate] = @RequiredDate
      ,[ShippedDate] = @ShippedDate
      ,[ShipVia] = @ShipVia
      ,[Freight] = @Freight
      ,[ShipName] = @ShipName
      ,[ShipAddress] = @ShipAddress
      ,[ShipCity] = @ShipCity
      ,[ShipRegion] = @ShipRegion
      ,[ShipPostalCode] = @ShipPostalCode
      ,[ShipCountry] = @ShipCountry";
                command.Parameters.AddWithValue("@CustomerID", orders.CustomerID);
                command.Parameters.AddWithValue("@EmployeeID", orders.EmployeeID);
                command.Parameters.AddWithValue("@OrderDate", orders.OrderDate);
                command.Parameters.AddWithValue("@RequiredDate", orders.RequiredDate);
                command.Parameters.AddWithValue("@ShippedDate", orders.ShippedDate);
                command.Parameters.AddWithValue("@ShipVia", orders.ShipVia);
                command.Parameters.AddWithValue("@Freight", orders.Freight);
                command.Parameters.AddWithValue("@ShipName", orders.ShipName);
                command.Parameters.AddWithValue("@ShipAddress", orders.ShipAddress);
                command.Parameters.AddWithValue("@ShipCity", orders.ShipCity);
                command.Parameters.AddWithValue("@ShipRegion", orders.ShipRegion);
                command.Parameters.AddWithValue("@ShipPostalCode", orders.ShipPostalCode);
                command.Parameters.AddWithValue("@ShipCountry", orders.ShipCountry);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Remove(Orders orders)
        {
            Remove(orders.CustomerID);
        }

        public void Remove(int id)
        {
            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "delete from Orders where CustomerID=@id";

                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

        public Orders Find(int id)
        {
            var order = default(Orders);

            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
select*from Orders where OrderID=@id";

                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        order = new Orders()
                        {
                            CustomerID = reader.GetInt32("CustomerID"),
                            OrderDate = reader.GetDateTime("OrderDate"),
                            EmployeeID = reader.GetInt32("EmployeeID"),
                            RequiredDate = reader.GetDateTime("RequiredDate"),
                            ShippedDate = reader.GetDateTime("ShippedDate"),
                            ShipVia = reader.GetStringNullable("ShipVia"),
                            Freight = reader.GetStringNullable("Freight"),
                            ShipName = reader.GetStringNullable("ShipName"),
                            ShipAddress = reader.GetStringNullable("ShipAddress"),
                            ShipCity = reader.GetStringNullable("ShipCity"),
                            ShipRegion = reader.GetStringNullable("ShipRegion"),
                            ShipPostalCode = reader.GetStringNullable("ShipPostalCode"),
                            ShipCountry = reader.GetStringNullable("ShipCountry"),

                        };
                    }
                }
                connection.Close();

            }
            return order;

        }
    }
}
