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
        public override IPlugin GetPlugin(PluginType pluginType, string pluginName)
        {
            try
            {
                IPlugin resultPlugin = _pluginLoader.Plugins[pluginType].First();

                if (pluginName != null)
                    foreach (var currPlugin in _pluginLoader.Plugins[pluginType])
                        if (currPlugin.Name == pluginName)
                        {
                            resultPlugin = currPlugin;
                            break;
                        }

                return resultPlugin;
            }
            catch
            {
                return null;
            }
        }
    }
}
