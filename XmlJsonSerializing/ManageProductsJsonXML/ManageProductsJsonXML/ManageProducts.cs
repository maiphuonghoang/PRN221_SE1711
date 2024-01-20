using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ManageProductsJsonXML
{
    public record Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
    public class ManageProducts
    {
        string filename = "ProductList.json";
        List<Product> products = new List<Product>();
        public List<Product> GetProducts()
        {
            GetDataFromFile();
            return products;
        }

        private void GetDataFromFile()
        {
            try
            {
                if (File.Exists(filename))
                {
                    string jsonData = File.ReadAllText(filename);
                    products = JsonSerializer.Deserialize<List<Product>>(jsonData);

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertProduct(Product product)
        {
            try
            {
                var p = products.SingleOrDefault(x => x.ProductId == product.ProductId);
                if (p != null)
                {
                    throw new Exception("This product already exists");
                };
                products.Add(product);
                StoreToFile();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void StoreToFile()
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(products, new JsonSerializerOptions
                {
                    WriteIndented = true,
                });
                File.WriteAllText(filename, jsonData);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                var p = products.SingleOrDefault(x => x.ProductId == product.ProductId);
                if (p == null)
                {
                    throw new Exception("This product does not exists");
                };
                p.ProductName = product.ProductName;
                StoreToFile();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void DeleteProduct(Product product)
        {
            try
            {
                var p = products.SingleOrDefault(x => x.ProductId == product.ProductId);
                if (p == null)
                {
                    throw new Exception("This product does not exists");
                }
                products.Remove(p);
                StoreToFile();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
