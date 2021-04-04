using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ShopBridge.DAL
{
    public class ProductRepository : IProductRepository
    {
        private ShopBridgeContext _context;
        public ProductRepository(ShopBridgeContext shopBridgeContext)
        {
            this._context = shopBridgeContext;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
        public Product GetProductByID(int id)
        {
            return _context.Products.Find(id);
        }
        public void InsertProduct(Product product)
        {
            _context.Products.Add(product);
        }
        public void DeleteProduct(int productID)
        {
            Product product = _context.Products.Find(productID);
            _context.Products.Remove(product);
        }
        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
