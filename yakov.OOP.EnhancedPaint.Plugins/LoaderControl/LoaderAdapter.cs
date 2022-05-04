using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yakov.OOP.EnhancedPaint.Plugins.Interfaces;

namespace yakov.OOP.EnhancedPaint.Plugins.LoaderControl
{
    public class LoaderAdapter : LoaderInteract
    {
        private PluginLoader _pluginLoader = PluginLoader.GetInstance();
        public override IPlugin GetPlugin(PluginType pluginType)
        {
            return _pluginLoader.Plugins[pluginType].First();
        }
    }
}
