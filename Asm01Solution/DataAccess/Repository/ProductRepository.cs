using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product product) => ProductDAO.Instance.AddProduct(product);

        public void DeleteProduct(Product product) => ProductDAO.Instance.DeleteProduct(product);

        public IEnumerable<Product> GetAllProducts() => ProductDAO.Instance.GetAllProducts();

        public Product GetProductById(int productId) => ProductDAO.Instance.getProductById(productId);

        public IEnumerable<Product> GetProductsByPrice(decimal price) => ProductDAO.Instance.GetProductsByPrice(price);

        public IEnumerable<Product> GetProductsByUnitInStock(int unit) => ProductDAO.Instance.GetProductsByUnitInStock(unit);

        public void UpdateProduct(Product product) => ProductDAO.Instance.UpdateProduct(product);
    }
}
