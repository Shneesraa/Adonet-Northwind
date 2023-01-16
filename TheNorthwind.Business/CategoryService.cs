using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheNorthwind.DataAccess;

namespace TheNorthwind.Business
{
    // CategoryBusiness
    // CategoryBLL (Business Layer Logic)
    // CategoryManager
    // CategoryFacade
    public class CategoryService
    {
        private CategoryRepository _repository = new CategoryRepository();

        public List<Category> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception)
            {
                // TODO: Hata mesajını Logla
                return new List<Category>();
            }
        }

        public Category GetById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception)
            {
                // TODO: Hata mesajı Loglanacak
                return default;
            }
        }

        public CommandResult Create(Category category)
        {
            try
            {
                _repository.Add(category);

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                // TODO: Hata mesajını logla

                return CommandResult.Failure(ex);
            }
        }

        public CommandResult Update(Category category)
        {
            try
            {
                _repository.Update(category);

                // Factory Pattern
                return CommandResult.Success("Güncelleme başarılı");
            }
            catch (Exception ex)
            {
                // Factory Pattern
                return CommandResult.Failure("Güncelleme başarısız", ex);
            }
        }

        public CommandResult Delete(Category category)
        {
            try
            {
                _repository.Remove(category);

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
