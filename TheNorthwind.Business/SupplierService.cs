using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheNorthwind.DataAccess;

namespace TheNorthwind.Business
{
    public class SupplierService
    {
        private SupplierRepository _repository = new SupplierRepository();

        public Supplier GetById(int id)
        {
            try
            {
                return _repository.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Supplier> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception)
            {
                return new List<Supplier>();
            }
        }

        public CommandResult Create(Supplier supplier)
        {
            try
            {
                _repository.Add(supplier);
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex);
            }
        }

        public CommandResult Update(Supplier supplier)
        {
            try
            {
                _repository.Update(supplier);
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex);
            }
        }

        public CommandResult Delete(Supplier supplier)
        {
            try
            {
                _repository.Remove(supplier);
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex);
            }
        }
    }
}
