using System.Data.Entity;

namespace ECommmerceApp.NetFramework.DataLayer.Interfaces
{
    public interface IECommerceDBContext
    {
        IDbSet<Customer> Customer { get; set; }

        int SaveChanges();
    }
}