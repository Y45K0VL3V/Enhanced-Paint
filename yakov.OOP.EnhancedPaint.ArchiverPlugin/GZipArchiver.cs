using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yakov.OOP.EnhancedPaint.Plugins.Interfaces;
using yakov.OOP.EnhancedPaint.Plugins;
using System.Reflection;
using System.IO.Compression;
using System.IO;

namespace yakov.OOP.EnhancedPaint.ArchiverPlugin
{
    [Plugin(PluginType.Archiver)]
    public class GZipArchiver : IArchiver
    {
        public string Path { get; set; }

        public void Archive(ref byte[] data)
        {
            using (var resultStream = new MemoryStream())
            {
                using (var archiveStream = new GZipStream(resultStream, CompressionMode.Compress))
                {
                    archiveStream.Write(data, 0, data.Length);
                    archiveStream.Close();
                    data = resultStream.ToArray();
                }
            }
        }

        public void Dearchive(ref byte[] archivedData)
        {
            using (var sourceStream = new MemoryStream(archivedData))
            {
                using (var resultStream = new MemoryStream())
                {
                    using (var archiveStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        archiveStream.CopyTo(resultStream);
                        archiveStream.Close();
                        archivedData = resultStream.ToArray();
                    }
                }
            }
        }
    }
}
