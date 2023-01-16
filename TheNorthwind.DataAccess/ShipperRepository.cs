using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheNorthwind.DataAccess
{
    public class ShipperRepository
    {
        public void Add(Shipper shipper)
        {
            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
insert into Shippers (CompanyName, Phone) values (@companyName, @phone)";

                command.Parameters.AddWithValue("@companyName", shipper.CompanyName);
                command.Parameters.AddWithValue("@phone", shipper.Phone);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(Shipper shipper)
        {
            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
update Shippers set
CompanyName=@companyName,
Phone=@phone";
                command.Parameters.AddWithValue("CompnayName", shipper.CompanyName);
                command.Parameters.AddWithValue("Phone", shipper.Phone);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Remove(Shipper shipper)
        {
            Remove(shipper.Id);
        }

        public void Remove(int id)
        {
            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
delete from Shippers where ShipperID=@id";

                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }

        public Shipper Find(int id)
        {
            var shipper = default(Shipper);

            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
select*from Shippers where ShipperID=@id";

                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        shipper = new Shipper()
                        {
                            Id = reader.GetInt32("ShipperID"),
                            CompanyName = reader.GetStringNullable("CompanyName"),
                            Phone = reader.GetStringNullable("Phone")

                        };
                    }
                }
                connection.Close();

            }
            return shipper;

        }


    }
}
