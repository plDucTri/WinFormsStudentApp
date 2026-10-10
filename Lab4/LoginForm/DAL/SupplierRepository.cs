using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SupplierRepository
    {
        private readonly LabDbContext _context;

        public SupplierRepository()
        {
            _context = new LabDbContext();
        }

        public void AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public Supplier GetSupplierById(int id)
        {
            return _context.Suppliers.FirstOrDefault(s => s.SupplierID == id);
        }

        public List<Supplier> GetAllSuppliers()
        {
            return _context.Suppliers.ToList();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            var existing = _context.Suppliers.FirstOrDefault(s => s.SupplierID == supplier.SupplierID);
            if (existing != null)
            {
                existing.SupplierName = supplier.SupplierName;
                existing.ProductName = supplier.ProductName;
                _context.SaveChanges();
            }
        }

        public void DeleteSupplier(int id)
        {
            var supplier = _context.Suppliers.FirstOrDefault(s => s.SupplierID == id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }
        }
    }
}