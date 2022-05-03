﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yakov.OOP.EnhancedPaint.Plugins.Interfaces
{
    public interface IArchiver: IPlugin
    {
        string Archive(string data);
        string Dearchive(string archivedData);
    }
}
