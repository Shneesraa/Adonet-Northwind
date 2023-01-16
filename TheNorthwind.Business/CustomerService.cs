using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheNorthwind.DataAccess;

namespace TheNorthwind.Business
{
    public class CustomerService
    {
        private CustomerRepository _repository = new CustomerRepository();

        public List<Customer> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception)
            {
                
                return new List<Customer>();
            }
        }

        public Customer GetById(Customer customer)
        {
            try
            {
                return _repository.Find(customer.Id);
            }
            catch (Exception)
            {
                // TODO: Hata mesajı Loglanacak
                return default;
            }
        }

        public CommandResult Create(Customer customer)
        {
            try
            {
                _repository.Add(customer);

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                // TODO: Hata mesajını logla

                return CommandResult.Failure(ex);
            }
        }

        public CommandResult Update(Customer customer)
        {
            try
            {
                _repository.Update(customer);

                // Factory Pattern
                return CommandResult.Success("Güncelleme başarılı");
            }
            catch (Exception ex)
            {
                // Factory Pattern
                return CommandResult.Failure("Güncelleme başarısız", ex);
            }
        }

        public CommandResult Delete(Customer customer)
        {
            try
            {
                _repository.Remove(customer);

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
