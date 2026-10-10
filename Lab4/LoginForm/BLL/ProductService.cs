using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public void AddProduct(Product product)
        {
            // Business Logic before adding
            _productRepository.AddProduct(product);
        }

        public Product GetProduct(int id)
        {
            // Business Logic before retrieving
            return _productRepository.GetProductById(id);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public void UpdateProduct(Product product)
        {
            // Business Logic before updating
            _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(int id)
        {
            // Business Logic before deleting
            _productRepository.DeleteProduct(id);
        }
    }
}