using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TheNorthwind.DataAccess
{
    // Repository Pattern
    // Repository => Depo anlamına gelir
    // Projelerin veriye erişen katmanlarında, Sql'de bir tabloyu temsilen koleksiyon tipindeki nesnelerin
    // ve bir satırlık kayıdı temsilen Entity nesnelerinin oluşturulduğu, çözümlendiği katman

    // Kategori tablosu ile ilgili veri işlemleri bu sınıfta yer alacak
    // Veri işlemleri? CRUD
    // Create
    // Read
    // Update
    // Delete
    public class CategoryRepository
    {
        // Create, Insert
        public void Add(Category category)
        {
            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText =
                    @"insert into Categories (CategoryName, Description) values (@name, @description)";
                command.Parameters.AddWithValue("@name", category.Name);
                command.Parameters.AddWithValue("@description", category.Description);

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void Update(Category category)
        {
            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
update Categories
set
    CategoryName = @name,
    Description = @description
where CategoryID = @id";

                command.Parameters.AddWithValue("@id", category.Id);
                command.Parameters.AddWithValue("@name", category.Name);
                command.Parameters.AddWithValue("@description", category.Description);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Remove(int id)
        {
            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "delete from Categories where CategoryID = @id";
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            //Remove(new Category() { Id = id });
        }

        // Delete
        public void Remove(Category category)
        {
            Remove(category.Id);
        }


        public Category GetById(int id)
        {
            var category = default(Category);

            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "select * from Categories where CategoryID = @id";
                command.Parameters.AddWithValue("@id", id);

                connection.Open();

                using (var dr = command.ExecuteReader())
                {
                    if (dr.HasRows && dr.Read())
                    {
                        category = new Category()
                        {
                            Id = dr.GetInt32("CategoryID"),
                            Name = dr.GetStringNullable("CategoryName"),
                            Description = dr.GetStringNullable("Description")
                        };
                    }
                }

                connection.Close();
            }

            return category;
        }

        public List<Category> GetAll()
        {
            using (var connection = new SqlConnection(DbSettings.ConnectionString))
            using (var command = new SqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = @"
select
    CategoryID as Id,
    CategoryName as Name,
    Description
from Categories";

                    connection.Open();

                    var categoryList = new List<Category>();
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            var category = new Category()
                            {
                                // dataReader, Result Set içindeki kolon isimleri
                                // ile ilgilenir, onları bilir
                                // Eğer sorguda kolon isimleri alias ile değiştirildiyse
                                // dataReader["KOLON_ADI"] kısmında yazılacak kolon adı da
                                // alias ile aynı olmalıdır
                                Id = (int)dataReader["Id"],
                                Name = (string)dataReader["Name"],
                                Description = (string)dataReader["Description"],
                            };
                            categoryList.Add(category);
                        }
                    }

                    connection.Close();

                    return categoryList;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        #region şimdilik pek dikkate almayın

        void Test()
        {
            var categories = new List<Category>();

            var record = new Category();
            record.Name = "Yeni kategori";

            categories.Add(record);

            ////
            ///

            categories.Remove(record);

            record.Name = "Eski kategori";
            //categories.Update(record);

            categories.Where(r => r.Name == "Beverages");
        }
        #endregion
    }
}
