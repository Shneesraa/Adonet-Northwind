using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheNorthwind.DataAccess
{
    public class EmployeeRepository
    {
        public Employee Find(int id)
        {

            var shipper = default(Employee);

            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from Employees where EmployeeID = @id";
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        shipper = new Employee()
                        {
                            Id = reader.GetInt32("@id"),
                            LastName = reader.GetString("@LastName"),
                            ReportsTo = reader.GetString("@ReportsTo"),
                            Address = reader.GetString("@Address"),
                            BirthDate = reader.GetDateTime("@BirthDate"),
                            City = reader.GetString("@City"),
                            Country = reader.GetString("@Country"),
                            Extension = reader.GetInt32("@Extension"),
                            FirstName = reader.GetString("@FirstName"),
                            HireDate = reader.GetDateTime("@HireDate"),
                            HomePhone = reader.GetString("@HomePhone"),
                            Notes = reader.GetString("@Notes"),
                            PostalCode = reader.GetString("@PostalCode"),
                            Region = reader.GetString("@Region"),
                            Title = reader.GetString("@Title"),
                            TitleOfCourtesy = reader.GetString("@TitleOfCourtesy"),
                        };
                    }
                }
                connection.Close();
            }
            return shipper;
        }

        public List<Employee> GetAll()
        {
            var employee = new List<Employee>();

            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from Employees";
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        employee.Add(MapSupplier(reader));
                        /* suppliers.Add(new Supplier()
                         {
                             Id = reader.GetInt32("SupplierID"),
                             CompanyName = reader.GetString("CompanyName"),
                             ContactName = reader.GetString("ContactName"),
                             ContactTitle = reader.GetString("ContactTitle"),
                             Address = reader.GetString("Adress"),
                             City = reader.GetString("City"),
                             Region = reader.GetString("Region"),
                             PostalCode = reader.GetString("PostalCode"),
                             Country = reader.GetString("Country"),
                             Phone = reader.GetString("Phone"),
                             Fax = reader.GetString("Fax"),
                             HomePage = reader.GetString("HomePage")
                         });*/
                    }
                }
                connection.Close();
            }
            return employee;
        }

        public void Add(Employee employee)
        {
            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"INSERT INTO [dbo].[Employees]([LastName],[FirstName],[Title],[TitleOfCourtesy],[BirthDate],[HireDate],[Address],[City],[Region],[PostalCode],[Country],[HomePhone],[Extension],[Photo],[Notes],[ReportsTo],[PhotoPath])
     VALUES
           (@LastName,@FirstName,@Title,@TitleOfCourtesy,@BirthDate,@HireDate,@Address,@City,@Region,@PostalCode,@Country,@HomePhone,@Extension,@Photo,@Notes,@ReportsTo,@PhotoPath,)
";
                command.Parameters.AddWithValue("@id", employee.Id);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@Title", employee.Title);
                command.Parameters.AddWithValue("@TitleOfCourtesy", employee.TitleOfCourtesy);
                command.Parameters.AddWithValue("@BirthDate", employee.BirthDate);
                command.Parameters.AddWithValue("@HireDate", employee.HireDate);
                command.Parameters.AddWithValue("@Address", employee.Address);
                command.Parameters.AddWithValue("@City", employee.City);
                command.Parameters.AddWithValue("@Region", employee.Region);
                command.Parameters.AddWithValue("@PostalCode", employee.PostalCode);
                command.Parameters.AddWithValue("@Country", employee.Country);
                command.Parameters.AddWithValue("@HomePhone", employee.HomePhone);
                command.Parameters.AddWithValue("@Extension", employee.Extension);
                command.Parameters.AddWithValue("@Notes", employee.Notes);
                command.Parameters.AddWithValue("@ReportsTo", employee.ReportsTo);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(Employee employee)
        {
            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                connection.Open();

                command.CommandText = @"UPDATE [dbo].[Employees]
       SET[LastName] = @LastName,[FirstName] = @FirstName,[Title] = @Title, [TitleOfCourtesy] = @TitleOfCourtesy,[BirthDate] = @BirthDate, [HireDate] = @HireDate ,[Address] = @Address ,[City] = @City, [Region] = @Region, [PostalCode] = @PostalCode, [Country] = @Country ,[HomePhone] = @HomePhone, [Extension] = @Extension, [Notes] = @Notes, [ReportsTo] = @ReportsTo";
                command.Parameters.AddWithValue("@id", employee.Id);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@Title", employee.Title);
                command.Parameters.AddWithValue("@TitleOfCourtesy", employee.TitleOfCourtesy);
                command.Parameters.AddWithValue("@BirthDate", employee.BirthDate);
                command.Parameters.AddWithValue("@HireDate", employee.HireDate);
                command.Parameters.AddWithValue("@Address", employee.Address);
                command.Parameters.AddWithValue("@City", employee.City);
                command.Parameters.AddWithValue("@Region", employee.Region);
                command.Parameters.AddWithValue("@PostalCode", employee.PostalCode);
                command.Parameters.AddWithValue("@Country", employee.Country);
                command.Parameters.AddWithValue("@HomePhone", employee.HomePhone);
                command.Parameters.AddWithValue("@Extension", employee.Extension);
                command.Parameters.AddWithValue("@Notes", employee.Notes);
                command.Parameters.AddWithValue("@ReportsTo", employee.ReportsTo);
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

        public void Remove(Employee employee)
        {
            Remove(employee.Id);
        }

        public void Remove(int id)
        {
            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "delete from Employees where EmployeeID: @id";
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private static Employee MapSupplier(SqlDataReader reader)
        {
            return new Employee()
            {
                Id = reader.GetInt32("EmployeeID"),
                LastName = reader.GetString("@LastName"),
                Address = reader.GetString("@Address"),
                BirthDate = reader.GetDateTime("@BirthDate"),
                City = reader.GetString("City"),
                Country = reader.GetString("Country"),
                Extension = reader.GetInt32("Extension"),
                FirstName = reader.GetString("FirstName"),
                HireDate = reader.GetDateTime("HireDate"),
                HomePhone = reader.GetString("HomePhone"),
                Notes = reader.GetString("Notes"),
                PostalCode = reader.GetString("PostalCode"),
                Region = reader.GetString("Region"),
                Title = reader.GetString("Title"),
                TitleOfCourtesy = reader.GetString("TitleOfCourtesy"),
                ReportsTo = reader.GetString("ReportsTo")
            };
        }
    }
}
