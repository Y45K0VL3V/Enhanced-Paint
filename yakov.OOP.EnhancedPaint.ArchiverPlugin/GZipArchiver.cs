﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yakov.OOP.EnhancedPaint.Plugins.Interfaces;
using yakov.OOP.EnhancedPaint.Plugins;

namespace yakov.OOP.EnhancedPaint.ArchiverPlugin
{
    [Plugin(PluginType.Archiver)]
    public class GZipArchiver : IArchiver
    {
        public string Archive(string data)
        {
            throw new NotImplementedException();
        }

        public string Dearchive(string archivedData)
        {
            throw new NotImplementedException();
        }
    }
}