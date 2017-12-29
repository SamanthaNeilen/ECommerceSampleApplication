using ECommerceApp.NetFramework.Shared.Adapters.Interfaces;
using Ionic.Zip;
using Ionic.Zlib;

namespace ECommerceApp.NetFramework.Shared.Adapters
{
    public class ZipFileAdapter : ZipFile, IZipFile
    {
        public ZipFileAdapter()
        {
            UseZip64WhenSaving = Zip64Option.AsNecessary;
            CompressionLevel = CompressionLevel.BestCompression;
        }        

        IZipEntry IZipFile.AddFile(string location)
        {
            return new ZipEntryAdapter(AddFile(location));
        }
    }
}
