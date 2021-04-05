using ShopBridge.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ShopBridge.BL
{
    public class ProductRepository : IProductRepository
    {
        private ShopBridgeContext _context;
        public ProductRepository()
        {
            this._context = new ShopBridgeContext();
        }

        //
        // Summary:
        //     Returns a Paginated response of Product list.
        //
        // Returns:
        //     A PageResponse object that can be used to iterate through the data object for Product list.
        public PagedResponse<IEnumerable<Product>> GetProducts(PagingParameterModel pagingmodel)
        {
            // Return List of Product 
            var source = _context.Products.AsQueryable().OrderBy(p => p.Id);

            // Get's No of Rows Count   
            int totalCount = source.Count();

            // Calculating Totalpage by Dividing (No of Records / Pagesize)  
            int totalPages = (int)Math.Ceiling(totalCount / (double)pagingmodel.pageSize);

            // Returns List of Product after applying Paging   
            var products = source.Skip((pagingmodel.pageNumber - 1) * pagingmodel.pageSize).Take(pagingmodel.pageSize).ToList();

            // Calculating previousPage
            int previousPage = (pagingmodel.pageNumber - 1) > 0 ? (pagingmodel.pageNumber - 1) : 0;

            // Calculating nextPage 
            int nextPage = (pagingmodel.pageNumber + 1) > totalPages ? totalPages : (pagingmodel.pageNumber + 1);

            // Object which we are going to send
            var paginationMetadata = new PagedResponse<IEnumerable<Product>>(
                (IEnumerable<Product>)products,
                pagingmodel.pageNumber,
                pagingmodel.pageSize,
                totalPages,
                totalCount,
                pagingmodel.pageNumber - 1,
                pagingmodel.pageNumber + 1
            );
            return paginationMetadata;
        }

        //
        // Summary:
        //     Finds a Product record with the given id. If an entity with the given
        //     values exists, then it is returns object.
        //
        // Returns:
        //     The entity found for the given id, or null.
        public Product GetProductByID(int id)
        {
            return _context.Products.Find(id);
        }

        //
        // Summary:
        //     Add the given entity into the context such that it will be inserted into the
        //     database when Save is called.
        //
        // Returns:
        //     The entity.
        public void InsertProduct(Product product)
        {
            _context.Products.Add(product);
        }

        //
        // Summary:
        //     Removes the given entity from the context such that it will be deleted from the
        //     database when Save is called.
        //
        // Returns:
        //     The entity.
        public void DeleteProduct(int productID)
        {
            Product product = _context.Products.Find(productID);
            _context.Products.Remove(product);
        }

        //
        // Summary:
        //      Sets the state of the entity to modified. Changes will reflect in
        //      the database when Save is called.
        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }

        //
        // Summary:
        //     Saves all changes made in this context to the underlying database.
        //
        // Returns:
        //     The number of state entries written to the database.
        public int Save()
        {
            return _context.SaveChanges();
        }


        private bool disposed = false;
        //
        // Summary:
        //     Disposes the current context by calling dispose method.
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
