using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheNorthwind.DataAccess;
using TheNorthwind;

namespace TheNorthwind.DataAccess
{
    public class CustomerRepository
    {
        public Customer GetById(string id)
        {
            var customer = default(Customer);

            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from Customers where CustomerID = @id";
                command.Parameters.AddWithValue("@id", id);

                connection.Open();

                using (var dr = command.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        customer = new Customer()
                        {
                            Id = dr.GetStringNullable("CustomerID"),
                            CompanyName = dr.GetStringNullable("CompanyName"),
                            ContactName = dr.GetStringNullable("ContactName"),
                            ContactTitle = dr.GetStringNullable("ContactTitle"),
                            Address = dr.GetStringNullable("Address"),
                            City = dr.GetStringNullable("City"),
                            Region = dr.GetStringNullable("Region"),
                            PostalCode = dr.GetStringNullable("PostalCode"),
                            Country = dr.GetStringNullable("Country"),
                            Phone = dr.GetStringNullable("Phone"),
                            Fax = dr.GetStringNullable("Fax")

                        };
                    }
                }

                connection.Close();
            }

            return customer;
        }

        public void Add(Customer customer)
        {
            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"INSERT INTO [dbo].[Customers]
           ([CustomerID]
           ,[CompanyName]
           ,[ContactName]
           ,[ContactTitle]
           ,[Address]
           ,[City]
           ,[Region]
           ,[PostalCode]
           ,[Country]
           ,[Phone]
           ,[Fax]
     VALUES 
	 (@CustomerID, @CompanyName, @ContactName, @ContactTitle,@Address,@City,@Region, @PostalCode,@Country,@Phone,@Fax)";

                command.Parameters.AddWithValue("@CustomerID", customer.Id);
                command.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                command.Parameters.AddWithValue("@ContactName", customer.ContactName);
                command.Parameters.AddWithValue("@ContactTitle", customer.ContactTitle);
                command.Parameters.AddWithValue("@Address", customer.Address);
                command.Parameters.AddWithValue("@City", customer.City);
                command.Parameters.AddWithValue("@Region", customer.Region);
                command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                command.Parameters.AddWithValue("@Country", customer.Country);
                command.Parameters.AddWithValue("@Phone", customer.Phone);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(Customer customer)
        {
            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"UPDATE [dbo].[Customers]
   SET 
       [CustomerID]=@CustomerID
      ,[CompanyName] = @CompanyName
      ,[ContactName] = @ContactName
      ,[ContactTitle] = @ContactTitle
      ,[Address] = @Address
      ,[City] = @City
      ,[Region] = @Region
      ,[PostalCode] = @PostalCode
      ,[Country] = @Country
      ,[Phone] = @Phone";
                command.Parameters.AddWithValue("@CustomerID", customer.Id);
                command.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                command.Parameters.AddWithValue("@ContactName", customer.ContactName);
                command.Parameters.AddWithValue("@ContactTitle", customer.ContactTitle);
                command.Parameters.AddWithValue("@Address", customer.Address);
                command.Parameters.AddWithValue("@City", customer.City);
                command.Parameters.AddWithValue("@Region", customer.Region);
                command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                command.Parameters.AddWithValue("@Country", customer.Country);
                command.Parameters.AddWithValue("@Phone", customer.Phone);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        //********
        public void Remove(Customer customer)
        {
            Remove(customer);
        }

        public void Remove(string id)
        {
            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "delete from Customers where CustomerID=@id";

                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

        public Customer Find(string id)
        {
            var customer = default(Customer);

            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
select*from Customers where CustomerID=@id";

                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        customer = MapCustomer(reader);
                    }
                }
                connection.Close();

            }
            return customer;

        }

        private static Customer MapCustomer(SqlDataReader reader)
        {
            return new Customer()
            {
                CustomerID = reader.GetStringNullable("CustomerID"),
                CompanyName = reader.GetStringNullable("CompanyName"),
                Fax = reader.GetStringNullable("Fax"),
                ContactName = reader.GetStringNullable("ContactName"),
                ContactTitle = reader.GetStringNullable("ContactTitle"),
                Address = reader.GetStringNullable("Address"),
                City = reader.GetStringNullable("City"),
                Region = reader.GetStringNullable("Region"),
                PostalCode = reader.GetStringNullable("PostalCode"),
                Country = reader.GetStringNullable("Country"),
                Phone = reader.GetStringNullable("Phone"),
            };
        }

        public List<Customer> GetAll()
        {
            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = @"
select
    CustomerID,
    CompanyName,
    ContactName,
    ContactTitle,
     Address,
     City,
    Region,
     PostalCode,
    Country,
     Phone,
    Fax
    from Customers";

                    connection.Open();


                    var customerList = new List<Customer>();
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            customerList.Add(MapCustomer(dataReader));
                        }
                    }

                    connection.Close();

                    return customerList;
                }
                catch (Exception)
                {

                    throw;
                }
            }


        }

    }
}

