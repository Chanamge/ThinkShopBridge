using ShopBridge.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ShopBridge.DAL
{
    public class ShopBridgeContext : DbContext
    {
        public ShopBridgeContext()
            : base("name=ShopBridgeConnectionString")
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
