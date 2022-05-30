using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yakov.OOP.EnhancedPaint.Plugins.Interfaces;

namespace yakov.OOP.EnhancedPaint.Plugins.LoaderControl
{
    public abstract class LoaderInteract
    {
        public abstract IPlugin GetPlugin(PluginType pluginType, string pluginName);

    }
}
