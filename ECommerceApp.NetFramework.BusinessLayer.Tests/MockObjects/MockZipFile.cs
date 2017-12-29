using ECommerceApp.NetFramework.Shared.Adapters.Interfaces;
using Ionic.Zip;
using Ionic.Zlib;
using System.Collections.Generic;

namespace ECommerceApp.NetFramework.BusinessLayer.Tests.MockObjects
{
    public class MockZipFile : IZipFile
    {
        public bool Saved = false;
        public List<MockZipEntry> ZipEntries = new List<MockZipEntry>();

        public Zip64Option UseZip64WhenSaving { get; set; }
        public CompressionLevel CompressionLevel { get; set; }
        public string Name { get; set; }

        public IZipEntry AddFile(string location)
        {
            var zipEntry = new MockZipEntry();
            zipEntry.Location = location;
            ZipEntries.Add(zipEntry);
            return zipEntry;
        }

        public void Save(string location)
        {
            Saved = true;
        }
    }
}
