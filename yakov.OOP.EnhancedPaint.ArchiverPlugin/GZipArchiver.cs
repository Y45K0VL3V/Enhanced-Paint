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

        public string Archive(string data)
        {
            var sourceStream = new MemoryStream(Encoding.UTF8.GetBytes(data));
            var resultStream = new MemoryStream();

            var archiveStream = new GZipStream(resultStream, CompressionMode.Compress);
            sourceStream.CopyTo(archiveStream);

            return Encoding.UTF8.GetString(resultStream.ToArray());
        }

        public string Dearchive(string archivedData)
        {
            var sourceStream = new MemoryStream(Encoding.UTF8.GetBytes(archivedData));
            var resultStream = new MemoryStream();

            var archiveStream = new GZipStream(resultStream, CompressionMode.Decompress);
            sourceStream.CopyTo(archiveStream);

            return Encoding.UTF8.GetString(resultStream.ToArray());
        }
    }
}
