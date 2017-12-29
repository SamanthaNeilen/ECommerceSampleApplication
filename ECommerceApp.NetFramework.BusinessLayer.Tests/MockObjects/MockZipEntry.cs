using ECommerceApp.NetFramework.Shared.Adapters.Interfaces;

namespace ECommerceApp.NetFramework.BusinessLayer.Tests.MockObjects
{
    public class MockZipEntry : IZipEntry
    {
        public string FileName { get; set; }

        public string Location { get; set; }
    }
}