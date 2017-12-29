using System.Data.Entity;

namespace ECommmerceApp.NetFramework.DataLayer.Interfaces
{
    public interface IECommerceDbContext
    {
        IDbSet<Customer> Customer { get; set; }

        int SaveChanges();
    }
}