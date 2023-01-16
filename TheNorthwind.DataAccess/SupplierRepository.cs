using System.Data;
using System.Data.SqlClient;

namespace TheNorthwind.DataAccess
{
    public class SupplierRepository
    {
        // GetById metodu Repository sınıflarında Find olarak da isimlendirilebilir
        public Supplier Find(int id)
        {
            var supplier = default(Supplier);
            //Supplier supplier = default(Supplier);

            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from Suppliers where SupplierID = @id";
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        supplier = MapSupplier(reader);
                    }
                }
                connection.Close();
            }
            return supplier;
        }

        public List<Supplier> GetAll()
        {
            var suppliers = new List<Supplier>();

            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from Suppliers";
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        suppliers.Add(MapSupplier(reader));
                    }
                }
                connection.Close();
            }
            return suppliers;
        }

        public void Add(Supplier supplier)
        {
            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
insert into Suppliers ([CompanyName], [ContactName], [ContactTitle], [Address],
[City], [Region], [PostalCode], [Country], [Phone], [Fax], [HomePage])
values (@CompanyName, @ContactName, @ContactTitle, @Address,
@City, @Region, @PostalCode, @Country, @Phone, @Fax, @HomePage)";

                command.Parameters.AddWithValue("@CompanyName", supplier.CompanyName);
                command.Parameters.AddWithValue("@ContactName", supplier.ContactName);
                command.Parameters.AddWithValue("@ContactTitle", supplier.ContactTitle);
                command.Parameters.AddWithValue("@Address", supplier.Address);
                command.Parameters.AddWithValue("@City", supplier.City);
                command.Parameters.AddWithValue("@Region", supplier.Region);
                command.Parameters.AddWithValue("@PostalCode", supplier.PostalCode);
                command.Parameters.AddWithValue("@Country", supplier.Country);
                command.Parameters.AddWithValue("@Phone", supplier.Phone);
                command.Parameters.AddWithValue("@Fax", supplier.Fax);
                command.Parameters.AddWithValue("@HomePage", supplier.HomePage);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(Supplier supplier)
        {
            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
update Suppliers
set
    CompanyName = @CompanyName,
    ContactName = @ContactName,
    ContactTitle = @ContactTitle,
    City = @City,
    Country = @Country,
    Address = @Address,
    PostalCode = @PostalCode,
    Region = @Region,
    Phone = @Phone,
    Fax = @Fax,
    HomePage = @HomePage
where SupplierID = @id ";
                command.Parameters.AddWithValue("@id", supplier.Id);
                command.Parameters.AddWithValue("@CompanyName", supplier.CompanyName);
                command.Parameters.AddWithValue("@ContactName", supplier.ContactName);
                command.Parameters.AddWithValue("@ContactTitle", supplier.ContactTitle);
                command.Parameters.AddWithValue("@City", supplier.City);
                command.Parameters.AddWithValue("@Country", supplier.Country);
                command.Parameters.AddWithValue("@Address", supplier.Address);
                command.Parameters.AddWithValue("@PostalCode", supplier.PostalCode);
                command.Parameters.AddWithValue("@Region", supplier.Region);
                command.Parameters.AddWithValue("@Phone", supplier.Phone);
                command.Parameters.AddWithValue("@Fax", supplier.Fax);
                command.Parameters.AddWithValue("@HomePage", supplier.HomePage);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Remove(Supplier supplier)
        {
            Remove(supplier.Id);
        }

        public void Remove(int id)
        {
            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "delete from Suppliers where SupplierID = @id";
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private static Supplier MapSupplier(SqlDataReader reader)
        {
            return new Supplier()
            {
                Id = reader.GetInt32("SupplierID"),
                CompanyName = reader.GetStringNullable("CompanyName"),
                ContactName = reader.GetStringNullable("ContactName"),
                ContactTitle = reader.GetStringNullable("ContactTitle"),
                City = reader.GetStringNullable("City"),
                Country = reader.GetStringNullable("Country"),
                Address = reader.GetStringNullable("Address"),
                PostalCode = reader.GetStringNullable("PostalCode"),
                Region = reader.GetStringNullable("Region"),
                Phone = reader.GetStringNullable("Phone"),
                Fax = reader.GetStringNullable("Fax"),
                HomePage = reader.GetStringNullable("HomePage")
            };
        }
    }
}
