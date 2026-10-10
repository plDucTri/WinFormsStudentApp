using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class SupplierService
    {
        private readonly SupplierRepository _supplierRepository;

        public SupplierService()
        {
            _supplierRepository = new SupplierRepository();
        }

        public void AddSupplier(Supplier supplier)
        {
            // Business Logic before adding
            _supplierRepository.AddSupplier(supplier);
        }

        public Supplier GetSupplier(int id)
        {
            // Business Logic before retrieving
            return _supplierRepository.GetSupplierById(id);
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _supplierRepository.GetAllSuppliers();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            // Business Logic before updating
            _supplierRepository.UpdateSupplier(supplier);
        }

        public void DeleteSupplier(int id)
        {
            // Business Logic before deleting
            _supplierRepository.DeleteSupplier(id);
        }
    }
}