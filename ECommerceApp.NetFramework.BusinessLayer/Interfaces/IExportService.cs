using ECommerceApp.NetFramework.Shared.Adapters.Interfaces;
namespace ECommerceApp.NetFramework.BusinessLayer.Interfaces
{
    public interface IExportService
    {
        IZipFile CreateCustomerOverviewZipFile();
    }
}
