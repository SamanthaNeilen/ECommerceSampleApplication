using ECommmerceApp.NetFramework.DataLayer.Interfaces;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ECommmerceApp.NetFramework.DataLayer
{
    public class ECommerceDbContext : DbContext, IECommerceDbContext
    {
        public ECommerceDbContext() 
            : base("name=ECommerceDbContext") 
        {
            Configuration.LazyLoadingEnabled = false;
        }
        
        public virtual IDbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }       
    }
}
