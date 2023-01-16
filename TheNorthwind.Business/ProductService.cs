using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheNorthwind.DataAccess;

namespace TheNorthwind.Business
{
    public class ProductService
    {
        private ProductRepository _repository = new ProductRepository();

        public List<Product> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception)
            {
                // TODO: Hata mesajını Logla
                return new List<Product>();
            }
        }

        public Product GetById(int id)
        {
            try
            {
                return _repository.Find(id);
            }
            catch (Exception)
            {
                // TODO: Hata mesajı Loglanacak
                return default;
            }
        }

        public CommandResult Create(Product product)
        {
            try
            {
                _repository.Add(product);

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                // TODO: Hata mesajını logla

                return CommandResult.Failure(ex);
            }
        }

        public CommandResult Update(Product product)
        {
            try
            {
                _repository.Update(product);

                // Factory Pattern
                return CommandResult.Success("Güncelleme başarılı");
            }
            catch (Exception ex)
            {
                // Factory Pattern
                return CommandResult.Failure("Güncelleme başarısız", ex);
            }
        }

        public CommandResult Delete(Product product)
        {
            try
            {
                _repository.Remove(product);

                // Burada bilerek eski usül CommandResult oluşturma işlemini bıraktık
                // Nostalji
                return new CommandResult()
                {
                    IsSuccess = true,
                    Message = "Silme işlemi başarılı"
                };
            }
            catch (Exception ex)
            {
                return new CommandResult()
                {
                    IsSuccess = false,
                    Message = "Silme başarısız",
                    ErrorMessage = ex.ToString()
                };
            }
        }
    }
}
