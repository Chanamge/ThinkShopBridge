using ShopBridge.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ShopBridge.Data
{
    public class ShopBridgeContext : DbContext
    {
        public ShopBridgeContext()
            : base("name=ShopBridgeEntities")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ShopBridgeContext>());
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }
    }
}
