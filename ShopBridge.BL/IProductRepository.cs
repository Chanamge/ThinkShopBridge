using ShopBridge.Data;
using System;
using System.Collections.Generic;

namespace ShopBridge.BL
{
    public interface IProductRepository : IDisposable
    {
        PagedResponse<IEnumerable<Product>> GetProducts(PagingParameterModel pagingparametermodel);
        Product GetProductByID(int id);
        void InsertProduct(Product product);
        void DeleteProduct(int id);
        void UpdateProduct(Product product);
        int Save();
    }
}
