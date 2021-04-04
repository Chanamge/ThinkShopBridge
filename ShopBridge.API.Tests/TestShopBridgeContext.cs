using ShopBridge.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.API.Tests
{
    public class TestShopBridgeContext : ShopBridgeContext
    {
        public TestShopBridgeContext()
        {
            this.Products = new TestProductDBSet();
        }

        public DbSet<Product> Products { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void Dispose() { }
    }
}
