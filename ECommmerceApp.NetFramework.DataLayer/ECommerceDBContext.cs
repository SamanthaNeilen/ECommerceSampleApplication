using ECommmerceApp.NetFramework.DataLayer.Interfaces;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ECommmerceApp.NetFramework.DataLayer
{
    public class ECommerceDBContext : DbContext, IECommerceDBContext
    {
        public ECommerceDBContext() 
            : base("name=ECommerceDBContext") 
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
