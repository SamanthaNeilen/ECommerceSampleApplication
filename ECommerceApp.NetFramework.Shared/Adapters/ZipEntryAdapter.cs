using ECommerceApp.NetFramework.Shared.Adapters.Interfaces;
using Ionic.Zip;

namespace ECommerceApp.NetFramework.Shared.Adapters
{
    public class ZipEntryAdapter : IZipEntry
    {
        private ZipEntry _zipEntry;

        public ZipEntryAdapter(ZipEntry zipEntry)
        {
            _zipEntry = zipEntry;
        }

        public string FileName { get { return _zipEntry.FileName; } set { _zipEntry.FileName = value; } }
    }
}
