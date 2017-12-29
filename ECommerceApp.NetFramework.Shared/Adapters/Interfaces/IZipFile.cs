
using Ionic.Zip;
using Ionic.Zlib;

namespace ECommerceApp.NetFramework.Shared.Adapters.Interfaces
{
    public interface IZipFile
    {
        Zip64Option UseZip64WhenSaving { get; set; }
        CompressionLevel CompressionLevel { get; set; }
        string Name { get; set; }
        IZipEntry AddFile(string location);
        void Save(string location);
    }
}
