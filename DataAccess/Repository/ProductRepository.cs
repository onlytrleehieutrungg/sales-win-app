using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(int productId) => ProductDBContext.Instance.Remove(productId);


        public IEnumerable<Product> GetProduct() => ProductDBContext.Instance.GetProductList();


        public Product GetProductByID(int productId) => ProductDBContext.Instance.GetProductByID(productId);


        public void InsertProduct(Product product) => ProductDBContext.Instance.AddNew(product);

        public IEnumerable<Product> Search(int productId) => ProductDBContext.Instance.SearchProduct(productId);


        public IEnumerable<Product> Search(string productName) => ProductDBContext.Instance.SearchProduct(productName);


        public void UpdateProduct(Product product) => ProductDBContext.Instance.Update(product);

    }
}
