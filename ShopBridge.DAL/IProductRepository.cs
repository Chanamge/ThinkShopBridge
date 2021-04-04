using ShopBridge.Models;
using System;
using System.Collections.Generic;

namespace ShopBridge.DAL
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(int id);
        void InsertProduct(Product product);
        void DeleteProduct(int id);
        void UpdateProduct(Product product);
        int Save();
    }
}
